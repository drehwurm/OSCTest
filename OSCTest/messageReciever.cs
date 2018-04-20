using Ventuz.OSC;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OSCTest
{
    class messageReciever
    {
        //Fields
        
        int port;
        UdpReader reader;
        OscBundle bundle = null;
        OscElement message = null;
        string argument;

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
        public string Recieve()
        {
            Task recieveTask = new Task(() => {
                Debug.WriteLine("Started new Thread");
                while (true)
                {
                    bundle = (OscBundle)reader.Receive();

                    if (bundle != null)
                    {
                        foreach (var element in bundle.Elements)
                        {
                            message = (OscElement)element;

                            foreach (var arg in message.Args)
                            {
                                argument = (string)arg;
                            }

                            //Debug.WriteLine(argument);

                        }
                    }

                }
            });

            //TO DO Implement something to prevent starting too many threads                        

            recieveTask.Start();


            return argument;

        }




    }
}
