using System.Windows.Input;

namespace GradeTracker.Commands;

// The same RelayCommand from class. It's done, so you don't need to change it.
// Hand it a method to run, and optionally a method that says whether it's
// allowed to run right now.
public class RelayCommand : ICommand
{
    private readonly Action execute;
    private readonly Func<bool>? canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => canExecute?.Invoke() ?? true;

    public void Execute(object? parameter) => execute();

    // WPF raises RequerySuggested after user input, so buttons
    // re-ask CanExecute without us having to trigger it.
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
