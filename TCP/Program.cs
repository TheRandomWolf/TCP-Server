namespace TCP
{
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

    /// <summary>
    /// This class handles the TCP server
    /// </summary>
    public class Program
    {
        private static TcpListener server = OpenServer(8001);

        /// <summary>
        /// This method handles sending messages.
        /// </summary>
        /// <param name="socket"></param>
        private static void SendMessage(Socket socket)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] msgBytes = ascii.GetBytes("test");
            socket.Send(msgBytes);
        }

        /// <summary>
        /// This method gets the bytes of the message
        /// </summary>
        /// <param name="s"></param>
        /// <returns>""</returns>
        private static byte[] GetBytes(Socket s)
        {
            byte[] b = new byte[1024];
            int k = s.Receive(b);
            byte[] c = new byte[k];
            for (int i = 0; i < k; i++)
                c[i] = b[i];
            return c;
        }
        /// <summary>
        /// Converts the message's bytes
        /// </summary>
        /// <param name="messageBytes"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GetMessage(byte[] messageBytes, int length)
        {
            List<char> messageChars = new List<char>();
            string message = string.Empty;
            for (int i = 0; i < length; i++)
            {
                char temp = Convert.ToChar(messageBytes[i]);
                messageChars.Add(temp);
                message += messageChars[i];
            }

            return new string(messageChars.ToArray());
        }

        private static TcpListener OpenServer(int port)
        {
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine("The server is running on port" + port.ToString());
            return server;
        }
        /// <summary>
        /// This method handles the main thread
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Socket socketBytes = server.AcceptSocket();
            byte[] recieved = GetBytes(socketBytes);
            string message = GetMessage(recieved, recieved.Length);
            Console.WriteLine("{0}: {1}", socketBytes.RemoteEndPoint, message);
            SendMessage(socketBytes);
            System.Threading.Thread.Sleep(500);
            Console.ReadKey(true);
        }
    }
}