using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace Program_16
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Tovar[] tovar = new Tovar[5];
            double MaxPrice = int.MinValue;
            int Max = 0;
            for (int i = 0; i < 5; i++)
            {
                tovar[i] = new Tovar();

                Console.Write("Введите код товара: ");
                tovar[i].kodTovara = int.Parse(Console.ReadLine());
                Console.Write("Введите наименование товара: ");
                tovar[i].nameTovara = Console.ReadLine();
                Console.Write("Введите стоимость товара: ");
                tovar[i].priceTovara = double.Parse(Console.ReadLine());
                Console.WriteLine();

                if (tovar[i].priceTovara > MaxPrice)
                {
                    MaxPrice = tovar[i].priceTovara;
                    Max = i;
                }
             };
  
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonstring = JsonSerializer.Serialize(tovar, options);
            Console.WriteLine(jsonstring);

            using (StreamWriter sx = new StreamWriter("../../../../Products.json"))
            {
                sx.WriteLine(jsonstring);
            }

            string jsonstring2 = File.ReadAllText("../../../../Products.json");
            Tovar[] tovar1 = JsonSerializer.Deserialize<Tovar[]>(jsonstring2);
            Console.WriteLine(jsonstring2);

            Console.WriteLine("Самый дорогой товар: {0}, его стоимость сотавляет: {1}", Max, MaxPrice);

            Console.ReadKey();
        }
    }
    class Tovar
    {
        public int kodTovara { get; set; }
        public string nameTovara { get; set; }
        public double priceTovara { get; set; }
    }
}
//1.Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

//Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
//Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
//Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».

//2.    Необходимо разработать программу для получения информации о товаре из json-файла.
//Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
