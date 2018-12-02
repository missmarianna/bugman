using System.Windows;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;
using System.Threading.Tasks;

namespace gameeee
{
    /// <summary>
    /// Логика взаимодействия для Connect.xaml
    /// </summary>
    public partial class Connect : Window
    {
        
        public byte[] data;
        public string response = "";
        public int n;
        MainWindow game = new MainWindow();
        TcpClient client = new TcpClient();
        public Connect()
        {
            InitializeComponent();
            
        }
        
        private async void Connect_ClickAsync(object sender, RoutedEventArgs e)
        {
            await App.StartG();
        }
    }
}
