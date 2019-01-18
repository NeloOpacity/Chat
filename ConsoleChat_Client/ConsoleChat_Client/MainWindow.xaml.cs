using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Threading;
using System.Runtime.CompilerServices;
using System.ComponentModel;
namespace ConsoleChat_Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Chat chat { get; set; }
        Socket socket;
        public MainWindow(Socket _socket)
        {
            InitializeComponent();
            //chat = new Chat();
            this.DataContext = this;
            socket = _socket;
            GetMessageAsync().GetAwaiter();
        }

        async Task GetMessageAsync()
        {
            while (true)
            {
                await Task.Delay(500);
                string x = await Task.Run(() =>
                {
                    while (true)
                    {
                        if (SocketFunctions.RecieveInt(socket) == 0)
                            break;
                    }
                    return SocketFunctions.RecieveString(socket);
                });
                string[] msg = x.Split(new[] { "%&%" }, StringSplitOptions.None);
                AllMessages.AppendText(msg[0] + " : " + msg[1] + " " + Environment.NewLine);
            }
        }

        private void bSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(ClientMessage.Text.Trim()))
            {
                SocketFunctions.SendInt(socket, 0);
                SocketFunctions.SendString(socket, ClientMessage.Text.Trim());
                ClientMessage.Text = "";
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SocketFunctions.SendInt(socket, 1);
        }
    }
}
