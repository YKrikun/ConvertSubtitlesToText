using System;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows;

namespace ConvertSubtitlesToText.MainWindowViewModel
{

    public static class ProccessSubtitlesCommand
    {
        public static RoutedCommand ProccessSubtitles { get; set; }

        static ProccessSubtitlesCommand()
        {
            ProccessSubtitles = new RoutedCommand("Proccess", typeof(MainWindow));
        }

        private static void ProccessSubtitles_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // FlowDocument flow = SubtitlesContent.Document;
            MessageBox.Show("Proccess");
        }
    }


    public static class OpenFileCommand
    {

        public static RoutedCommand OpenFile { get; set; }

        public static string FileName;
        public static FlowDocument SubtitlesContent;

        static OpenFileCommand()
        {
            OpenFile = new RoutedCommand("Open", typeof(MainWindow));
        }

        private static void OpenFileCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            string fileName = GetFileName();

            // Process open file dialog box results
            if (fileName != "")
            {
                // Open document
                FileName = fileName;
                LoadFile(fileName);
            }
        }

        private static string GetFileName()
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

        private static void LoadFile(string FileName)
        {
            var reader = new System.IO.StreamReader(FileName);
            FlowDocument flow = new FlowDocument(new Paragraph(new Run(reader.ReadToEnd())));
            //SubtitlesContent.Document = flow;
        }

    }

}
