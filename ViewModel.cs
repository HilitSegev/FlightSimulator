using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Microsoft.Win32;



namespace WPF
{
    class ViewModel : INotifyPropertyChanged
    {
        private IModel model;
        private int playbackSpeed;
        public int VM_PlaybackSpeed
        {
            get { return playbackSpeed; }
            set
            {
                playbackSpeed = value;
                model.PlaybackSpeedChanged(playbackSpeed);
            }
        }
        public float VM_Rudder
        {
            get { return model.Rudder; }
        }
        public float VM_Throttle1
        {
            get { return model.Throttle1; }
        }
        public float VM_Throttle2
        {
            get { return model.Throttle2; }
        }
        public float VM_Aileron
        {
            get { return model.Aileron; }
        }
        public float VM_Elevator
        {
            get { return model.Elevator; }
        }
        public float VM_Altitude
        {
            get { return model.Altitude; }
        }
        public float VM_Airspeed
        {
            get { return model.Airspeed; }
        }
        public float VM_HeadingDeg
        {
            get { return model.HeadingDeg; }
        }
        public float VM_Pitch
        {
            get { return model.Pitch; }
        }
        public float VM_Roll
        {
            get { return model.Roll; }
        }
        public float VM_Yaw
        {
            get { return model.Yaw; }
        }

        private int currentRow;
        public int VM_CurrentRow
        {
            get { return model.CurrentRow; }
            set
            {
                model.CurrentRow = value;
            }
        }

        public List<float> VM_PointsSelectedFeature
        {
            get { return model.PointsSelectedFeature; }
        }


        public ViewModel(IModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

            this.playbackSpeed = 100;
            VM_PlaybackSpeed = playbackSpeed;

            this.currentRow = 0;


        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));

            //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        }

        public void VM_sendCSV(OpenFileDialog csvFile)
        {
            model.getCSV(csvFile);
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
