using AgriProductsManagementSystem.ViewModels;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using AgriProductsManagementSystem.DataAccess;
using System.Configuration;

namespace AgriProductsManagementSystem.Views
{
    public partial class SignUpView : UserControl
    {
        // Create an instance of the DbContextOptions for PurchaserDbContext
        private readonly DbContextOptions<AppDbContext> dbContextOptions =
            new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
            .Options;

        // Create an instance of the PurchaserDbContext
        private readonly AppDbContext dbContext;

        // Create an instance of the PurchaserSignupViewModel, passing the PurchaserDbContext
        private readonly PurchaserSignupViewModel viewModel;

        public SignUpView()
        {
            InitializeComponent();

            // Create the PurchaserDbContext with the options
            dbContext = new AppDbContext(dbContextOptions);

            // Create the view model with the PurchaserDbContext
            viewModel = new PurchaserSignupViewModel(dbContext);

            // Set the DataContext to the view model
            DataContext = viewModel;
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            // Call the SignUp method of the view model
            viewModel.SignUp();
        }

        private void LoginLink_Click(object sender, RoutedEventArgs e)
        {
            // Redirect to the LoginView
            var loginView = new LogInView();
            var mainWindow = Application.Current.MainWindow;
            mainWindow.Content = loginView;
        }
    }
}
