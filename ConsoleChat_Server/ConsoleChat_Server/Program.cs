using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleChat_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread listeningThread = new Thread(ListenForClients);
            listeningThread.Start();
            listeningThread.Join();
            Console.ReadLine();
        }
        static void ListenForClients()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1213);
            Socket socket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(ip);
                socket.Listen(0);
                while (true)
                {
                    Socket socket2 = socket.Accept();
                    byte[] data_size = new byte[sizeof(int)];
                    socket2.Receive(data_size);
                    byte[] data = new byte[BitConverter.ToInt32(data_size, 0)];
                    socket2.Receive(data);
                    string name = Encoding.Unicode.GetString(data);
                    ClientModel client = new ClientModel { Name = name, ClientSocket = socket2, ServerSocket = socket };
                    ClientModel.AllClientSockets.Add(client.ClientSocket);
                    client.Listen();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
