using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    
    {
        ApplicationContext db;
        
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();


        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox2.Password.Trim();
            string email = textBoxMail.Text.ToLower().Trim();

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Введіть коректні значення";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Введіть коректні значення";
                passBox.Background = Brushes.DarkRed;
            }
            else if (pass != pass_2)
            {
                passBox2.ToolTip = "Паролі не співпадають";
                passBox2.Background = Brushes.DarkRed;
            }
            else if (email.Length <5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxMail.ToolTip = "Паролі не співпадають";
                textBoxMail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;
                textBoxMail.ToolTip = "";
                textBoxMail.Background = Brushes.Transparent;

                MessageBox.Show("Дякую ви зарееструвались!");
                User user = new User(login, email, pass);


                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        private void Button_Open_Window_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();

        }


    }
}
