using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Substitutii_monoalfabetice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti textul clar pentru Cezar cu n=3:");
            string plaintext1 = Console.ReadLine();
            Cezar3 cod = new Cezar3(plaintext1);

            Console.WriteLine("Introduceti textul clar pentru Cezar:");
            string plaintext2 = Console.ReadLine();
            Console.WriteLine("Introduceti n-ul");
            int n = int.Parse(Console.ReadLine());
            Cezar cod2 = new Cezar(plaintext2, n);

            Console.WriteLine("Introduceti textul clar pentru ROT13:");
            string plaintext3 = Console.ReadLine();
            ROT13 cod3 = new ROT13(plaintext3);

            Console.WriteLine("Introduceti textul clar pentru substitutia monoalfabetica:");
            string plaintext4 = Console.ReadLine();
            SimpleSubstitution cod4 = new SimpleSubstitution(plaintext4, "zebras");

            Console.ReadKey();
        }
    }
}
