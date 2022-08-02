using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Hack
{
    public class HackSocket
    {
        public Thread mThread;
        public string connectionIP = "127.0.0.1";
        public int connectionPort = 25001;
        public string json = "";
        public bool connected;
        public bool listening;
        private TcpListener listener;
        private TcpClient client;

        // debug string for display in game if needed
        private string _debug = "";
        private string debug { get{return _debug;} set { _debug = _debug + value + " "; } }

        public HackSocket()
        {
            ThreadStart ts = new ThreadStart(GetInfo);
            mThread = new Thread(ts);
            mThread.Start();
        }

        private void GetInfo()
        {
            listener = new TcpListener(IPAddress.Any, 1302);
            listener.Start();
            connected = true;
            connection:
            listening = true;
            client = listener.AcceptTcpClient();
            listening = false;
            // try catch to catch when a client disconnects
            try
            {
                while (connected)
                {
                    SendData();
                }
            }
            catch
            {
                goto connection;
            }
            connected = false;
        }

        // Destructor to clean up thread
        ~HackSocket()
        {
            listener.Stop();
            mThread.Abort();
        }

        private void SendData()
        {
            //---Sending Data to Host----
            //StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());
            sw.WriteLine(json);
            sw.Flush();
        }

        public void SendData(string json)
        {
            this.json = json;
        }

        public void Disconnect()
        {
            connected = false;
        }


        public string ConnectionStatus()
        {
            string extra = 
                "side car: " + mThread.IsAlive + "\n" +
                "Client Connected: " + !listening + "\n" +
                "Current data: " + json;

           if (connected)
            {
                return "TCP Status: Connected to " + connectionIP + ":" + connectionPort + "\n" + extra;
            }
            else
            {
                return "TCP Status: Not connected \n" + extra;
            }
        }
    }
}