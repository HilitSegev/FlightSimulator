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
        float Rudder { set; get; }
        float Throttle1 { set; get; }
        float Throttle2 { set; get; }
        float Aileron { set; get; }
        float Elevator { set; get; }
        float Altitude { set; get; }
        float Airspeed { set; get; }
        float HeadingDeg { set; get; }
        float Pitch { set; get; }
        float Roll { set; get; }
        float Yaw { set; get; }

        public void currentRowChanged(int currentRow);

    }
}
