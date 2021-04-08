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
    /// Interaction logic for JoyStick.xaml
    /// </summary>
    public partial class JoyStick : UserControl
    {
        JoyStickVM JSvm;
        public JoyStick()
        {
            InitializeComponent();
        }

        public JoyStickVM VM_JoyStick
        {
            get { return JSvm; }
            set
            {
                JSvm = value;
                this.DataContext = JSvm;
            }
        }
    }
}
