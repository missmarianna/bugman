using System.Windows;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

namespace gameeee
{
    /// <summary>
    /// Логика взаимодействия для Connect.xaml
    /// </summary>
    public partial class Connect : Window
    {
        Random rnd = new Random();
        public byte[] data;
        public string response = "";
        MainWindow game = new MainWindow();
        TcpClient client = new TcpClient();
        public Connect()
        {
            InitializeComponent();
            
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            int n = rnd.Next(1000, 9999);  //identificator clienta
            data = BitConverter.GetBytes(n);
            try
            {
                client.Connect(Convert.ToString(IpText.Text), Convert.ToInt32(PortText.Text));
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
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
            if (response == ("Connected " + n.ToString()))
            {
                Close();
                game.Show();
            }
        }
    }
}
