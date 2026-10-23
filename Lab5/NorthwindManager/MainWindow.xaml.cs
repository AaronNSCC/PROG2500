using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace NorthwindManager
{
    public partial class MainWindow : Window
    {
        // TODO (Step 3): After you scaffold, add "using NorthwindManager.Models;" at the top
        // and give the window one NorthwindContext to use everywhere.

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO (Step 3): Show all the products, sorted by name.
            // TODO (Step 5): Show all the shippers.
        }

        // Products tab

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO (Step 3): Show only the products whose name contains the text in SearchBox.
            // A blank search shows them all again.
        }

        private void ProductsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO (Step 4): Put the selected product's price in PriceBox.
        }

        private void SavePriceButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO (Step 4): Save the price in PriceBox to the selected product.
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
