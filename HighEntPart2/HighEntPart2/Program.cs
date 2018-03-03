using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighEntPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            int invalid = 0;
            string sortWord = "";
            string path = @"C:\Users\bianc\Desktop\AdventofCode\HighEntPart2\input.txt";
            List<string> passphrases = new List<string>();
            HashSet<string> passHash = new HashSet<string>();

            using (StreamReader reader = File.OpenText(path))
            {
                string entry = "";

                while ((entry = reader.ReadLine()) != null)
                {
                    passHash.Clear(); //empty hashset for next passphrase
                    total++; //track number of passphrases
                    Console.WriteLine($"Word #{total}");
                    passphrases = (entry.Split(null).ToList()); //split line into list by spaces

                    foreach (var word in passphrases)
                    {
                        char[] letters = word.ToCharArray();
                        Array.Sort(letters); //sort letters
                        sortWord =  new string (letters);               

                        Console.Write($"{sortWord} ");

                        if (passHash.Contains(sortWord)) //if hashset contains word; iterate invalid and break out of loop
                        {
                            Console.WriteLine($"Contains {sortWord}");
                            invalid++;
                            break;
                        }
                        else //if new word, add to hashset
                        {
                            passHash.Add(sortWord);
                        }

                    }

                }

            }
            Console.WriteLine();

            Console.WriteLine($"Total passphrases = {total}; Invalid = {invalid}; Valid = {total - invalid}");

            Console.ReadLine();
        }
    }
}
