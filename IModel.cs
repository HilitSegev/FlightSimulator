using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Microsoft.Win32;

namespace WPF
{
    interface IModel : INotifyPropertyChanged
    {
        void connect(string ip, int port);
        void disconnect();
        void start();
        public void getCSV(OpenFileDialog csvFile);
        public void PlaybackSpeedChanged(int PlaybackSpeed);

    }
}
