using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Server created and started
            TcpListener server = new TcpListener(System.Net.IPAddress.Any,8888);
            server.Start();
            Console.WriteLine("Server Started");
            //Socket
            Socket clientdoor = server.AcceptSocket();
            //If client is connected
            if (clientdoor.Connected)
            {
                //Create network stream (middle man) for read and write function
                NetworkStream ns = new NetworkStream(clientdoor);
                //Using writer to send message to client from server
                Console.WriteLine("Server >> Hello Client");
                StreamWriter streamWriter = new StreamWriter(ns);
                StreamReader streamReader = new StreamReader(ns);
                streamWriter.WriteLine("server >> I am Iron-man");
                //Print everything which is in writer stream
                streamWriter.Flush();
                while (true)
                {
                    string clientmessage = streamReader.ReadLine();
                    if (clientmessage != null)
                    {
                        Console.WriteLine("Client >> " + clientmessage);
                        Console.Write("Server:|");
                        string message = Console.ReadLine();
                        string botmessage = "Server >> " + message;
                        streamWriter.WriteLine(botmessage);
                    }
                    else
                    {
                        Console.WriteLine("Client Disconnected");
                        break;
                    }
                }
            }
            //If client is not connected
        }
    }
}
