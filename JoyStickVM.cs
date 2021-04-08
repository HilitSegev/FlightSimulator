using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WPF
{
    public class JoyStickVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IModel model;

        public JoyStickVM(IModel model)
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
    }
}
