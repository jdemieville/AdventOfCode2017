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
            int round = 1;
            bool cont = true; //boolean for initial allocation, ends with 1st duplicate value
            bool cycle = true; //boolean to count length of cycle for duplicate value
            string strList = "";
            string finalStr = "";

            memory.Add(input.ToString());
            List<int> newMem = new List<int> (input);

            while (cont == true)
            {
                largest = lgPos(newMem);
                newMem = redistMem(newMem, largest);
                timesRedis++;

                Console.WriteLine($"Largest {largest}"); 

                foreach (var val in newMem) //append each value to string (memory allocation heavy, but allows better utilization of hashset)
                {
                    //Console.WriteLine(val); //test print
                    strList += val;
                }
                
                Console.WriteLine($"{strList}");

                //Console.WriteLine(memory.Contains(strList)); 
                if (memory.Contains(strList)) //check if string in hashset, if not add to hashset, if so end loop and get final string for cycle compare
                {
                    cont = false;
                    finalStr = strList;
                }
                else
                {
                    memory.Add(strList);
                    strList = "";
                }
            }

            while (cycle == true)
            {
                strList = "";
                largest = lgPos(newMem);
                newMem = redistMem(newMem, largest);
                foreach (var val in newMem)
                {
                    //Console.WriteLine(val); //test print
                    strList += val;
                }
                Console.WriteLine($"Final str {finalStr}, strlist {strList}");

                if (finalStr == strList) //check final string value with string created, if matches end loop, if not add to cycle count
                {
                    cycle = false;
                }
                else
                {
                    round++;
                }
            }

            Console.WriteLine($"Redistributed {timesRedis} times. Cycle is {round}");
            Console.ReadLine();
        }

        static List<int> redistMem(List<int> oldList, int pos)
        {
            List<int> newList = new List<int>(oldList);
            int value = oldList[pos]; //largest value
            int currentPos = pos; //starting at position of largest value
            newList[pos] = 0; //zero value start position
            
            while (value > 0) 
            {
                if (currentPos < newList.Count-1) //loop through list
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
            int pos = mem.IndexOf(mem.Max()); //position of largest element

            return pos;
        }
    }
}
