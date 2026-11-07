using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChinookMusicApp.ViewModels;

// reusable command for buttons and menu items (from MVVM Part 2 - Commands slides)
public class RelayCommand : ICommand
{
    private readonly Action execute;
    private readonly Func<bool>? canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? p) =>
        canExecute?.Invoke() ?? true;
    public void Execute(object? p) => execute();

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}