using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighEntropy
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            int invalid = 0;
            string path = @"C:\Users\bianc\Desktop\AdventofCode\HighEnt\input.txt";
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
                        Console.Write($"{word} ");

                        if (passHash.Contains(word)) //if hashset contains word; iterate invalid and break out of loop
                        {
                            Console.WriteLine($"Contains {word}");
                            invalid++;
                            break;
                        }
                        else //if new word, add to hashset
                        {
                            passHash.Add(word);
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
