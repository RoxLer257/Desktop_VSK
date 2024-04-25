using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private PractikaEntities practikaEntities;
        public AdminPage()
        {
            InitializeComponent();
            practikaEntities = PractikaEntities.GetContext();
            UserListView.ItemsSource = practikaEntities.Users.ToList();
            RefreshUser();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var createUserWindow = new CreateUsers();

            if (createUserWindow.ShowDialog() == true)
            {
                RefreshUser();
            }
        }

        private void DelUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UserListView.SelectedItem as Users;
            if( selectedUser != null)
            {
                practikaEntities.Users.Remove(selectedUser);
                practikaEntities.SaveChanges();
                RefreshUser();
            }
        }

        private void RefUser_Click(object sender, RoutedEventArgs e)
        {
            RefreshUser();
        }

        private void RefreshUser()
        {
            try
            {
                UserListView.ItemsSource = practikaEntities.Users.ToList();
            }
            catch 
            {
                MessageBox.Show("Исключение");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new Main());
        }
    }
}
