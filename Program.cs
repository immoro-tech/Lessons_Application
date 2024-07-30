using System.Net.Sockets;
using Lessons_Aplication_Frontend;
using Lessons_Aplication_Frontend.Pages;
public class Program
{
    static void Main()
    {
        RegistrationPage registrationPage = new();
        registrationPage.DataFillingForm();

        Console.ReadKey();
    }

}