using System.Windows.Input;

namespace Calculator.Commands;

public class RelayCommand(Action<object> executeAction, Func<object, bool> canExecute = null) : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
        => canExecute?.Invoke(parameter) ?? true;

    public void Execute(object parameter)
        => executeAction?.Invoke(parameter);
}