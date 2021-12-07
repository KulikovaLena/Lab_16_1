using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace Lab_16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Product[] product = new Product[5];
            product[0] = new Product(1, "Tov1", 1);
            product[1] = new Product(2, "Tov2", 2);
            product[2] = new Product(3, "Tov3", 3);
            product[3] = new Product(4, "Tov4", 4);
            product[4] = new Product(5, "Tov5", 5);
            foreach (var i in product)
            {
                i.Info();
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(product, options);
            Console.WriteLine(jsonString);
            string path = "D:\\Lena\\BIM\\Lab_16_1\\Product.json";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(jsonString);
            }
            Console.ReadKey();
        }
            
    }
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
        public Product(int code, string name, double price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
        public void Info()
        {
            Console.Write("vvedite artikul {0} ", Code);
            Code = Convert.ToInt32(Console.ReadLine());
            Console.Write("vvedite nazvanie {0} ", Name);
            Name  = Convert.ToString(Console.ReadLine());
            Console.Write("vvedite cenu {0} ", Price);
            Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
        }
    }
}
