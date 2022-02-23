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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Izdatelstvo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        IzdatelstvoEntities1 db = new IzdatelstvoEntities1();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (db.Writers.Where(r => r.Login == txtLogin.Text && r.Password == txtPass.Text).Count() > 0)
            {
                Menu men = new Menu(txtLogin.Text);
                men.Show();
                this.Close();
            }
            else
            {
                txtLogin.Text = "";
                txtPass.Text = "";
                MessageBox.Show("Неверный логин или пароль", "Ошибка");
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Registr reg = new Registr();
            reg.Show();
            this.Close();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (db.Sotrudniki.Where(r => r.Login == txtLogin.Text && r.Password == txtPass.Text).Count() > 0)
            {
                MenuSot men = new MenuSot(txtLogin.Text);
                men.Show();
                this.Close();
            }
            else
            {
                txtLogin.Text = "";
                txtPass.Text = "";
                MessageBox.Show("Неверный логин или пароль", "Ошибка");
            }
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
