using System;
using System.ComponentModel;

namespace ConvertSubtitlesToText
{

    public class ProccessSubtitlesCommand
    {
        public static RoutedCommand ProccessSubtitles { get; set; }

        static ProccessSubtitlesCommand()
        {
            ProccessSubtitles = new RoutedCommand("Proccess", typeof(MainWindow));
        }
    }

}
