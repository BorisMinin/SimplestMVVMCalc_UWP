using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimplestMVVMCalc_UWP.Common
{
    public class RelayCommand : ICommand
    {
        #region Поля класса RelayCommand
        private Action<object> _execute;
        private Func<bool> _canExecute;
        #endregion

        #region Конструкторы класса RelayCommand
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        public RelayCommand(Action<object> execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region Реализация интерфейса
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return (bool)((_canExecute == null) ? true : _canExecute());
        }

        public void Execute(object parametr)
        {
            _execute(parametr);
        }
        #endregion
    }
}