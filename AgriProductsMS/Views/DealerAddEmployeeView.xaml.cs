using AgriProductsManagementSystem.DataAccess;
using AgriProductsManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for DealerAddEmployeeView.xaml
    /// </summary>
    public partial class DealerAddEmployeeView : UserControl
    {
        // Create an instance of the DbContextOptions for EmployeeDbContext
        private readonly DbContextOptions<AppDbContext> dbContextOptions =
            new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
            .Options;

        // Create an instance of the EmployeeDbContext
        private readonly AppDbContext dbContext;

        // Create an instance of the DealerAddEmployeeViewModel, passing the EmployeeDbContext
        private readonly DealerAddEmployeeViewModel viewModel;

        public DealerAddEmployeeView()
        {
            InitializeComponent();

            // Create the EmployeeDbContext with the options
            dbContext = new AppDbContext(dbContextOptions);

            // Create the view model with the EmployeeDbContext
            viewModel = new DealerAddEmployeeViewModel(dbContext);

            // Set the DataContext to the view model
            DataContext = viewModel;
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            // Call the SignUp method of the view model
            viewModel.AddEmployee();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var dashboardView = new DealerDashboardView();
            var mainWindow = Application.Current.MainWindow;
            mainWindow.Content = dashboardView;
        }

    }

}
