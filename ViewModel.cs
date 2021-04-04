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
        public float VM_Throttle
        {
            get { return model.Throttle; }
        }
        public float VM_Aileron
        {
            get { return model.Aileron; }
        }
        public float VM_Elevator
        {
            get { return model.Elevator; }
        }

        public ViewModel(IModel model)
        {
            this.model = model;
            this.playbackSpeed = 100;
            VM_PlaybackSpeed = playbackSpeed;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void VM_sendCSV(OpenFileDialog csvFile)
        {
            model.getCSV(csvFile);
        }
    }
}
