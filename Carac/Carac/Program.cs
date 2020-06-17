using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Http;

namespace Carac
{
    class Program
    {
        static void Main(string[] args)
        {
            // for (int con = 0; con < 2; con++)
            //{
            string value;

            Console.WriteLine("Introduce una letra");
            value = Console.ReadLine();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(value);

            // int i = BitConverter.ToInt32(asciiBytes, 0);

            // string str = Encoding.UTF8.GetString(asciiBytes, 0, asciiBytes.Length);
            //str = Convert.ToInt32();
            if (asciiBytes[0] < 58 && asciiBytes[0] > 47)
            {
                Console.WriteLine("Es un numero");
            }
            else if ((asciiBytes[0] < 91 && asciiBytes[0] > 64) || (asciiBytes[0] < 123 && asciiBytes[0] > 96))
            {
                Console.WriteLine("Es una letra");
            }
            else if ((asciiBytes[0] < 48 && asciiBytes[0] > 31) || (asciiBytes[0] < 64 && asciiBytes[0] > 57) || (asciiBytes[0] < 97 && asciiBytes[0] > 90) || (asciiBytes[0] < 127 && asciiBytes[0] > 122))
            {
                Console.WriteLine("Es un signo de puntuacion.");
            }

            Console.WriteLine("////////////////");
            string palabra;
            string letra;
            Console.WriteLine("Introduce una palabra");
            palabra = Console.ReadLine();
            byte[] vs = Encoding.ASCII.GetBytes(palabra);

            Console.WriteLine("Introduce una letra");
            letra = Console.ReadLine();
            byte[] vs1 = Encoding.ASCII.GetBytes(letra);

            if (vs.Contains(vs1[0])) 
            {
                Console.WriteLine("La letra se encuentra en la palabra");
            }
            else { Console.WriteLine("No se encuentra la letra"); }

            Console.WriteLine("////////////////");
            string regexp = @"(\d{3})-(\d{3}-\d{4})";
            string codarea; 
            Console.WriteLine("Digite su numero de telefono");
            codarea = Console.ReadLine();
            MatchCollection matches = Regex.Matches(codarea, regexp);
            foreach (Match match in matches)
            {
                Console.WriteLine("Codigo de area: {0}", match.Groups[1].Value);
                Console.WriteLine("Numero de telefono: {0}", match.Groups[2].Value);
                Console.WriteLine();
            }

            Console.WriteLine("/////////////");
            Console.WriteLine("Digite la palabra a buscar");
            string pal = Console.ReadLine();
            Console.WriteLine("Digite o copie el texto");
            string texto = Console.ReadLine();            
            bool rgx = Regex.IsMatch(texto, @"(\s)" + Regex.Escape(pal) + @"(\s)");

            if (rgx == true) 
            {
                Console.WriteLine("La palbra se encuentra");             
            }
            else { Console.WriteLine("La palabra no se encuentra"); }

            string[] a =texto.Split(' ') ;
            int contar = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (pal.Equals(a[i]))
                {
                    contar++;
                }
            }
            Console.WriteLine("La palabra se encuentra {0} veces", contar);

            Console.WriteLine("El texto tiene {0} palabras", a.Length);
            int vocal=0;
            int consonante=0;
            
            byte[] asci = Encoding.ASCII.GetBytes(texto);
            for (int i = 0; i < asci.Length; i++)
            {
                
               if (asci[i].Equals(101 | 105 | 111 | 117 | 125 | 141 | 145 | 151 | 157 | 165))
                {
                    vocal++;
                }
                else if ((asci[i] < 105 && asci[i] > 101) | (asci[i] < 111 && asci[i] > 105) | (asci[i] < 111 && asci[i] > 105) | (asci[i] < 117 && asci[i] > 111) | (asci[i] < 125 && asci[i] > 117) | (asci[i] < 145 && asci[i] > 141) | (asci[i] < 151 && asci[i] > 145) | (asci[i] < 157 && asci[i] > 151) | (asci[i] < 165 && asci[i] > 157))
                {
                    consonante++;
                }
                Console.WriteLine("El texto contiene {0} vocales", vocal);
                Console.WriteLine("El texto contiene {0} consonantes", consonante);
            }

        }
    }
}
