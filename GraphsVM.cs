using Microsoft.Win32;
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
        private int selectedAnomaly;

        private Object dllDynamic;
        private string dllPath;

        public int VM_SelectedFeatureIndex
        {
            get { return selectedFeatureIndex; }
            set
            {
                selectedFeatureIndex = value;
                model.SelectedFeatureChanged(selectedFeatureIndex);
            }
        }
        public int VM_SelectedAnomaly
        {
            get { return selectedAnomaly; }
            set
            {
                selectedAnomaly = value;
                model.SelectedAnomalyChanged(selectedAnomaly);
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

        public List<DataPoint> VM_PointsCorrelatedFeature
        {
            get
            {
                invalidateFlag++;
                NotifyPropertyChanged("VM_InvalidateFlag");
                return model.PointsCorrelatedFeature;
            }
        }

        public List<DataPoint> VM_PointsSelectedAndCorrelated
        {
            get
            {
                invalidateFlag++;
                NotifyPropertyChanged("VM_InvalidateFlag");
                return model.PointsSelectedAndCorrelated;
            }
        }
        public List<DataPoint> VM_RegressionLinePoints
        {
            get
            {
                invalidateFlag++;
                NotifyPropertyChanged("VM_InvalidateFlag");
                return model.RegressionLinePoints;
            }
        }

        public List<DataPoint> VM_Last30SecPoints
        {
            get
            {
                invalidateFlag++;
                NotifyPropertyChanged("VM_InvalidateFlag");
                return model.Last30SecPoints;
            }
        }

        public List<DataPoint> VM_AnomalyPoints
        {
            get
            {
                invalidateFlag++;
                NotifyPropertyChanged("VM_InvalidateFlag");
                return model.AnomalyPoints;
            }
        }

        public List<string> VM_AnomalyIdxList
        {
            get
            {
                invalidateFlag++;
                NotifyPropertyChanged("VM_InvalidateFlag");
                return model.AnomalyIdxList;
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

        public dynamic VM_DLLDynamic
        {
            get { return dllDynamic; }
            set
            {
                dllDynamic = value;
                model.DLLDynamic(dllDynamic);
            }
        }

        public string VM_DLLpath
        {
            get { return dllPath; }
            set
            {
                dllPath = value;
            }
        }

    }
}
