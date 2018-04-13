using Ventuz.OSC;

namespace OSCTest
{
    class messageReciever
    {
        //Fields
        int port;
        UdpReader reader;
        OscBundle bundle = null;

        //Constructors
        public messageReciever()
        {
            port = 4445;
            reader = new UdpReader(port);
        }

        public messageReciever(int port)
        {
            this.port = port;
            reader = new UdpReader(port);
        }

        //Methods
        public OscBundle Recieve()
        {
            bundle = (OscBundle)reader.Receive();

            return bundle;
        }




    }
}
