using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;//1
namespace SimplestMVVMCalc_UWP
{
    class ViewModel : INotifyPropertyChanged
    {           
        #region Объявление переменных
        string _op1, _op2; // переменные для хранения числовых значений
        string _result; // переменная для вывд ответа
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
        //Свойство для первого операнда
        public string Operand1
        {
            set
            {
                _op1 = value;
                CalcCommand.RaiseCanExecuteChanged();
            }
            get { return _op1; }
        }
        //Свойство для второго операнда
        public string Operand2
        {
            set
            {
                _op2 = value;
                CalcCommand.RaiseCanExecuteChanged();
            }
            get { return _op2; }
        }
        //Свойство результата вычислений
        public string Result
        { 
            private set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
            get { return _result; }
        }

        #endregion

        #region Свойства команды

        public RelayCommand CalcCommand { get; set; }

        #endregion

        #region Конструктор класса ViewModel
        public ViewModel()
        {
            CalcCommand = new RelayCommand(CalcCommandExecute, CanExecuteCalcCommand);
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
    }
}