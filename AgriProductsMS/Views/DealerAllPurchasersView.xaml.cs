using AgriProductsManagementSystem.Models;
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
using System.Data.SqlClient;

namespace AgriProductsManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for DealerAllPurchasersView.xaml
    /// </summary>
    public partial class DealerAllPurchasersView : UserControl
    {
        public DealerAllPurchasersView()
        {
            InitializeComponent();
            Loaded += DealerDealsView_Loaded;
        }

        private void DealerDealsView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPurchasersData();
        }

        private void LoadPurchasersData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT 
                p.PurchaserID, 
                p.Email,
                p.FirstName,
                p.LastName,
                p.LoansApplied
            FROM 
                Purchasers p";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Purchaser> dataList = new List<Purchaser>();

                    while (reader.Read())
                    {
                        Purchaser purchaser = new Purchaser
                        {
                            PurchaserID = reader.GetInt32(reader.GetOrdinal("PurchaserID")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            LoansApplied = reader.GetInt32(reader.GetOrdinal("LoansApplied"))
                        };

                        dataList.Add(purchaser);
                    }

                    viewPurchasersDataGrid.ItemsSource = dataList;
                }
            }
        }

    }
}
