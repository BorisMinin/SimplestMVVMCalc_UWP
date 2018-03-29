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
        string op1;
        string op2;
        string result;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
