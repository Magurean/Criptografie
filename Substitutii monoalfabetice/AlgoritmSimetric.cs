using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Substitutii_monoalfabetice
{
    abstract class AlgoritmSimetric
    {
        public string plaintext { get; set; }
        public int key { get; set; }
        public string ciphertext { get; set; }

    }

    class Cezar : AlgoritmSimetric
    {
        public Cezar(string cod, int n)
        {
            this.plaintext = cod;
            this.key = n;
            this.ciphertext = Criptare(plaintext, n);
        }

        public static string Criptare(string plaintext, int n)
        {            
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < plaintext.Length; i++)
            {
                if (char.IsUpper(plaintext[i]))
                {
                    char ch = (char)(((int)plaintext[i] + n - 65) % 26 + 65);
                    result.Append(ch);
                }
                else
                {
                    char ch = (char)(((int)plaintext[i] + n - 97) % 26 + 97);
                    result.Append(ch);
                }
            }
            Console.WriteLine(result);
            return result.ToString();
        }
    }
    class Cezar3 : Cezar
    {
        public Cezar3(string plaintext) : base(plaintext, 3)
        {

        }

    }

    class ROT13 : Cezar
    {
        public ROT13(string plaintext) : base(plaintext,13)
        {

        }
    }

    class SimpleSubstitution : AlgoritmSimetric
    {
        static List<char> plaintextAlphabet = new List<char>();
        static List<char> ciphertextAlphabet = new List<char>();
        public SimpleSubstitution(string cod, string key)
        {
            this.plaintext = cod;
            this.ciphertext = Criptare(cod, key);
        }

        public string Criptare(string cod, string key)
        {
            CipherText(key);
            string result = "";

            foreach(char i in cod)
            {
                if (i >= 'a' && i <= 'z')
                    result += ciphertextAlphabet[plaintextAlphabet.IndexOf(i)];
                else
                {
                    if (i >= 'A' && i <= 'Z')
                        result += (char)(ciphertextAlphabet[plaintextAlphabet.IndexOf((char)(i + 32))] - 32);
                    else
                        result += i;
                }
            }
            Console.WriteLine(result);
            return result;
        }
        public void CipherText(string key)
        {
            plaintextAlphabet = new List<char>("abcdefghijklmnopqrstuvwxyz");
            ciphertextAlphabet = new List<char>(key);
            plaintextAlphabet.RemoveAll(i => key.Contains(i));
            ciphertextAlphabet.AddRange(plaintextAlphabet);
            plaintextAlphabet = new List<char>("abcdefghijklmnopqrstuvwxyz");
            //foreach (var i in ciphertextAlphabet)
            //{
            //    Console.Write(i);
            //}
            //Console.WriteLine();
        }

    }
}
