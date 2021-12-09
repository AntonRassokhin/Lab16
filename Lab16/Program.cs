using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] expArray = new string[3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите последовательно: код товара, название товара, цену товара:");
                ExpTovar exportTovar = new ExpTovar()
                {
                    codeTovar = Convert.ToInt32(Console.ReadLine()),
                    nameTovar = Console.ReadLine(),
                    cenaTovar = Convert.ToUInt32(Console.ReadLine()),
                };
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string expJsonString = JsonSerializer.Serialize(exportTovar, options);
                expArray[i] = expJsonString;
                using (StreamWriter recordFile = new StreamWriter("TEST.json", true))
                {
                    recordFile.WriteLine(expArray[i]);
                }
            }
            

            // вторая часть
            string impJsonString = File.ReadAllText("TEST.json");
            var impTovar = JsonSerializer.Deserialize<List<ImpTovar>>(impJsonString);
            var maxPrice = impTovar.Max(x => x.cenaTovar);
            var maxName = impTovar.Last(x => x.cenaTovar == maxPrice).nameTovar;
            Console.WriteLine("Самый дорогой товар - {0}", maxName);
            Console.ReadKey();
        }
    }

    class ExpTovar
    {
        public int codeTovar { get; set; }
        public string nameTovar { get; set; }
        public uint cenaTovar { get; set; }
    }

    class ImpTovar
    {
        public int codeTovar { get; set; }
        public string nameTovar { get; set; }
        public uint cenaTovar { get; set; }

        /*public void SayCena()
        {
            Console.WriteLine(cenaTovar);
        }*/
    }
}
