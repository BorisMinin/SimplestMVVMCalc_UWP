using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
//1

namespace SimplestMVVMCalc_UWP
{
    class ViewModel : INotifyPropertyChanged
    {
           
        #region Объявление переменных
        string _op1; // переменная для хранения первого операнда
        string _op2; // переменная для хранения второго операнда
        string _result; // переменная для вывд ответа
        #endregion

        #region Свойства команды
        public RelayCommand CalcCommand { get; }
        #endregion

        #region Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Свойства привязки
        public string Operand1
        {
            get { return _op1; }
            set
            {
                _op1 = value;
                CalcCommand.RaiseCanExecuteChanged();
            }
        }
        public string Operand2
        {
            get { return _op2; }
            set
            {
                _op2 = value;
                CalcCommand.RaiseCanExecuteChanged();
            }
        }
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }


        #endregion

        #region Логика команды
        public void CalcCommandExecute(object parametr)
        {
            switch (parametr)
            {
                case "+":
                    Result = (Double.Parse(_op1) + Double.Parse(_op2)).ToString();
                    break;
                case "-":
                    Result = (Double.Parse(_op1) - Double.Parse(_op2)).ToString();
                    break;
                case "*":
                    Result = (Double.Parse(_op1) * Double.Parse(_op2)).ToString();
                    break;
                case "/":
                    Result = (Double.Parse(_op1) / Double.Parse(_op2)).ToString();
                    break;
            }
        }
        public bool CanExecuteCalcCommand()
        {
            if (String.IsNullOrEmpty(_op1) || String.IsNullOrEmpty(_op2))
                return false;
            else
                return true;
        }
        #endregion

        #region Конструктор класса ViewModel
        public ViewModel()
        {
            CalcCommand = new RelayCommand(CalcCommandExecute, CanExecuteCalcCommand);
        }
        #endregion
    }
}