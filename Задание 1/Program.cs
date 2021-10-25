using System;
using System.IO;

namespace JSON_to_html
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("Form.json") == false)
            {
                Console.WriteLine("Json файл не найден. Работа программы будет завершена.");
                Console.ReadKey();
                return;
            }

            Rootobject jsonform = Files.GetJsonFile();
            Files.WriteFile(jsonform);
            Console.ReadKey();
        }
    }
}
