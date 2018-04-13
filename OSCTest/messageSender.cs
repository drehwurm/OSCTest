using Ventuz.OSC;

namespace OSCTest
{
    class messageSender
    {
        //Fields
        string address;
        int port;
        OscBundle bundle;
        UdpWriter writer;


        //Constructors
        public messageSender()
        {
            address = "127.0.0.1";
            port = 4444;
            bundle = new OscBundle();
            writer = new UdpWriter(address, port);
        }

        public messageSender(string address, int port)
        {
            this.address = address;
            this.port = port;
            bundle = new OscBundle();
            writer = new UdpWriter(address, port);
        }



        //Methods
        public void sendOscMessage(OscElement messageElement)
        {
            bundle.AddElement(messageElement);
            writer.Send(bundle);
        }






    }
}
