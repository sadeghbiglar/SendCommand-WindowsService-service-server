using System;
using System.IO;
using System.Net.Sockets;

class Client
{
    static void Main(string[] args)
    {
        using (TcpClient client = new TcpClient("localhost", 5002))
        using (NetworkStream stream = client.GetStream())
        using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
        using (StreamReader reader = new StreamReader(stream))
        {
            Console.Write("Enter command: ");
            string command = Console.ReadLine();
            writer.WriteLine(command);

            string response;
            while ((response = reader.ReadLine()) != "END_OF_MESSAGE")
            {
                Console.WriteLine(response);
               
            }
            Console.ReadKey();
        }
    }
}
