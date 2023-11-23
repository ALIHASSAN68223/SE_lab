using AgriProductsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AgriProductsManagementSystem.Views
{
    // DealerDealsView UserControl for managing and adding deals for products.
    public partial class DealerDealsView : UserControl
    {
        // List to store products retrieved from the database
        private List<Product> products;

        // Constructor for the DealerDealsView UserControl.
        public DealerDealsView()
        {
            InitializeComponent();
            Loaded += DealerDealsView_Loaded; // Subscribe to the Loaded event
        }

        // Event handler for the Loaded event of the UserControl.
        private void DealerDealsView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData(); // Load data for active deals
            LoadManageDealsData(); // Load data for managing deals
        }

        // Loads data for active deals from the database and binds it to the manageDealsDataGrid.
        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to retrieve active deals with product details
                string query = @"
                    SELECT 
                        d.DealID, 
                        d.ProductID, 
                        p.ProductName,
                        d.Discount, 
                        d.ValidityPeriod
                    FROM 
                        Deals d
                    INNER JOIN 
                        Products p ON d.ProductID = p.ProductID
                    WHERE
                        d.ValidityPeriod > GETDATE()";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Deal> dataList = new List<Deal>();

                    // Read data from the database and populate the dataList
                    while (reader.Read())
                    {
                        Deal data = new Deal
                        {
                            DealID = reader.GetInt32(reader.GetOrdinal("DealID")),
                            ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                            ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                            Discount = reader.GetDecimal(reader.GetOrdinal("Discount")),
                            ValidityPeriod = reader.GetDateTime(reader.GetOrdinal("ValidityPeriod"))
                        };

                        dataList.Add(data);
                    }

                    // Bind the dataList to the manageDealsDataGrid
                    manageDealsDataGrid.ItemsSource = dataList;
                }
            }
        }

        // Loads product data from the database for adding new deals and binds it to the addDealsDataGrid.
        private void LoadManageDealsData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to retrieve product details for managing deals
                string query = @"
                    SELECT 
                        p.ProductID,
                        p.ProductName,
                        p.Price
                    FROM 
                        Products p";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    products = new List<Product>();

                    // Read product data from the database and populate the products list
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                            ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                        };

                        Deal deal = new Deal
                        {
                            Discount = 0,
                            ValidityPeriod = null
                        };

                        product.Deal = deal;
                        products.Add(product);
                    }

                    // Bind the products list to the addDealsDataGrid
                    addDealsDataGrid.ItemsSource = products;
                }
            }
        }

        // Event handler for the "Add Deal" button click.
        private void AddDeal_Click(object sender, RoutedEventArgs e)
        {
            if (addDealsDataGrid.SelectedItem is Product selectedProduct)
            {
                AddDeal(selectedProduct, selectedProduct.Deal?.Discount ?? 0);
                LoadData(); // Refresh active deals data
            }
            else
            {
                MessageBox.Show("Please select a product before adding a deal.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Adds a new deal for the specified product with the given discount.
        private void AddDeal(Product product, decimal discount)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to insert a new deal into the Deals table
                string query = @"
                    INSERT INTO Deals (ProductID, Discount, ValidityPeriod, CreatedAt, UpdatedAt, Active)
                    VALUES (@ProductID, @Discount, @ValidityPeriod, GETDATE(), GETDATE(), 1)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@Discount", discount);
                command.Parameters.AddWithValue("@ValidityPeriod", DateTime.Now.AddDays(30));

                command.ExecuteNonQuery();
            }
        }

        // Event handler for the "Update Deal" button click.
        private void UpdateDeal_Click(object sender, RoutedEventArgs e)
        {
            if (manageDealsDataGrid.SelectedItem != null)
            {
                Deal selectedDeal = (Deal)manageDealsDataGrid.SelectedItem;
                int dealIdToUpdate = selectedDeal.DealID;
                decimal newDiscountValue = selectedDeal.Discount;

                // Perform the update without comparing old and new values
                UpdateDeal(dealIdToUpdate, newDiscountValue);
                UpdateDealsAudit(dealIdToUpdate, selectedDeal.ProductID, selectedDeal.Discount, selectedDeal.ValidityPeriod, newDiscountValue);

                MessageBox.Show("Deal updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a deal to update.", "No Deal Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Updates the discount value for the specified deal in the Deals table.
        private void UpdateDeal(int dealId, decimal newDiscount)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to update the discount value for a deal
                string query = @"
                    UPDATE Deals
                    SET Discount = @NewDiscount, UpdatedAt = GETDATE()
                    WHERE DealID = @DealID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@NewDiscount", newDiscount);
                command.Parameters.AddWithValue("@DealID", dealId);

                command.ExecuteNonQuery();
            }
        }

        // Updates the DealsAudit table with the changes made to a deal.
        private void UpdateDealsAudit(int dealId, int productId, decimal oldDiscount, DateTime? validityPeriod, decimal newDiscount)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to insert a new record into the DealsAudit table
                string query = @"
                    INSERT INTO DealsAudit (DealID, ProductID, Discount, ValidityPeriod, CreatedAt, UpdatedAt, Active, NewDiscount)
                    VALUES (@DealID, @ProductID, @OldDiscount, @ValidityPeriod, GETDATE(), GETDATE(), 1, @NewDiscount)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DealID", dealId);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@OldDiscount", oldDiscount);
                command.Parameters.AddWithValue("@ValidityPeriod", validityPeriod);
                command.Parameters.AddWithValue("@NewDiscount", newDiscount);

                command.ExecuteNonQuery();
            }
        }
    }
}
