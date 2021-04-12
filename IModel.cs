using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Microsoft.Win32;
using OxyPlot;

namespace WPF
{
    public interface IModel : INotifyPropertyChanged
    {
        public int CurrentRow { get; set; }
        public Boolean pause { get; set; }

        void connect(string ip, int port);
        void disconnect();
        void start();
        public int getCSV(OpenFileDialog csvFile);
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

        public void SelectedFeatureChanged(int selectedFeatureIndex);
        public void DLLDynamic(dynamic dllDynamic);
        void SelectedAnomalyChanged(int selectedAnomaly);

        float Yaw { set; get; }
        List<DataPoint> PointsSelectedFeature { get; set; }
        int NumOfCSVRows { get; }
        List<DataPoint> PointsCorrelatedFeature { get; set; }
        List<DataPoint> Last30SecPoints { get; set; }
        List<DataPoint> PointsSelectedAndCorrelated { get; set; }
        List<DataPoint> RegressionLinePoints { get; set; }
        List<DataPoint> AnomalyPoints { get; set; }
        List<string> AnomalyIdxList { get; set; }

        public void currentRowChanged(int currentRow);
        public void getCSVDetect(OpenFileDialog csvFileDetect);
    }
}
