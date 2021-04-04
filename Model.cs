using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml;
using Microsoft.Win32;

namespace WPF
{
    class Model : IModel
    {
        private OpenFileDialog csvFile;
        ITelnetClient telnetClient;
        volatile Boolean stop;
        private int playbackSpeed;
        private float rudder;
        private float throttle;
        private float aileron;
        private float elevator;

        public float Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                OnPropertyChanged();
            }
        }

        public float Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                OnPropertyChanged();
            }
        }

        public float Aileron
        {
            get { return aileron; }
            set
            {
                aileron = value;
                OnPropertyChanged();
            }
        }
        public float Elevator
        {
            get { return elevator; }
            set
            {
                elevator = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Model(ITelnetClient telnetClient)
        {
            this.telnetClient = telnetClient;
            stop = false;
        }

        public XmlNodeList parseXML(string filePath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            XmlNodeList names = xml.GetElementsByTagName("name");

            return names;
        }

        // get attribute index
        public int getAttributeIdx(string att, XmlNodeList attributeList)
        {
            for (int i = 0; i < attributeList.Count; i++)
            {
                if (attributeList[i].InnerText == att)
                {
                    return i;
                }
            }

            return -1;
        }

        // split csv line by ","
        public string[] parseLine(string line)
        {
            return line.Split(',');
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
            // testing xmlParser
            XmlNodeList parse = parseXML("playback_small.xml");

            // open client connection
            telnetClient.connect("localhost", 5400);

            // populate line
            StreamReader sr = new StreamReader(csvFile.FileName);
            string line = sr.ReadLine() + '\n';

            new Thread(delegate ()
            {
                while (line != null)
                {
                    string[] parsedLine = parseLine(line);
                    Rudder = float.Parse(parsedLine[getAttributeIdx("rudder", parse)]);
                    Throttle = float.Parse(parsedLine[getAttributeIdx("throttle", parse)]);
                    Aileron = float.Parse(parsedLine[getAttributeIdx("aileron", parse)]);
                    Elevator = float.Parse(parsedLine[getAttributeIdx("elevator", parse)]);

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
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
