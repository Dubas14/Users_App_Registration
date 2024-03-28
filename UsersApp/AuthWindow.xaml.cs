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

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }


        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();


            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Введіть коректні значення";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Введіть коректні значення";
                passBox.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User autUser = null;
                using (ApplicationContext context = new ApplicationContext())
                {
                    autUser = context.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }
                if (autUser != null)
                    MessageBox.Show("Ви війшли до кабінету");
                else
                {
                    MessageBox.Show("Не коректні дані");
                }

            }


        }
    }
}
