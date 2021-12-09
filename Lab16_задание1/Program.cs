using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode; 
using System.Text.Json.Serialization;

namespace Lab16_задание1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tovar tovar = new Tovar()
            { 
            }


        }
    }

    class Tovar
    {
        public int codeTovar { get; set; }
        public string nameTovar { get; set; }
        public uint CenaTovar { get; set; }     
    }
}
