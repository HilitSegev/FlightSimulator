using System;
using System.Collections.Generic;
using System.Reflection;
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
    /// Interaction logic for Graphs.xaml
    /// </summary>
    public partial class Graphs : UserControl
    {
        GraphsVM Gvm;
        public Graphs()
        {
            InitializeComponent();

            // put feature names in the list for plots
            List<String> featureNames = Utilities.getFeatureNamesList("playback_small.xml");
            foreach (string name in featureNames)
            {
                featureNamesList.Items.Add(name);
            }
        }

        public GraphsVM VM_Graphs
        {
            get { return Gvm; }
            set
            {
                Gvm = value;
                this.DataContext = Gvm;
            }
        }
        
        public void DLL()
        {
            string path = Gvm.VM_DLLpath;
            try {
                Assembly dll = Assembly.LoadFile(path);
                Type[] typesInDLL = dll.GetExportedTypes();
                string s = "DLLPacade";
                foreach(Type t in typesInDLL)
                {
                    if (t.Name == s)
                    {
                        VM_Graphs.VM_DLLDynamic = Activator.CreateInstance(t);
                    }
                }
                VM_Graphs.VM_DLLDynamic.Create();
            }


            catch (Exception e)
            {
                Console.WriteLine("Error loading DLL file");
            }
        }
    }
}
