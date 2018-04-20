using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Diagnostics;

namespace OSCTest
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        messageSender m = new messageSender(); //Initialize OSC Sender
        messageReciever r = new messageReciever(); //Initialize OSC Reciever

        public MainWindow()
        {
            InitializeComponent();
                        
        }
        




        // Sender Methods

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






        //Reciever Methods

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //TO DO Get Updates instantly as soon as r.Recieve() changes

            recievedFloatMessage.Text = r.Recieve();
            /*recievedFloatMessage.Dispatcher.BeginInvoke((ThreadStart)delegate ()
            {
                recievedFloatMessage.Text = r.Recieve();
            });*/



        }
    }
}
