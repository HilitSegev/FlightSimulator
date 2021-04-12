using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Microsoft.Win32;
using OxyPlot;

namespace WPF
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IModel model;
        private int currentRow;

        public int VM_CurrentRow
        {
            get { return model.CurrentRow; }
            set
            {
                model.CurrentRow = value;
                model.PointsSelectedFeature = new List<DataPoint>();
                model.PointsCorrelatedFeature = new List<DataPoint>();
                model.RegressionLinePoints = model.PointsSelectedAndCorrelated.GetRange(0, model.CurrentRow);
                model.Last30SecPoints = new List<DataPoint>();
            }
        }

        private int numOfCSVRows;

        public int VM_NumOfCSVRows
        {
            get
            {
                return numOfCSVRows;
            }
            set
            {
                numOfCSVRows = value;
                NotifyPropertyChanged("VM_NumOfCSVRows");
            }
        }

        public ViewModel(IModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

            this.currentRow = 0;
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public void VM_sendCSV(OpenFileDialog csvFile)
        {
            VM_NumOfCSVRows = model.getCSV(csvFile);
        }

        public void VM_sendCSVDetect(OpenFileDialog csvFile)
        {
            model.getCSVDetect(csvFile);
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
