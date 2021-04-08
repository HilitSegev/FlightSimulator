using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WPF
{
    public class DashBoardVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IModel model;

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

        public DashBoardVM(IModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
