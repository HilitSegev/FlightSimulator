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
        byte[][] VM_view;
        private double playbackSpeed;
        public double VM_PlaybackSpeed
        {
            get { return playbackSpeed; }
            set
            {
                playbackSpeed = value;
                model.PlaybackSpeedChanged(playbackSpeed);
            }
        }

        public ViewModel(IModel model)
        {
            this.model = model;
            this.playbackSpeed = 50;
            VM_PlaybackSpeed = playbackSpeed;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (String.Equals(propName, "VM_gotCSVfile"))
            {
                this.VM_view = model.sendView();
            }
        }

        public void VM_sendCSV(OpenFileDialog csvFile)
        {
            model.getCSV(csvFile);
        }
    }
}
