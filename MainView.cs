using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Advent2015
{
    internal class MainView : INotifyPropertyChanged
    {
        public string _OutText;
        public string OutText
        {
            get
            {
                return _OutText;
            }
            set
            {
                if (value == _OutText)
                    return;
                _OutText = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}