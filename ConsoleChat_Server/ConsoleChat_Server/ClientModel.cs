using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleChat_Server
{
    class ClientModel
    {
        List<string> Messages = new List<string>();
        public Socket ServerSocket { get; set; }
        public string Name { get; set; }

        public Socket ClientSocket { get; set; }

        public static List<Socket> AllClientSockets = new List<Socket>();

        public void Listen()
        {
            new Thread(new ThreadStart(delegate ()
            {
                IPEndPoint ip = (IPEndPoint)ClientSocket.RemoteEndPoint;
                try
                {
                    Console.WriteLine($"{Name} с адресом {ip.Address.ToString()} подключен!");
                    Thread dad=new Thread(new ThreadStart(SendMessages));
                    dad.Start();
                    while (ClientSocket.Connected)
                    {
                        int signal = SocketFunctions.RecieveInt(ClientSocket);
                        if (signal == 1)
                        {
                            dad.Abort();
                            Console.WriteLine($"{Name} {ip.Address.ToString()} отключён! GOODBYE JOJO!!!!!!!!!!!!!!!!!!!!");
                            ClientSocket.Shutdown(SocketShutdown.Both);
                            ClientSocket.Close();
                            AllClientSockets.RemoveAll(x => x == ClientSocket);
                        }
                        else if (signal == 0)
                        {
                            string msg = SocketFunctions.RecieveString(ClientSocket);
                            Messages.Add(Name + "%&%" + msg);
                            Console.WriteLine($"{Name}:{msg}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{Name}:{ip.Address.ToString()} отключён! GOODBYE JOJO!!!!!!!!!!!!!!!!!!!!");
                }
            })).Start();
        }

        public void SendMessages()
        {
                while (ClientSocket.Connected)
                {
                    if (Messages.Count == 0)
                    {
                        Thread.Sleep(1);
                    }
                    else if (Messages.Count != 0)
                    {
                    foreach (Socket s in AllClientSockets)
                    {
                        SocketFunctions.SendInt(s, 0);
                        SocketFunctions.SendString(s, Messages[0]);
                    }
                        Messages.RemoveAt(0);
                    }
                }
        }
    }
}
