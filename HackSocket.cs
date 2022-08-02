using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Hack
{
    public class HackSocket
    {
        public Thread mThread;
        public string connectionIP = "127.0.0.1";
        public int connectionPort = 25001;
        TcpListener listener;
        TcpClient client;

        public HackSocket()
        {
            ThreadStart ts = new ThreadStart(GetInfo);
            mThread = new Thread(ts);
            mThread.Start();
        }

        private void GetInfo()
        {
            client = new TcpClient(connectionIP, connectionPort);
        }

        // Destructor to clean up thread
        ~HackSocket()
        {
            client.Close();
            listener.Stop();
            mThread.Abort();
        }

        public void SendData(string json)
        {
            NetworkStream newStream = client.GetStream();

            //---Sending Data to Host----
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes(json); //Converting string to byte data
            newStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Sending the data in Bytes to Python
        }
    }
}