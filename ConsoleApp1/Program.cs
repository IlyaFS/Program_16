using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[5];
            for (int i = 0; i < 5; i++)
            {
                products[i] = new Product();
                Console.WriteLine("Введите код:");
                products[i].Code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название:");
                products[i].Name = Console.ReadLine();
                Console.WriteLine("Введите стоимость:");
                products[i].Cost = Convert.ToDouble(Console.ReadLine());
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            string outJs = JsonSerializer.Serialize(products, options);
            Console.WriteLine(outJs);

            using (StreamWriter sw = new StreamWriter("../../../../Products.json"))
            {
                sw.WriteLine(outJs);

            }

            Console.ReadKey();
        }
    }


    class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }


    }
}
