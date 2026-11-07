using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChinookMusicApp.Data;

namespace ChinookMusicApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Scaffold command used to generate Models\Generated and Data\Generated
        // from Organizing an EF App slides (with changes for Chinook):
        // Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=Chinook;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models\Generated -ContextDir Data\Generated -Namespace ChinookMusicApp.Models -ContextNamespace ChinookMusicApp.Data -Context ChinookContext -NoOnConfiguring
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}