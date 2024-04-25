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
    /// Логика взаимодействия для Main_Clients.xaml
    /// </summary>
    public partial class Main_Clients : Page
    {
        public Main_Clients()
        {
            InitializeComponent();
            DtgClients.ItemsSource = 
                PractikaEntities.GetContext().Policy.ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TxtSearch.Text;
            DtgClients.ItemsSource = PractikaEntities.GetContext().Policy.
                Where(x => x.FIO.Contains(search)).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var client = DtgClients.SelectedItems.Cast<Policy>().ToList();

            if (MessageBox.Show
                ($"Удалить {client.Count()} " +
                $"клиентов?",
                "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    PractikaEntities.GetContext().
                        Policy.RemoveRange(client);

                    PractikaEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены");
                    DtgClients.ItemsSource = PractikaEntities.GetContext().Policy.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.Main());
        }
    }
}
