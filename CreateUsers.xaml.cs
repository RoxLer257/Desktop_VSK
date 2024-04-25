using Practika.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Practika
{
    /// <summary>
    /// Логика взаимодействия для CreateUsers.xaml
    /// </summary>
    public partial class CreateUsers : Window
    {
        private PractikaEntities practikaEntities;
        public CreateUsers()
        {
            InitializeComponent();
            practikaEntities = PractikaEntities.GetContext();
            RoleComboBox.ItemsSource = practikaEntities.Roles.ToList();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Text;
            var role = (RoleComboBox.SelectedItem as Roles).ID_Role;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                var user = new Users { Login = login, Password = password, Role = role };

                using (var dbContext = practikaEntities)
                {
                    practikaEntities.Users.Add(user);
                    practikaEntities.SaveChanges();
                }

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Не правильно заполнены данные");
            }
        }
    }
}
