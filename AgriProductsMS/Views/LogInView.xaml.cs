using System;
using System.Configuration; // Add this namespace
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AgriProductsManagementSystem.Views
{
    public partial class LogInView : UserControl
    {

        public LogInView()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            string loginAs = ((ComboBoxItem)LoginAsComboBox.SelectedItem)?.Content.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(loginAs))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (loginAs == "Dealer")
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // Change "YourConnectionStringName" accordingly
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = $"SELECT * FROM Dealer WHERE username = @username AND password = @password";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            MessageBox.Show($"Welcome, {username}! You are logged in as {loginAs}.", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                            var dealerView = new DealerDashboardView(); 
                            var mainWindow = Application.Current.MainWindow;
                            mainWindow.Content = dealerView;
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                if (loginAs == "Purchaser")
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // Change "YourConnectionStringName" accordingly
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = $"SELECT * FROM Purchasers WHERE username = @username AND password = @password";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            MessageBox.Show($"Welcome, {username}! You are logged in as {loginAs}.", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                            var dealerView = new DealerDashboardView();
                            var mainWindow = Application.Current.MainWindow;
                            mainWindow.Content = dealerView;
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                if (loginAs == "")
                {
                    MessageBox.Show("Kindly choose user type in LoginAs before logging in!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
