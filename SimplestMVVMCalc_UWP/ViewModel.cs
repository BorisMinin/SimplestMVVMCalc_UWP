using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SimplestMVVMCalc_UWP
{
    class ViewModel : INotifyPropertyChanged
    {
           
        #region Объявление переменных
        string op1; // переменная для хранения первого операнда
        string op2; // переменная для хранения второго операнда
        string result; // переменная для вывд ответа
        #endregion

        #region Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}
        #endregion

        #region Свойства команды

        #endregion

        #region Конструктор класса ViewModel
        public ViewModel()
        {
            
        }
        #endregion

    }
}
