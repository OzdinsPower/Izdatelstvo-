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

namespace Izdatelstvo
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }
        Writers client = new Writers(); 
        IzdatelstvoEntities1 db = new IzdatelstvoEntities1();
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text != "" && txtPass.Text != ""  && txtFam.Text != "" && txtName.Text != "" || txtOtch.Text != "" || txtMail.Text != "")
            {
                foreach (var user in db.Writers)
                {
                    if (user.Login == txtLogin.Text)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка");
                        return;
                    }
                }
                client.Login = txtLogin.Text.Trim();
                client.Name = txtName.Text.Trim();
                client.Password = txtPass.Text.Trim();
                client.Surname = txtFam.Text.Trim();
                client.Email = txtMail.Text.Trim();
                client.Lastname = txtOtch.Text.Trim();
                db.Writers.Add(client);
                db.SaveChanges();
                Menu men = new Menu(txtLogin.Text);
                men.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все данные введены!");
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
