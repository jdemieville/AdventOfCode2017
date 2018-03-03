using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemReallocHash
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int> { 0, 2, 7, 0 };
            List<int> input = new List<int> { 11, 11, 13, 7, 0, 15, 5, 5, 4, 4, 1, 1, 7, 1, 15, 11 };
            //HashSet<List<int>> memory = new HashSet<List<int>>(); //altered to store strings instead to save on computational time, string builder not great for space efficiency
            HashSet<string> memory = new HashSet<string>();
            int largest = 0;
            int timesRedis = 0;
            bool cont = true;
            string strList = "";

            memory.Add(input.ToString());
            List<int> newMem = new List<int> (input);

            while (cont == true)
            {
                largest = lgPos(newMem);
                newMem = redistMem(newMem, largest);
                timesRedis++;

                Console.WriteLine($"Largest {largest}");
                foreach (var val in newMem)
                {
                    Console.WriteLine(val);
                    strList += val;
                }
                
                Console.WriteLine($"{strList}");

                Console.WriteLine(memory.Contains(strList));
                if (memory.Contains(strList))
                {
                    cont = false;
                }
                else
                {
                    memory.Add(strList);
                    strList = "";
                }

                //foreach (var li in memory.ToList())
                //{
                //    strList = li.ToString();

                //    Console.WriteLine($"Sequence equal: {li.SequenceEqual(newMem)}");
                //    if (li.SequenceEqual(newMem))
                //    {
                //        cont = false;
                //        break;
                //    }
                //    else
                //    {
                //        memory.Add(newMem.ToList());
                //    }
                //}

            }

            Console.WriteLine($"Redistributed {timesRedis} times.");
            Console.ReadLine();
        }

        static List<int> redistMem(List<int> oldList, int pos)
        {
            List<int> newList = new List<int>(oldList);
            int value = oldList[pos];
            int currentPos = pos;
            newList[pos] = 0;
            
            while (value > 0)
            {
                if (currentPos < newList.Count-1)
                {
                    currentPos++;
                }
                else
                {
                    currentPos = 0;
                }

                newList[currentPos] += 1;
                value--;
            }

            return newList;
        }

        static int lgPos(List<int> mem)
        {
            int pos = mem.IndexOf(mem.Max());

            return pos;
        }
    }
}
