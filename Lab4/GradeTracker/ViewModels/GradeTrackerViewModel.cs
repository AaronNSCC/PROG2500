using System.Collections.ObjectModel;
using System.ComponentModel;
using GradeTracker.Models;

namespace GradeTracker.ViewModels;

// Everything the screen needs, with no reference to the screen.
// When you're done, nothing in this file should mention a TextBox, a ListBox,
// a Button, or a MessageBox.
public class GradeTrackerViewModel : INotifyPropertyChanged
{
    // Step 2 (Inputs): add a property for each box the user types into. = (Name and Grade)
    // Each one announces itself when it changes. = (OnPropertyChanged)
    // Think about what type the grade should be while the user is still typing it. = (String) it'll change to a number when it's used.

    // NAME
    private string name = "";
    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    // GRADE
    private string gradeText = "";
    public string GradeText
    {
        get => gradeText;
        set
        {
            gradeText = value;
            OnPropertyChanged(nameof(GradeText));
        }
    }

    // Step 3 (List and summary): add the list of students, and a property
    // for the selected student. Then add the five summary values as calculated
    // properties. They should never crash, even before anyone's been added,
    // and the screen needs to hear about them whenever the list changes.

    // list of students + property for selected student
    public ObservableCollection<Student> Students { get; } = new();
    private Student? selectedStudent;
    public Student? SelectedStudent
    {
        get => selectedStudent;
        set
        {
            selectedStudent = value;
            OnPropertyChanged(nameof(SelectedStudent));
        }
    }
    // 5 summary values: TopStudent, NumberOfStudents, ClassAverage, HighestGrade, LowestGrade
    public int NumberOfStudents => Students.Count;
    public string TopStudent => Students.Count == 0 ? "None yet" : Students.MaxBy(st => st.Grade)!.Name;
    public double ClassAverage => Students.Count == 0 ? 0 : Students.Average(st => st.Grade);
    public double HighestGrade => Students.Count == 0 ? 0 : Students.Max(st => st.Grade);
    public double LowestGrade => Students.Count == 0 ? 0 : Students.Min(st => st.Grade);

    public GradeTrackerViewModel()
    {
        Students.CollectionChanged += (sender, e) => OnTotalsChanged();
    }
    private void OnTotalsChanged()
    {
        OnPropertyChanged(nameof(NumberOfStudents));
        OnPropertyChanged(nameof(TopStudent));
        OnPropertyChanged(nameof(ClassAverage));
        OnPropertyChanged(nameof(HighestGrade));
        OnPropertyChanged(nameof(LowestGrade));
    }


    // TODO Step 4 (Commands and the message): add a command for Add and one for
    // Remove, using the RelayCommand in the Commands folder. The MessageBox checks
    // become two things: a CanExecute rule for Add, and a message the screen can
    // show explaining what's wrong. Write the checks once and use them for both,
    // so the button and the message can never disagree.
    // Remove's "only when someone's selected" rule is a CanExecute too.

    // Change notification. This part is done.
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
