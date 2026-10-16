using System.Windows;
using System.Windows.Controls;
using GradeTracker.Models;

namespace GradeTracker;

// This app works, but everything lives in the code-behind: reading the
// TextBoxes, checking the input, keeping the list, turning the Remove button
// on and off, and writing the summary onto the screen.
//
// Your job is to move it to MVVM without changing what the user sees.
//
// Step 5 (View): when you're done, this file should only have the
// constructor with InitializeComponent() in it. Everything else moves to
// the ViewModel or turns into a binding.
public partial class MainWindow : Window
{
    private readonly List<Student> students = new();

    public MainWindow()
    {
        InitializeComponent();
    }

}

