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
        }

        public void VM_sendCSV(OpenFileDialog csvFile)
        {
            model.getCSV(csvFile);
        }
    }
}
