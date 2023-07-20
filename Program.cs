using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TelnetCOnect
{
    internal class Program
    {
        static void RunServr(string serverIPstr, int serverPort)
        {
            Socket server = null;
            Socket client = null;

            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                Console.WriteLine("Сервер сотворен!:)");
                IPAddress servrIP = IPAddress.Parse(serverIPstr);
                IPEndPoint servEP = new IPEndPoint(servrIP, serverPort);
                server.Bind(servEP);
                Console.WriteLine($"Адресс сервера задан!{servEP}");
                server.Listen(1);
                Console.WriteLine("Ожидание подключений");
                client = server.Accept();
                Console.WriteLine($"Клиент подключен{client.RemoteEndPoint}");

            }catch (Exception e)
            {
                Console.WriteLine("Чтото не так: "+e);
            }
            finally
            {
                server?.Close();
                client?.Close();
            }
        }
        static void Main(string[] args)
        {//26.89.185.170 1024
            string ipA = "26.89.185.170";
            int port = 1024;
            RunServr(ipA, port);

        }
    }
}
