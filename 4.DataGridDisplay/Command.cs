using System;
using System.Windows.Input;

namespace Dynamics
{
    public class Command : ICommand
    {
        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }

        public bool CanExecute(object parameter) => CanExecuteDelegate == null || CanExecuteDelegate(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter) => ExecuteDelegate?.Invoke(parameter);
    }
}
