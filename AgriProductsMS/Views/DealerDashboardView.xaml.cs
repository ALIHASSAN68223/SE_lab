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

namespace AgriProductsManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for DealerDashboardView.xaml
    /// </summary>
    public partial class DealerDashboardView : UserControl
    {
        public DealerDashboardView()
        {
            InitializeComponent();

        }

        private void AddEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            var addEmployeesView = new DealerAddEmployeeView();
            var mainWindow = Application.Current.MainWindow;
            mainWindow.Content = addEmployeesView;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

            // Redirect to the LoginView
            var loginView = new LogInView();
            var mainWindow = Application.Current.MainWindow;
            mainWindow.Content = loginView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
