using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gameeee
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string response = "";
        public byte[] data;
        MainWindow game = new MainWindow();
        Connect conwin = new Connect();
        Random rnd = new Random();
        public async Task StartG()
        {
            TcpClient client = new TcpClient();
            data = BitConverter.GetBytes(rnd.Next(1000, 9999));  //индентификатор клиента);//записываем его в буфер для последующей передачи.
            try
            {
               await client.ConnectAsync(Connect.IpText.Text, Convert.ToInt32(Connect.PortText.Text));//  меня задолбало это говно, поправьте как то)
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
