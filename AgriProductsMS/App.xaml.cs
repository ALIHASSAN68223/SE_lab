using AgriProductsManagementSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Windows;

namespace AgriProductsManagementSystem
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Retrieve connection string from configuration
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Configure DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var dbContextOptions = optionsBuilder.Options;

            // Create and configure your DbContext
            using (var context = new AppDbContext(dbContextOptions))
            {
                try
                {
                    // Try to open a connection to the database
                    context.Database.OpenConnection();

                    // If successful, show a message
                    MessageBox.Show("Database connected successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    // If an exception occurs, show an error message
                    MessageBox.Show($"Error connecting to the database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    // Close the connection if it was opened
                    context.Database.CloseConnection();
                }
            }

            // Continue with the application startup...
        }
    }
}
