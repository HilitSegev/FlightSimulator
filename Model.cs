using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace WPF
{
    class Model : IModel
    {
        private OpenFileDialog csvFile;
        ITelnetClient telnetClient;
        volatile Boolean stop;
        int playbackSpeed;

        public event PropertyChangedEventHandler PropertyChanged;

        public Model(ITelnetClient telnetClient)
        {
            this.telnetClient = telnetClient;
            stop = false;
        }

        public void connect(string ip, int port)
        {
            telnetClient.connect(ip, port);
        }
        public void disconnect()
        {
            stop = true;
            telnetClient.disconnect();
        }
        public void start()
        {
            // open client connection
            telnetClient.connect("localhost", 5400);

            // populate line
            StreamReader sr = new StreamReader(csvFile.FileName);
            string line = sr.ReadLine() + '\n';

            new Thread(delegate ()
            {
                while (line != null)
                {
                    telnetClient.write(line);
                    Thread.Sleep(playbackSpeed);// read the data in 4Hz

                    // TODO: Remove
                    System.Diagnostics.Debug.WriteLine("playbackSpeed: {0}", playbackSpeed);

                    // read new line
                    line = sr.ReadLine() + '\n';
                }
            }).Start();

        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void getCSV(OpenFileDialog csvFile)
        {
            this.csvFile = csvFile;
            start();
        }

        public void PlaybackSpeedChanged(int PlaybackSpeed)
        {
            this.playbackSpeed = PlaybackSpeed;
        }

    }
}
