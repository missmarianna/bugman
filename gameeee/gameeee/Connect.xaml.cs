using System.Windows;

namespace gameeee
{
    /// <summary>
    /// Логика взаимодействия для Connect.xaml
    /// </summary>
    public partial class Connect : Window
    {
        MainWindow game = new MainWindow();
        public Connect()
        {
            InitializeComponent();
            
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            Close();
            game.Show();
        }
    }
}
