using System.ComponentModel;

namespace GradeTracker.ViewModels;

// Everything the screen needs, with no reference to the screen.
// When you're done, nothing in this file should mention a TextBox, a ListBox,
// a Button, or a MessageBox.
public class GradeTrackerViewModel : INotifyPropertyChanged
{
    // TODO Step 2 (Inputs): add a property for each box the user types into.
    // Each one announces itself when it changes.
    // Think about what type the grade should be while the user is still typing it.

    // TODO Step 3 (List and summary): add the list of students, and a property
    // for the selected student. Then add the five summary values as calculated
    // properties. They should never crash, even before anyone's been added,
    // and the screen needs to hear about them whenever the list changes.

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
