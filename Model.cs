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
        double playbackSpeed;
        byte[][] view;

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
            //string line = "";
            //StreamReader sr = new StreamReader(csvFile.FileName);
            //while (line != null)
            //{
            //    line = sr.ReadLine() + '\n';
            //    if (line != null)
            //    {
            //        System.Diagnostics.Debug.WriteLine(line);
            //    }
            //}

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
                    Thread.Sleep(250);// read the data in 4Hz

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
            // API connect
            // API start
        }
        public byte[][] sendView()
        {
            byte[][] view = null;
            return view;
        }

        public void PlaybackSpeedChanged(double PlaybackSpeed)
        {
            this.playbackSpeed = PlaybackSpeed;
        }

    }
}
