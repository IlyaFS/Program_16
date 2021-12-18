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
            Type rank = new Type();
            Tovar[] tovar = { new Tovar1(), new Tovar2(), new Tovar3(), new Tovar4(), new Tovar5() };
            {
                foreach (var i in tovar)
                {
                    rank.Show(i);
                    Console.WriteLine();
                    Console.Write("Введите код товара: ");
                    int kodtovara = int.Parse(Console.ReadLine());
                    Console.Write("Введите наименование товара: ");
                    string nametovara = Console.ReadLine();
                    Console.Write("Введите стоимость товара: ");
                    int pricetovara = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
            };
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonstring = JsonSerializer.Serialize(tovar, options);

            Console.WriteLine(jsonstring);

            string path = "Products.json";
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            using (StreamWriter sx = new StreamWriter(path))

            {
                sx.WriteLine(jsonstring);
            }


            string jsonstring2 = File.ReadAllText("Products.json");
            Tovar tovar1 = JsonSerializer.Deserialize<Tovar>(jsonstring2);
          
            Console.WriteLine(jsonstring2);

            Console.ReadKey();
        }

    }
    class Tovar
    {
        public virtual string Type { get; set; }
        public virtual int kodTovara { get; set; }
        public virtual string nameTovara { get; set; }
        public virtual double priceTovara { get; set; }
        public virtual void ShowInfo()
        {
            Console.Write(Type);
        }

    }
    class Type
    {
        public void Show(Tovar tovar)
        {
            tovar.ShowInfo();
        }
    }
    class Tovar1 : Tovar
    {
        public override string Type { get { return "Товар 1:"; } }
        public override int kodTovara { get; set; }
        public override string nameTovara { get; set; }
        public override double priceTovara { get; set; }

    }
    class Tovar2 : Tovar
    {
        public override string Type { get { return "Товар 2:"; } }
        public override int kodTovara { get; set; }
        public override string nameTovara { get; set; }
        public override double priceTovara { get; set; }


    }
    class Tovar3 : Tovar
    {
        public override string Type { get { return "Товар 3:"; } }
        public override int kodTovara { get; set; }
        public override string nameTovara { get; set; }
        public override double priceTovara { get; set; }


    }
    class Tovar4 : Tovar
    {
        public override string Type { get { return "Товар 4:"; } }
        public override int kodTovara { get; set; }
        public override string nameTovara { get; set; }
        public override double priceTovara { get; set; }


    }
    class Tovar5 : Tovar
    {
        public override string Type { get { return "Товар 5:"; } }
        public override int kodTovara { get; set; }
        public override string nameTovara { get; set; }
        public override double priceTovara { get; set; }

    }

}
//1.Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

//Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
//Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
//Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».

//2.    Необходимо разработать программу для получения информации о товаре из json-файла.
//Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
