using System;
using System.Collections;
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
        List<String> rowsList;


        ITelnetClient telnetClient;
        volatile Boolean stop;
        public Boolean pause { get; set; }
        int playbackSpeed;
        int currentRow;
        public int CurrentRow
        {
            get { return currentRow; }
            set
            {
                currentRow = value;
                NotifyPropertyChanged("CurrentRow");
            }
        }

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

            new Thread(delegate ()
            {
                while ((!stop) && (currentRow < rowsList.Count))
                {
                    while (pause)
                    {
                        continue;
                    }
                    telnetClient.write(rowsList[currentRow]);
                    Thread.Sleep(playbackSpeed);
                    CurrentRow++;

                    // TODO: Remove
                    System.Diagnostics.Debug.WriteLine("playbackSpeed: {0}", playbackSpeed);

                    // read new line
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
            this.rowsList = new List<string>();

            // populate line
            StreamReader sr = new StreamReader(csvFile.FileName);

            // keep reading from file and send to server
            string line = sr.ReadLine();

            while (line != null)
            {
                rowsList.Add(line+'\n');

                // read new line
                line = sr.ReadLine();
            }
            start();
        }

        public void PlaybackSpeedChanged(int PlaybackSpeed)
        {
            this.playbackSpeed = PlaybackSpeed;
        }

        public void currentRowChanged(int currentRow)
        {
            this.currentRow = currentRow;
        }

    }
}
