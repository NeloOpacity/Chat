using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleChat_Server
{
    static class SocketFunctions
    {
        static public void SendInt(Socket socket, int x)
        {
            byte[] data;
            data = BitConverter.GetBytes(x);
            socket.Send(data);
        }
        static public void SendString(Socket socket, string str)
        {
            byte[] data_size = new byte[sizeof(int)];
            byte[] data;
            data = Encoding.Unicode.GetBytes(str);
            int length = data.Length;
            data_size = BitConverter.GetBytes(length);
            socket.Send(data_size);
            socket.Send(data);
        }
        static public int RecieveInt(Socket socket)
        {
            byte[] data = new byte[sizeof(int)];
            socket.Receive(data);
            return BitConverter.ToInt32(data, 0);
        }

        static public string RecieveString(Socket socket)
        {
            byte[] data_size = new byte[sizeof(int)];
            socket.Receive(data_size);
            byte[] data = new byte[BitConverter.ToInt32(data_size, 0)];
            socket.Receive(data);
            return new[] { Encoding.Unicode.GetString(data) }[0];
        }
    }
}
