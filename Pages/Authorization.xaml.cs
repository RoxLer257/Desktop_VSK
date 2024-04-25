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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.practika.Users.FirstOrDefault(x => x.Login == TxtLogin.Text && x.Password == PsbPassword.Password);
                if (userObj == null)
                {
                    TxtLogin.ToolTip = "Такого пользователя нет";
                    TxtLogin.Background = Brushes.Red;
                    MessageBox.Show("Такого пользователя нет", "Ошибка при авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    ClassFrame.ID_Role = userObj.Roles.ID_Role;
                    Classes.ClassFrame.frmObj.Navigate(new Pages.Main());
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения", "Уведомления", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.Registration());
        }
    }
}
