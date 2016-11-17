using System;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;

namespace ConvertSubtitlesToText
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public DelegateCommand OpenFileCommand { get; set; }
        public DelegateCommand ProccessFileCommand { get; set; }

        private string _subtitlesFileName;
        public string SubtitlesFileName
        {
            get
            {
                return _subtitlesFileName;
            }
            set
            {
                _subtitlesFileName = value;
                NotifyPropertyChanged("SubtitlesFileName");
            }
        }

        private string _documentText;
        public string DocumentText
        {
            get 
            { 
                return _documentText;
            }
            set 
            {
                _documentText = value;
                NotifyPropertyChanged("DocumentText");
            }
        }

        private string _proccessText;
        public string ProccessText
        {
            get 
            { 
                return _proccessText;
            }
            set 
            {
                _proccessText = value;
                NotifyPropertyChanged("ProccessText");
            }
        }

        public MainWindowViewModel()
        {
            OpenFileCommand = new DelegateCommand(OpenFile);
            ProccessFileCommand = new DelegateCommand(ProccessFile);
        }

        private void ProccessFile()
        {

            string[] separator = { Environment.NewLine };
            string[] strArray = _documentText.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            int count = 1;
            int length = strArray.Length; 
            int operation = 1;
            string proccessText = "";

            while (i<length)
	        {
                switch (operation)
                {
                    case 1: { i++; operation++; break; }
                    case 2: { i++; operation++; count++; break; }
                    case 3:
                    { 
                        string str = strArray[i];
                        int istr;
                        if (Int32.TryParse(str, out istr) & (count == istr))
                        {
                            operation = 1;
                        }
                        else
                        {
                            proccessText = proccessText + str + " ";
                            char endOfLine = str[str.Length - 1];
                            string end = Char.ToString(endOfLine);
                            if (end == "." || end == "?" || end == "!")
                                proccessText = proccessText + "\n";
                            i++;
                        }
                        break;
                    }
                }
                
	        }
            ProccessText = proccessText;

        }
        private void OpenFile()
        {
            string fileName = GetFileName();

            if (fileName != "")
            {
                LoadFile(fileName);
                SubtitlesFileName = fileName;
            }
        }

        private string GetFileName()
        {
            string fileName = "";

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Subtitles"; // Default file name
            dlg.DefaultExt = ".srt"; // Default file extension
            dlg.Filter = "Файл субтитров (.srt)|*.srt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                fileName = dlg.FileName;
            }
            return fileName;
        }

        private void LoadFile(string FileName)
        {
            var reader = new System.IO.StreamReader(FileName);
            DocumentText = reader.ReadToEnd();
            FlowDocument flow = new FlowDocument(new Paragraph(new Run(DocumentText)));
            //SubtitlesContent.Document = flow;
        }

        #region События / Events
        /// <summary>
        /// Событие изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Методы / Methods
        /// <summary>
        /// Метод отпарвки уведомления об изменении свойства
        /// </summary>
        /// <param name="propertyName">Название свойства</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
