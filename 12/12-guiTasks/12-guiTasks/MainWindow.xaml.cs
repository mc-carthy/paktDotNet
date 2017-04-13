using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace _12_guiTasks
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

        private void GetProductsButton_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(
              @"Data Source=(localdb)\mssqllocaldb;" +
              "Initial Catalog=Northwind;Integrated Security=true;");

            connection.Open();

            var getProducts = new SqlCommand(
              "WAITFOR DELAY '00:00:05';" +
              "SELECT ProductID, ProductName, UnitPrice FROM Products",
              connection);

            SqlDataReader reader = getProducts.ExecuteReader();

            int indexOfID = reader.GetOrdinal("ProductID");
            int indexOfName = reader.GetOrdinal("ProductName");
            int indexOfPrice = reader.GetOrdinal("UnitPrice");

            while (reader.Read())
            {
                ProductsListBox.Items.Add(
                  string.Format("{0}: {1} costs {2:c}",
                  reader.GetInt32(indexOfID),
                  reader.GetString(indexOfName),
                  reader.GetDecimal(indexOfPrice)));
            }
            reader.Dispose();
            connection.Dispose();
        }
    }
}
