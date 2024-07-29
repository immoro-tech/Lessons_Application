using System.Net;
using System.Net.Sockets;

var tcpListener = new TcpListener(IPAddress.Any, 8888);
try
{
    tcpListener.Start();
    Console.WriteLine("Server started");

    while (true)
    {
        using var tcpClient = await tcpListener.AcceptTcpClientAsync();
        Console.WriteLine(tcpClient.Client.RemoteEndPoint);
    }
}
finally
{
    tcpListener.Stop();
    Console.WriteLine("Connect closed");
}