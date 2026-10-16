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
            DataContext = summary;

            // start the date picker on today's date
            ActivityDatePicker.SelectedDate = DateTime.Today;
        }

        private void SetGoalsButton_Click(object sender, RoutedEventArgs e)
        {
            // goal boxes use UpdateSourceTrigger=Explicit - send their values to the binding on btn click
            // https://learn.microsoft.com/en-us/dotnet/api/system.windows.data.bindingoperations.getbindingexpression?view=windowsdesktop-10.0
            MinutesGoalTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            CaloriesGoalTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void AddActivityButton_Click(object sender, RoutedEventArgs e)
        {
            // try parsing int values (must be greater than 0) - textbox is passing a string
            if (!int.TryParse(ActivityMinutesTextBox.Text, out int minutes) || minutes <= 0 ||
                !int.TryParse(ActivityCaloriesTextBox.Text, out int calories) || calories <= 0)
            {
                MessageBox.Show("Minutes and calories must be whole numbers greater than 0.", "Invalid number");
                return;
            }

            Activity activity = new Activity
            {
                Name = ActivityNameTextBox.Text.Trim(),
                Minutes = minutes,
                Calories = calories,
                Date = ActivityDatePicker.SelectedDate!.Value
            };

            // cast DataContext to FitnessSummary so it reaches the Activities list
            ((FitnessSummary)DataContext).Activities.Add(activity);

            // reset the form values for the next activity to be entered
            ActivityNameTextBox.Clear();
            ActivityMinutesTextBox.Clear();
            ActivityCaloriesTextBox.Clear();
            ActivityDatePicker.SelectedDate = DateTime.Today;
        }

        private void RemoveActivityButton_Click(object sender, RoutedEventArgs e)
        {
            // remove the selected activity - ActivitiesCollectionChanged in FitnessSummary will update the summary totals
            if (ActivitiesListView.SelectedItem is Activity activity)
            {
                ((FitnessSummary)DataContext).Activities.Remove(activity);
            }
        }
    }
}