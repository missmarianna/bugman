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
            int n = rnd.Next(1000, 9999);  //индентификатор клиента
            data = BitConverter.GetBytes(n);//записываем его в буфер для последующей передачи.
            App.StartG(IpText.Text, Convert.ToInt32(PortText.Text), data);
        }
    }
}
