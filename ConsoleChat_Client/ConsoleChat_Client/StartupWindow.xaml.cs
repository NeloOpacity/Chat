using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace ConsoleChat_Client
{
    /// <summary>
    /// Логика взаимодействия для StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
        }

        private void bConnect_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ClientName.Text.Trim()) || String.IsNullOrEmpty(ClientConnectIp.Text.Trim()) || String.IsNullOrEmpty(ClientConnectPort.Text.Trim()))
            {
                MessageBox.Show("Какое-то из полей пустое!");
            }
            else
            {
                try
                {
                    Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ClientConnectIp.Text.Trim()), Convert.ToInt32(ClientConnectPort.Text.Trim()));
                    socket.Connect(ip);
                    string name = ClientName.Text.Trim();
                    SocketFunctions.SendString(socket, name);
                    MainWindow window = new MainWindow(socket);
                    window.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
