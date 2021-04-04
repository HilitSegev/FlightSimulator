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

        private int currentRow;
        public int VM_CurrentRow
        {
            get { return model.CurrentRow; }
            set
            {
                model.CurrentRow = value;
            }
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
