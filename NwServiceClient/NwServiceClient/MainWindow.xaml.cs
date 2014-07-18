namespace NwServiceClient
{
    using System;
    using System.ServiceModel;
    using System.Windows;
    using System.Windows.Controls;
    using NwService;
    
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnTabSelection(object sender, SelectionChangedEventArgs e)
        {
            if (tabCustomers.IsSelected)
            {
                FillGridCustomers();
            }

            if (tabEmployees.IsSelected)
            {
                FillGridEmployees();
            }
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
            using (var client = new ServiceClient())
            {
                string msg = "Connection could not be established!";
                try
                {
                    gridCustomers.ItemsSource = client.GetCustomers();
                }
                catch (EndpointNotFoundException)
                {
                    Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(msg)));
                }
            }
        }

        private void FillGridEmployees()
        {
            using (var client = new ServiceClient())
            {
                try
                {
                    gridEmployees.ItemsSource = client.GetEmployees(dtpBirth.SelectedDate, dtpHire.SelectedDate);
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
