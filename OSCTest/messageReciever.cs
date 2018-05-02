using Ventuz.OSC;
using System;
using System.Windows.Threading;

namespace OSCTest
{

    public class MessageReciever
    {
        // Fields
        OscDispatcher oscDispatcher = new OscDispatcher();
        UdpReader reader;
        int port;
        public string argument;
        public delegate void MessageRecievedEventHandler(object source, EventArgs args);
        public event MessageRecievedEventHandler MessageRecieved;



        //Constructors
        public MessageReciever()
        {
            port = 4445;
            reader = new UdpReader(port);
            oscDispatcher.AddNetReader(reader);
            oscDispatcher.Bundle += OnRecieve;
            StartRecieving();
        }

        public MessageReciever(int port)
        {
            this.port = port;
            reader = new UdpReader(port);
            oscDispatcher.AddNetReader(reader);
            oscDispatcher.Bundle += OnRecieve;
            StartRecieving();
        }



        // Methods
        public virtual void OnMessageRecieved()
        {
            if (MessageRecieved != null)
            {
                MessageRecieved(this, EventArgs.Empty);
            }
        }

        public void StartRecieving()
        {
            DispatcherTimer purgeTimer = new DispatcherTimer();
            purgeTimer.Tick += PurgeTimer_Tick;
            purgeTimer.Interval = TimeSpan.FromMilliseconds(20); // 20 milliseconds
            purgeTimer.Start();


        }

        private void PurgeTimer_Tick(object sender, EventArgs e)
        {
            oscDispatcher.Purge();
        }

        public void OnRecieve(OscDispatcher dispatcher, OscBundle bundle)
        {
            //Parsing the OSC Message
            if (bundle != null)
            {
                foreach (var element in bundle.Elements)
                {
                    OscElement message = (OscElement)element;

                    foreach (var arg in message.Args)
                    {
                        argument = (string)arg;
                    }
                    //Raising the event
                    if (argument != null)
                    {
                        OnMessageRecieved();
                    }

                }
            }
        }
    }


}
