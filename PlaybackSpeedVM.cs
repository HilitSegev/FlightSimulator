using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WPF
{
    public class PlaybackSpeedVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
        public PlaybackSpeedVM(IModel model)
        {

            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            this.playbackSpeed = 100;
            VM_PlaybackSpeed = playbackSpeed;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
