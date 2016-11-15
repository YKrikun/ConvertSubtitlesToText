using System;
using System.ComponentModel;

namespace ConvertSubtitlesToText
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public DelegateCommand ProccessTextCommand { get; set; }

        protected MainWindowViewModel()
        {
        }
    }

}
