using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Microsoft.Win32;

namespace WPF
{
    interface IModel : INotifyPropertyChanged
    {
        public int CurrentRow { get; set; }
        public Boolean pause { get; set; }

        void connect(string ip, int port);
        void disconnect();
        void start();
        public void getCSV(OpenFileDialog csvFile);
        public void PlaybackSpeedChanged(int PlaybackSpeed);

        public void currentRowChanged(int currentRow);

    }
}
