using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Lessons_Aplication_Frontend.Pages
{
    public class RegistrationPage
    {
        public void DataFillingForm() 
        {
            Console.WriteLine("Registration page");

            Console.WriteLine("Entry Username:");
            string? username = Console.ReadLine();

            Console.WriteLine("Entry Password:");
            string? password = Console.ReadLine();

            Console.WriteLine("Entry Your Name:");
            string? name = Console.ReadLine();

            Console.WriteLine("Entry Your Age:");
            int age = int.Parse(Console.ReadLine());

            string requsetData = $"register,{username},{password},{name},{age}";



            TcpClient tcpClient = new TcpClient("192.168.0.5", 8888);
            NetworkStream stream = tcpClient.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(requsetData);

            stream.Write(data, 0, data.Length);
            Console.WriteLine("Data send on server");

            tcpClient.Close();
        }
    }
}
