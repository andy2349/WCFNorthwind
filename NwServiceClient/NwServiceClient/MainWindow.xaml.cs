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
using System.ServiceModel;
using NwServiceClient.NwService;

namespace NwServiceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnTabSelection(object sender, SelectionChangedEventArgs e)
        {

                if (this.tabCustomers.IsSelected)
                    FillGridCustomers();
                if (this.tabEmployees.IsSelected)
                    FillGridEmployees();
        }

        private void RefreshCustomers(object sender, RoutedEventArgs e)
        {
            FillGridCustomers();
        }

        private void RefreshEmployees(object sender, RoutedEventArgs e)
        {
            FillGridEmployees();
        }

        private void FillGridCustomers()
        {
            using (ServiceClient client = new ServiceClient())
            {
                try
                {
                    this.gridCustomers.ItemsSource = client.GetCustomers();
                }
                catch (EndpointNotFoundException)
                {
                    var msg = "Connection could not be established!";
                    Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(msg)));
                }
            }
        }

        private void FillGridEmployees()
        {
            using (ServiceClient client = new ServiceClient())
            {
                try
                {
                    this.gridEmployees.ItemsSource = client.GetEmployees(dtpBirth.SelectedDate, dtpHire.SelectedDate);
                }
                catch (EndpointNotFoundException)
                {
                    var msg = "Connection could not be established!";
                    Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(msg)));
                }
            }
        }
    }
}
