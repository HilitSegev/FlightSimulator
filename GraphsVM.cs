using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WPF
{
    public class GraphsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IModel model;
        private int invalidateFlag;
        private int selectedFeatureIndex;

        public int VM_SelectedFeatureIndex
        {
            get { return selectedFeatureIndex; }
            set
            {
                selectedFeatureIndex = value;
                model.SelectedFeatureChanged(selectedFeatureIndex);
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

        public int VM_InvalidateFlag
        {
            get
            {
                return invalidateFlag;
            }
        }

        public GraphsVM(IModel model)
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
