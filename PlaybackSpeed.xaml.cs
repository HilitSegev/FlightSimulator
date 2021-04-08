using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for PlaybackSpeed.xaml
    /// </summary>
    public partial class PlaybackSpeed : UserControl
    {
        PlaybackSpeedVM PSvm;
        public PlaybackSpeed()
        {
            InitializeComponent();
        }

        public PlaybackSpeedVM VM_PlaybackSpeed
        {
            get { return PSvm; }
            set
            {
                PSvm = value;
                this.DataContext = PSvm;
            }
        }
    }
}
