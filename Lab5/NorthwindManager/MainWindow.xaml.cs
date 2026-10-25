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

        // (Step 3): helper method to load all products- sorted by name 
        private void LoadProducts(string search)
        {
            var products = _context.Products
                .Where(p => p.ProductName.Contains(search))
                .OrderBy(p => p.ProductName)
                .ToList();
            ProductsGrid.ItemsSource = products;
        }
        // (Step 5): helper method to load all shippers- sorted by id
        private void LoadShippers()
        {
            var shippers = _context.Shippers
                .OrderBy(s => s.ShipperId)
                .ToList();
            ShippersGrid.ItemsSource = shippers;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // (Step 3): Show all the products, sorted by name.
            // passing empty string - will load all products
            LoadProducts("");

            // (Step 5): Show all the shippers.
            LoadShippers();
        }

        // Products tab

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // (Step 3): Show only the products whose name contains the text in SearchBox.
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
            // (Step 4): Save the price in PriceBox to the selected product.
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
            // (Step 5): Add a new shipper from CompanyBox and PhoneBox.
            if (string.IsNullOrWhiteSpace(CompanyBox.Text))
            {
                MessageBox.Show("Must enter a company name.");
                return;
            }
            _context.Shippers.Add(new Shipper { CompanyName = CompanyBox.Text.Trim(), Phone = PhoneBox.Text.Trim() });
            _context.SaveChanges();
            // after saving to db- clear the text boxes
            CompanyBox.Clear();
            PhoneBox.Clear();
            // call to refresh
            LoadShippers();
        }

        private void DeleteShipperButton_Click(object sender, RoutedEventArgs e)
        {
            // (Step 6): Delete the selected shipper.
            // https://www.learnentityframeworkcore.com/dbcontext/deleting-data
            var shipper = ShippersGrid.SelectedItem as Shipper; // returns null if nothing's selected
            if (shipper == null)
            {
                MessageBox.Show("Must select a Shipper.");
                return;
            }
            _context.Shippers.Remove(shipper);
            try
            {
                _context.SaveChanges();
                LoadShippers();
            } catch (DbUpdateException)
            {
                MessageBox.Show("Failed to remove selected Shipper because it has orders.\nShippers with orders can't be removed.");
                _context.Entry(shipper).State = EntityState.Unchanged;
            }

        }
    }
}
