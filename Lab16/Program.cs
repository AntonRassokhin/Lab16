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
            
            /*
            ExpTovar[] expArray = new ExpTovar[3];            
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите последовательно: код товара, название товара, цену товара:");
                ExpTovar exportTovar = new ExpTovar()
                {
                    codeTovar = Convert.ToInt32(Console.ReadLine()),
                    nameTovar = Console.ReadLine(),
                    cenaTovar = Convert.ToUInt32(Console.ReadLine()),
                };
                expArray[i] = exportTovar;                
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string expJsonString = JsonSerializer.Serialize(expArray, options);

            using (StreamWriter recordFile = new StreamWriter("TEST.json", true))
            {
                recordFile.WriteLine(expJsonString);
            }
            */

            // вторая часть
            string impJsonString = File.ReadAllText("TEST.json");
            Console.WriteLine(impJsonString);

            ExpTovar[] impTovar = JsonSerializer.Deserialize<ExpTovar[]>(impJsonString);

            
            uint maxCena = impTovar[0].cenaTovar;
            string maxName = impTovar[0].nameTovar;

            for (int i = 0; i < 3; i++)
            {
                if (impTovar[i].cenaTovar > maxCena)
                {
                    maxCena = impTovar[i].cenaTovar;
                    maxName = impTovar[i].nameTovar;
                }
            }
            Console.WriteLine("Товар {0} - самый дорогой", maxName);
            Console.ReadKey();
            
        }
    }

    class ExpTovar
    {
        public int codeTovar { get; set; }
        public string nameTovar { get; set; }
        public uint cenaTovar { get; set; }
    }
       
}
