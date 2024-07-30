using Lessons_Application_Backend.Model;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Lessons_Application_Backend;

public class Program
{
    static void Main(string[] args)
    {
        TcpListener server = new TcpListener(IPAddress.Any, 8888);
        server.Start();
        Console.WriteLine("Sever running");


        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Thread clientThread = new Thread(() => HandleClient(client));
            clientThread.Start();
        }
    }

    private static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        string[] requestData = request.Split(',');

        if (requestData[0] == "register")
        {
            string username = requestData[1];
            string password = requestData[2];
            string name = requestData[3];
            int age = Convert.ToInt32(requestData[4]);

            using (var context = new ApplicationDbContext())
            {
                User newUser = new User
                {
                    Username = username,
                    Password = password,
                    Name = name,
                    Age = age
                };
                context.Users.Add(newUser);
                context.SaveChanges();
            }
            Console.WriteLine($"User {username} registration succefull");
        }
        client.Close();
    }
}