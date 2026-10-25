using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NorthwindManager.Models;

namespace NorthwindManager
{
    public partial class MainWindow : Window
    {
        // (Step 3): After you scaffold, add "using NorthwindManager.Models;" at the top
        // and give the window one NorthwindContext to use everywhere.
        private readonly NorthwindContext _context = new NorthwindContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        // helper method to load all products- sorted by name 
        private void LoadProducts(string search)
        {
            var products = _context.Products
                .Where(p => p.ProductName.Contains(search))
                .OrderBy(p => p.ProductName)
                .ToList();
            ProductsGrid.ItemsSource = products;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // (Step 3): Show all the products, sorted by name.
            // passing empty string - will load all products
            LoadProducts("");

            // TODO (Step 5): Show all the shippers.
        }

        // Products tab

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO (Step 3): Show only the products whose name contains the text in SearchBox.
            // A blank search shows them all again.
            LoadProducts(SearchBox.Text.Trim());
        }

        private void ProductsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // (Step 4): Put the selected product's price in PriceBox.
            var product = ProductsGrid.SelectedItem as Product; // returns null if nothing's selected
            if (product != null) 
            {
                PriceBox.Text = product.UnitPrice?.ToString("0.00"); 
            } else
            {
                PriceBox.Clear();
            }
            
        }

        private void SavePriceButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO (Step 4): Save the price in PriceBox to the selected product.
            var product = ProductsGrid.SelectedItem as Product; // returns null if nothing's selected
            bool validPrice = decimal.TryParse(PriceBox.Text, out decimal setPrice);
            if (product == null)
            {
                MessageBox.Show("Must select a product to set its price.");
                return;
            }
            else if (!validPrice || setPrice < 0)
            {
                MessageBox.Show("Must enter a valid price. 0 or higher.");
                return;
            }

            product.UnitPrice = setPrice;   // set price
            _context.SaveChanges();         // save in DB: https://learn.microsoft.com/en-us/ef/core/saving/basic
            ProductsGrid.Items.Refresh();   // refresh grid
        }

        // Shippers tab

        private void AddShipperButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO (Step 5): Add a new shipper from CompanyBox and PhoneBox.
        }

        private void DeleteShipperButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO (Step 6): Delete the selected shipper.
        }
    }
}
