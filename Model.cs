﻿using System;
using System.Collections;
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
        List<String> rowsList;


        ITelnetClient telnetClient;
        volatile Boolean stop;
        public Boolean pause { get; set; }
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
        private int playbackSpeed;
        private float rudder;
        private float throttle1;
        private float throttle2;
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

        public float Throttle1
        {
            get { return throttle1; }
            set
            {
                throttle1 = value;
                OnPropertyChanged();
            }
        }

        public float Throttle2
        {
            get { return throttle2; }
            set
            {
                throttle2 = value;
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
        public int getAttributeIdx(string att, XmlNodeList attributeList, int appearance)
        {
            int appear = 0;
            for (int i = 0; i < attributeList.Count; i++)
            {
                if (attributeList[i].InnerText == att)
                {
                    appear++;
                    if (appearance == appear)
                    {
                        return i;
                    }
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

                    string[] parsedLine = parseLine(rowsList[currentRow]);

                    if (parsedLine.Length > 1)
                    {
                        Rudder = float.Parse(parsedLine[getAttributeIdx("rudder", parse, 1)]);
                        Throttle1 = float.Parse(parsedLine[getAttributeIdx("throttle", parse, 1)]);
                        Throttle2 = float.Parse(parsedLine[getAttributeIdx("throttle", parse, 2)]);
                        Aileron = float.Parse(parsedLine[getAttributeIdx("aileron", parse, 1)]);
                        Elevator = float.Parse(parsedLine[getAttributeIdx("elevator", parse, 1)]);
                    }


                    // TODO: Remove
                    System.Diagnostics.Debug.WriteLine("playbackSpeed: {0}", playbackSpeed);

                    // read new line
                    CurrentRow++;

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
