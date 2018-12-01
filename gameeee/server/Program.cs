﻿using System;
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
                byte[] data = new byte[256];
                string mess = "";
                int port = 8888;
                string ip = "127.0.0.1";
                IPAddress localAddr = IPAddress.Parse(ip);
                server = new TcpListener(localAddr, port);
                server.Start();
               
                    TcpClient client = server.AcceptTcpClient();//Здесь сервак принимает подключение, следовательно после этой строчки запускаем отдельный поток под следущее подключение
                    NetworkStream stream = client.GetStream();
                    do
                    {
                        int bytes = stream.Read(data, 0, data.Length);
                        mess += Encoding.UTF8.GetString(data, 0, bytes);
                    }
                    while (stream.DataAvailable);
                    string response = "Connected " + mess;
                    data = Encoding.UTF8.GetBytes(response);
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                    client.Close();
            
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.Read();
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }
    }
}
