using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Diagnostics;

namespace Izdatelstvo
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        IzdatelstvoEntities1 db = new IzdatelstvoEntities1();

        string filename = null;
        string shortFileName = null;
        string Login;
        int id_writer = 0;

        public Menu(string Login)
        {
            InitializeComponent();
            this.Login = Login;
            Writer.Text = Login;
            Data_send.Text = DateTime.Today.ToShortDateString();
            id_writer = find_writer();
            ListDoc.ItemsSource = IzdatelstvoEntities1.GetContext().Manuscripts.Where(r => r.ID_writers == id_writer).ToList();
        }
        

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            //foreach (var item in db.Manuscripts)
            //{
            //    if (item.ID == 3)
            //    {
            //        string filename = System.IO.Path.GetTempFileName() + "." + "pdf"; // Makes something like "C:\Temp\blah.tmp.pdf"
            //        File.WriteAllBytes(filename, item.Soderjanie);
            //        var process = Process.Start(filename);
            //        // Clean up our temporary file...
            //        process.Exited += (s, e) => System.IO.File.Delete(filename);
            //    }
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".docx"; // Default file extension
            dlg.Filter = "Text documents (.docx; .txt; .doc; .pdf) | *.docx;*.txt; *.doc; *.pdf"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
                shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1);
                FileName.Text = shortFileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            byte[] buffer;
            buffer = File.ReadAllBytes(filename);

            try
            {
                Manuscripts man = new Manuscripts(shortFileName,buffer, Convert.ToDateTime(Data_send.Text) ,find_writer());
                db.Manuscripts.Add(man);
                db.SaveChanges();
                MessageBox.Show("Отправлено");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }

        int find_writer()
        {
            foreach (var item in db.Writers)
            {
                if (Writer.Text == item.Login)
                {
                    return item.ID;
                }
            }
            return -1;
        }
    }
}
