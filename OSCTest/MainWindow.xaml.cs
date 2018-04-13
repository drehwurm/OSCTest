using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ventuz.OSC;

namespace OSCTest
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        messageSender m = new messageSender(); //Initialize OSC Sender
        messageReciever r = new messageReciever(); //Initialize OSC Sender

        public MainWindow()
        {
            InitializeComponent();
                        
        }
        
        private void sendIntButton_Click(object sender, RoutedEventArgs e)
        {
            OscElement imsg = new OscElement(integerAddressTextBox.Text, integerTextBox.Text); //Typkonvertierung beachten
            m.sendOscMessage(imsg);
        }

        private void sendStringButton_Click(object sender, RoutedEventArgs e)
        {
            OscElement smsg = new OscElement(stringAddressTextBox.Text, stringTextBox.Text);
            m.sendOscMessage(smsg);
        }

        private void sendFloatButton_Click(object sender, RoutedEventArgs e)
        {
            OscElement fmsg = new OscElement(floatAdressTextBox.Text, floatTextBox.Text);
            m.sendOscMessage(fmsg);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OscBundle bundle = r.Recieve();
            if (bundle != null)
            {
                foreach (OscElement element in bundle.Elements)
                {
                    recievedFloatMessage.Text += element;
                }
            }

        }
    }
}
