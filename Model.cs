﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Microsoft.Win32;
using OxyPlot;
using static WPF.Utilities;
namespace WPF
{
    class Model : IModel
    {
        private OpenFileDialog csvFile;
        TimeSeries rowsList;

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
        private int selectedFeatureIndex;
        private float rudder;
        private float throttle1;
        private float throttle2;
        private float aileron;
        private float elevator;
        private float altitude;
        private float airspeed;
        private float headingDeg;
        private float pitch;
        private float roll;
        private float yaw;
        private List<String> listOfFeatureNames;
        private List<DataPoint> pointsSelectedFeature;


        public List<String> ListOfFeatureNames
        {
            get { return listOfFeatureNames; }
            set
            {
                listOfFeatureNames = value;
                OnPropertyChanged();
            }
        }

        public List<DataPoint> PointsSelectedFeature
        {
            get { return pointsSelectedFeature; }
            set
            {
                pointsSelectedFeature = value;
                
            }
        }

        private int numOfCSVRows = 2000;
        public int NumOfCSVRows
        {
            get { return numOfCSVRows; }
            set
            {
                numOfCSVRows = value;
                OnPropertyChanged();
            }
        }

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
        public float Altitude
        {
            get { return altitude; }
            set
            {
                altitude = value;
                OnPropertyChanged();
            }
        }
        public float Airspeed
        {
            get { return airspeed; }
            set
            {
                airspeed = value;
                OnPropertyChanged();
            }
        }
        public float HeadingDeg
        {
            get { return headingDeg; }
            set
            {
                headingDeg = value;
                OnPropertyChanged();
            }
        }
        public float Pitch
        {
            get { return pitch; }
            set
            {
                pitch = value;
                OnPropertyChanged();
            }
        }
        public float Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                OnPropertyChanged();
            }
        }
        public float Yaw
        {
            get { return yaw; }
            set
            {
                yaw = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Model(ITelnetClient telnetClient)
        {
            this.telnetClient = telnetClient;
            stop = false;
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
            return line.Replace("\n", "").Split(',');
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
            XmlNodeList parsedXML = parseXML("playback_small.xml");

            PointsSelectedFeature = new List<DataPoint>();
            
            // open client connection
            telnetClient.connect("localhost", 5400);

            // lastSelectedFeatureIndex to clean the plot
            int lastSelectedFeatureIndex = selectedFeatureIndex;
            int startOfPlotIndex = 0;
            new Thread(delegate ()
            {
                while ((!stop) && (currentRow < rowsList.getNumOfRows()))
                {
                    while (pause)
                    {
                        continue;
                    }
                    telnetClient.write(rowsList.printRow(currentRow));
                    Thread.Sleep(playbackSpeed);

                    string[] parsedLine = parseLine(rowsList.printRow(currentRow));

                    if (parsedLine.Length > 1)
                    {
                        Rudder = float.Parse(parsedLine[getAttributeIdx("rudder", parsedXML, 1)]);
                        Throttle1 = float.Parse(parsedLine[getAttributeIdx("throttle", parsedXML, 1)]);
                        Throttle2 = float.Parse(parsedLine[getAttributeIdx("throttle", parsedXML, 2)]);
                        Aileron = 125 + (75 * float.Parse(parsedLine[getAttributeIdx("aileron", parsedXML, 1)]));
                        Elevator = 125 + (75 * float.Parse(parsedLine[getAttributeIdx("elevator", parsedXML, 1)]));
                        Altitude = float.Parse(parsedLine[getAttributeIdx("altitude-ft", parsedXML, 1)]);
                        Airspeed = float.Parse(parsedLine[getAttributeIdx("airspeed-kt", parsedXML, 1)]);
                        HeadingDeg = float.Parse(parsedLine[getAttributeIdx("heading-deg", parsedXML, 1)]);
                        Pitch = float.Parse(parsedLine[getAttributeIdx("pitch-deg", parsedXML, 1)]);
                        Roll = float.Parse(parsedLine[getAttributeIdx("roll-deg", parsedXML, 1)]);
                        Yaw = float.Parse(parsedLine[getAttributeIdx("side-slip-deg", parsedXML, 1)]);
                    }

                    // identify change in selected feature
                    if (lastSelectedFeatureIndex != selectedFeatureIndex)
                    {
                        startOfPlotIndex = currentRow;
                        PointsSelectedFeature = new List<DataPoint>();
                        lastSelectedFeatureIndex = selectedFeatureIndex;
                    }

                    PointsSelectedFeature.Add(new DataPoint(currentRow, float.Parse(parsedLine[selectedFeatureIndex])));
                    OnPropertyChanged("PointsSelectedFeature");
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

        public int getCSV(OpenFileDialog csvFile)
        {
            this.csvFile = csvFile;
            this.rowsList = new TimeSeries(csvFile.FileName);

            
            start();
            return rowsList.getNumOfRows();
        }

        public void PlaybackSpeedChanged(int PlaybackSpeed)
        {
            this.playbackSpeed = PlaybackSpeed;
        }

        public void currentRowChanged(int currentRow)
        {
            this.currentRow = currentRow;
        }

        public void SelectedFeatureChanged(int selectedFeatureIndex)
        {
            this.selectedFeatureIndex = selectedFeatureIndex;
        }
    }
}
