using System.Windows;
using System.Windows.Controls;

namespace GradeTracker;

// This app works, but everything lives in the code-behind: reading the
// TextBoxes, checking the input, keeping the list, turning the Remove button
// on and off, and writing the summary onto the screen.
//
// Your job is to move it to MVVM without changing what the user sees.
//
// TODO Step 5 (View): when you're done, this file should only have the
// constructor with InitializeComponent() in it. Everything else moves to
// the ViewModel or turns into a binding.
public partial class MainWindow : Window
{
    private readonly List<Student> students = new();

    public MainWindow()
    {
        InitializeComponent();
        UpdateSummary();
    }

    private void AddStudent_Click(object sender, RoutedEventArgs e)
    {
        string name = NameTextBox.Text.Trim();

        if (name == string.Empty)
        {
            MessageBox.Show("Please enter a student name.");
            return;
        }

        if (!double.TryParse(GradeTextBox.Text, out double grade))
        {
            MessageBox.Show("Please enter the grade as a number.");
            return;
        }

        if (double.IsNaN(grade) || grade < 0 || grade > 100)
        {
            MessageBox.Show("Grades must be between 0 and 100.");
            return;
        }

        var student = new Student
        {
            Name = name,
            Grade = grade
        };

        students.Add(student);
        StudentsListBox.Items.Add(student);

        NameTextBox.Text = string.Empty;
        GradeTextBox.Text = string.Empty;
        UpdateSummary();
    }

    private void RemoveStudent_Click(object sender, RoutedEventArgs e)
    {
        if (StudentsListBox.SelectedItem is Student student)
        {
            students.Remove(student);
            StudentsListBox.Items.Remove(student);
            UpdateSummary();
        }
    }

    // Remove only makes sense when someone is selected.
    private void StudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        RemoveButton.IsEnabled = StudentsListBox.SelectedItem != null;
    }

    private void UpdateSummary()
    {
        CountTextBlock.Text = students.Count.ToString();

        // Average, Max and Min all throw on an empty list.
        if (students.Count == 0)
        {
            AverageTextBlock.Text = "0.0";
            HighestTextBlock.Text = "0.0";
            LowestTextBlock.Text = "0.0";
            TopStudentTextBlock.Text = "None yet";
            return;
        }

        AverageTextBlock.Text = students.Average(s => s.Grade).ToString("0.0");
        HighestTextBlock.Text = students.Max(s => s.Grade).ToString("0.0");
        LowestTextBlock.Text = students.Min(s => s.Grade).ToString("0.0");

        // If two students tie for the top grade, the first one added wins.
        TopStudentTextBlock.Text = students.MaxBy(s => s.Grade)!.Name;
    }
}

// TODO Step 1 (Model): move this class into its own file in a Models folder,
// with a namespace to match. Nothing about the class itself needs to change.
public class Student
{
    public string Name { get; set; } = "";
    public double Grade { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Grade:0.#})";
    }
}
