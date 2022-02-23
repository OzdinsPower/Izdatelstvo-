using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

namespace Izdatelstvo
{
    /// <summary>
    /// Логика взаимодействия для MenuSot.xaml
    /// </summary>
    public partial class MenuSot : Window
    {
        public MenuSot()
        {
            InitializeComponent();
        }

        IzdatelstvoEntities1 db = new IzdatelstvoEntities1();

        //string filename = null;
        //string shortFileName = null;
        string Login;
        int id_sotrudnik = 0;

        public MenuSot(string Login)
        {
            InitializeComponent();
            this.Login = Login;
            id_sotrudnik = find_sotrudnik();
            ListDoc.ItemsSource = IzdatelstvoEntities1.GetContext().Manuscripts.Where(r => r.ID_sotrudnik == id_sotrudnik).ToList();
        }

        int find_sotrudnik()
        {
            foreach (var item in db.Sotrudniki)
            {
                if (Login == item.Login)
                {
                    return item.ID;
                }
            }
            return -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in db.Manuscripts)
            {
                if (item.ID == ((Manuscripts)ListDoc.SelectedItem).ID) // Приводит выбранный элемент к классу 
                {
                    string filename = @".\Скачанный документ.doc"; 
                    File.WriteAllBytes(filename, item.Soderjanie);
                    var process = Process.Start(filename);
                }
            }
        }
    }
}
