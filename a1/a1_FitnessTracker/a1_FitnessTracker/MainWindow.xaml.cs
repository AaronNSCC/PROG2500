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
using a1_FitnessTracker.Models;

namespace a1_FitnessTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // create data object
            FitnessSummary summary = new FitnessSummary();
            // create fake activity (for now) - delete when Add activity works
            summary.Activities.Add(new Activity { Name = "Test 1", Minutes = 35, Calories = 220, Date = DateTime.Today});
            DataContext = summary;
        }

        private void SetGoalsButton_Click(object sender, RoutedEventArgs e)
        {
            // goal boxes use UpdateSourceTrigger=Explicit - send their values to the binding on btn click
            // https://learn.microsoft.com/en-us/dotnet/api/system.windows.data.bindingoperations.getbindingexpression?view=windowsdesktop-10.0
            MinutesGoalTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            CaloriesGoalTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}