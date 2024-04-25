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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            CheckUserRole();
            DtgArchive.ItemsSource =
                PractikaEntities.GetContext().Policy.ToList();

            var RegistrationDate = PractikaEntities.GetContext().Policy.
                Select(x => x.Date_of_issue).Distinct().ToList();

            CmbDate.Items.Add("Все даты");
            CmbDate.SelectedIndex = 0;
            foreach (var date in RegistrationDate) 
            {
                CmbDate.Items.Add(date);
            }
        }

        private void CheckUserRole()
        {
            if(ClassFrame.ID_Role == 1)
            {
                Adm.Visibility = Visibility.Visible;
            }
            else
            {
                Adm.Visibility = Visibility.Collapsed;
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TxtSearch.Text;
            DtgArchive.ItemsSource = PractikaEntities.GetContext().Policy.
                Where(x => x.FIO.Contains(search)).ToList();
        }

        private void RbtnAsc_Click(object sender, RoutedEventArgs e)
        {
            DtgArchive.ItemsSource = PractikaEntities.GetContext().Policy.
                OrderBy(x => x.Price).ToList();
        }

        private void RbtnDesc_Click(object sender, RoutedEventArgs e)
        {
            DtgArchive.ItemsSource = PractikaEntities.GetContext().Policy.
                OrderByDescending(x => x.Price).ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new Pages.PageAddEditPolicy(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var policy =
                DtgArchive.SelectedItems.
                Cast<Policy>().ToList();

            if (MessageBox.Show
                ($"Удалить {policy.Count()} " +
                $"полисы?",
                "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    PractikaEntities.GetContext().
                        Policy.RemoveRange(policy);

                    PractikaEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены");
                    DtgArchive.ItemsSource = PractikaEntities.GetContext().Policy.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.Main_Clients());
        }

        private void CmbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string dat = CmbDate.SelectedValue.ToString();

                if (dat == "Все даты")
                {
                    DtgArchive.ItemsSource = PractikaEntities.GetContext().Policy.ToList();
                }
                else
                {
                    DtgArchive.ItemsSource = PractikaEntities.GetContext().Policy.Where(x => x.Date_of_issue == dat).ToList();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(
                new PageAddEditPolicy((sender as Button).DataContext as Policy));
        }

        private void Adm_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AdminPage());
        }
    }
}
