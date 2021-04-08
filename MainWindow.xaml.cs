using System.Windows;
using OxyPlot;
using System;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ViewModel vm;
        DashBoardVM Dvm;
        JoyStickVM JSvm;
        PlaybackSpeedVM PSvm;
        GraphsVM Gvm;

        public MainWindow()
        {
            InitializeComponent();

            // put feature names in the list for plots
            //List<String> featureNames = Utilities.getFeatureNamesList("playback_small.xml");
            //foreach (string name in featureNames) {
            //    featureNamesList.Items.Add(name);
            //}

            Model model = new Model(new TelnetClient());
            vm = new ViewModel(model);
            Dvm = new DashBoardVM(model);
            dashBoard.VM_DashBoard = Dvm;
            JSvm = new JoyStickVM(model);
            joyStick.VM_JoyStick = JSvm;
            PSvm = new PlaybackSpeedVM(model);
            playbackSpeed.VM_PlaybackSpeed = PSvm;

            Gvm = new GraphsVM(model);
            graphs.VM_Graphs = Gvm;
            //vm = new ViewModel(new Model(new TelnetClient()));
            DataContext = vm;

        }

        private void uploadCSVButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog csvFile = new OpenFileDialog();
            csvFile.Filter = "CSV Files (*.csv)|*.csv";

            if (csvFile.ShowDialog() == true)
            {
                txtEditor.Text = File.ReadAllText(csvFile.FileName);
                vm.VM_sendCSV(csvFile);
            }
        }

        private void playButtonClick(object sender, RoutedEventArgs e)
        {
            vm.VM_playButtonClick();

        }

        private void pauseButtonClick(object sender, RoutedEventArgs e)
        {
            vm.VM_pauseButtonClick();
        }

        private void stopButtonClick(object sender, RoutedEventArgs e)
        {
            vm.VM_stopButtonClick();
        }
    }
}
