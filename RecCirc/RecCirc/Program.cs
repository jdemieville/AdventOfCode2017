using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RecCirc
{
    class Program
    {
        static void Main(string[] args)
        {
            //weighted graph 
            //read parent node, weight sep by space and ()
            //child nodes sep by space and ->, each child sep by comma
            //search graph to find parent node that is not a child (bottom)
            //dictionary implementation with parent node as key, weights and child nodes as value

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            
            //string test = @"C:\Users\bianc\Desktop\AdventofCode\RecCirc\test.txt";
            string input = @"C:\Users\bianc\Desktop\AdventofCode\RecCirc\input.txt";
            string line = "";
            string trimLine = "";
            string strKey = "";
            List<string> parent = new List<string>();
            List<string> child = new List<string>();
            char[] splitChar = {'(', ')', '-', '>', ',',};

            using (StreamReader sr = new StreamReader(input))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> value = new List<string>();
                    string[] strLine = new string[(line.Length - 1)];
                    trimLine = line.Replace(" ", string.Empty);
                    strLine = trimLine.Split(splitChar);

                    foreach (var ch in strLine)
                    {
                        if (ch != "")
                        {
                            value.Add(ch); //add stripped down values to list
                        }
                    }

                    //foreach (var c in value)
                    //{
                    //    Console.Write($"Line {c} ");
                    //    Console.WriteLine();

                    //}

                    //Console.WriteLine(value.Count);

                    strKey = value[0];
                    value.RemoveAt(0);

                    graph.Add(strKey, value);

                    //Console.WriteLine();
                }
            }
            foreach(var item in graph)
            {
                Console.WriteLine("Item:");
                Console.Write($"{item.Key}");
                if (item.Value.Count > 1) //more than 1 indicates children nodes, 1st value is weight
                {
                    Console.WriteLine(" is a parent node.");
                    parent.Add(item.Key); //those with children nodes, added to parent list
                    foreach (var kVal in item.Value)
                    {
                        Console.Write($" {kVal}");
                        child.Add(kVal);

                    }
                }
                
                Console.WriteLine();
            }

            var top = parent.Except(child);
            
            foreach (var element in top)
            {
                Console.Write($"Top is {element}");
            }

            Console.ReadLine();
        }
    }
}
