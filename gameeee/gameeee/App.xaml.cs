using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace gameeee
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow game = new MainWindow();
        Connect conwin = new Connect();
        public string response;
        public async void StartG(string serverIpAddress, int port, byte[] data)
        {
            TcpClient client = new TcpClient();
            try
            {
               await client.ConnectAsync(serverIpAddress, port);
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(data, 0, data.Length);
                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    response += Encoding.UTF8.GetString(data, 0, bytes);
                }
                while (stream.DataAvailable);
            }
            catch (SocketException error)
            {
                MessageBox.Show(error.ToString(), "Ошибка!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Ошибка!");
            }
            if (response == ("Connected " + data))
            {
                conwin.Close();
                game.Show();
            }
        }
    }
}
