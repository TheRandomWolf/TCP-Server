using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCP
{
	public class Server
	{
		public int ServerPort { get; private set; }
		public IPAddress ServerIP { get; private set; }
		public TcpListener server;
		public bool Active { get; private set; }
		public Server(int port)
		{
			ServerPort = port;
			ServerIP = IPAddress.Any;
			server = new TcpListener(ServerIP, ServerPort);
		}
		public Server(int port, IPAddress ip)
		{
			ServerPort = port;
			ServerIP = ip;
			server = new TcpListener(ServerIP, ServerPort);
		}
		public void StartServer()
		{
			server.Start();
			Active = true;
		}
	}
}
