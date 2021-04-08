using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Microsoft.Win32;
using OxyPlot;

namespace WPF
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IModel model;
        private int currentRow;
        //private int playbackSpeed;
        private int selectedFeatureIndex;
        //public int VM_PlaybackSpeed
        //{
        //    get { return playbackSpeed; }
        //    set
        //    {
        //        playbackSpeed = value;
        //        model.PlaybackSpeedChanged(playbackSpeed);
        //    }
        //}

        public int VM_SelectedFeatureIndex
        {
            get { return selectedFeatureIndex; }
            set
            {
                selectedFeatureIndex = value;
                model.SelectedFeatureChanged(selectedFeatureIndex);
            }
        }

        public int VM_CurrentRow
        {
            get { return model.CurrentRow; }
            set
            {
                model.CurrentRow = value;
                model.PointsSelectedFeature = new List<DataPoint>();
            }
        }
        public List<DataPoint> VM_PointsSelectedFeature
        {
            get
            {
                invalidateFlag++;
                NotifyPropertyChanged("VM_InvalidateFlag");
                return model.PointsSelectedFeature;
            }
        }
        private int invalidateFlag;
        private int numOfCSVRows;

        public int VM_InvalidateFlag
        {
            get
            {
                return invalidateFlag;
            }
        }

        //public float VM_Rudder
        //{
        //    get { return model.Rudder; }
        //}
        //public float VM_Throttle1
        //{
        //    get { return model.Throttle1; }
        //}
        //public float VM_Throttle2
        //{
        //    get { return model.Throttle2; }
        //}
        //public float VM_Aileron
        //{
        //    get { return model.Aileron; }
        //}
        //public float VM_Elevator
        //{
        //    get { return model.Elevator; }
        //}

        public int VM_NumOfCSVRows
        {
            get
            {
                return numOfCSVRows;
            }
            set
            {
                numOfCSVRows = value;
                NotifyPropertyChanged("VM_NumOfCSVRows");
            }
        }

        public ViewModel(IModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

            //this.playbackSpeed = 100;
            //VM_PlaybackSpeed = playbackSpeed;

            this.currentRow = 0;


        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));

            //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        }
        public void VM_sendCSV(OpenFileDialog csvFile)
        {
            VM_NumOfCSVRows = model.getCSV(csvFile);

        }
        public void VM_playButtonClick()
        {
            model.pause = false;
        }
        public void VM_pauseButtonClick()
        {
            model.pause = true;
        }
        public void VM_stopButtonClick()
        {
            model.pause = true;
            model.CurrentRow = 0;
        }
    }
}
