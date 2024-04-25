using Practika.Classes;
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

namespace Practika.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.practika.Users.Count(x => x.Login == TxtLogin.Text) > 0)
            {
                TxtLogin.ToolTip = "Пользователь с таким логином есть";
                TxtLogin.Background = Brushes.Red;
                MessageBox.Show("Пользователь с таким логином есть", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Users UserObj = new Users()
                {
                    Login = TxtLogin.Text,
                    Password = TxtPassword.Text,
                    Role = 2
                };
                AppConnect.practika.Users.Add(UserObj);
                AppConnect.practika.SaveChanges();

                ClassFrame.ID_Role = UserObj.id;

                Classes.ClassFrame.frmObj.Navigate(new Pages.Main());

                MessageBox.Show("Данные успешно добавлены",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.Authorization());
        }

        private void PsbConfPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PsbConfPassword.Password != TxtPassword.Text) 
            {
                BtnCreate.IsEnabled = false;
                PsbConfPassword.Background = Brushes.LightCoral;
                PsbConfPassword.BorderBrush = Brushes.Red;
            }
            else
            { 
                BtnCreate.IsEnabled = true;
                PsbConfPassword.Background = Brushes.LightGreen;
                PsbConfPassword.BorderBrush= Brushes.Green;
            }
        }
    }
}
