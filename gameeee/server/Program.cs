using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                int port = 8888;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                server.Start();
                while (true)
                {
                    string mess = "";
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    byte[] data = new byte[256];
                    do
                    {
                        int bytes = stream.Read(data, 0, data.Length);
                        mess += Encoding.UTF8.GetString(data, 0, bytes);
                    } while (stream.DataAvailable);
                    string response = "Вы говорите это: " + mess;
                    data = Encoding.UTF8.GetBytes(response);
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                if (server != null) server.Stop();
            }
        }
    }
}
