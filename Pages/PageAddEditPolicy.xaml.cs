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
    /// Логика взаимодействия для PageAddEditPolicy.xaml
    /// </summary>
    public partial class PageAddEditPolicy : Page
    {
        Policy policy = new Policy();

        public PageAddEditPolicy(Policy policies)
        {
            InitializeComponent();


            if (policies != null)
                policy = policies;

            DataContext = policy;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (policy.ID == 0)
                PractikaEntities.GetContext().Policy.Add(policy);

            try
            {
                PractikaEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения успешно сохранены");
                ClassFrame.frmObj.Navigate(new Main());
            }
            catch (Exception ex)
            {
                ToolTip = ex.Message;
                TxtNumPol.Background = Brushes.Red;
                TxtNumRec.Background = Brushes.Red;
                TxtFIO.Background = Brushes.Red;
                TxtDateIssue.Background = Brushes.Red;
                TxtPrice.Background = Brushes.Red;
                TxtAddress.Background = Brushes.Red;
                TxtPhNum.Background = Brushes.Red;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.Main());
        }
    }
}
