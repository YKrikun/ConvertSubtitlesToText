using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConvertSubtitlesToText
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //MessageBox.Show("Команда запущена из "+e.Source.ToString());
            string fileName = GetFileName();

            // Process open file dialog box results
            if (fileName != "")
            {
                // Open document
                FileName.Text = fileName;
                LoadFile(fileName);
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

        private void ButtonProccess_Click(object sender, RoutedEventArgs e)
        {

            FlowDocument flow = SubtitlesContent.Document;

        }

        private void LoadFile(string FileName)
        {
            var reader = new System.IO.StreamReader(FileName);
            FlowDocument flow = new FlowDocument(new Paragraph(new Run(reader.ReadToEnd())));
            SubtitlesContent.Document = flow;
        }
    }
}
