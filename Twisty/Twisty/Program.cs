using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisty
{
    class Program
    {
        static void Main(string[] args)
        {
            //read in file, sep by new line, into arrays
            //starting at array[0], increment "head" to position dictated
            //*will need some check to ensure within array (- num in first position, future - that go beyond initial position
            //*same for beyond array limits
            //note- escaping maze via forward & backward or just forward
            //store value pointed to in array, increment value in position by one, move head to new position by previous value

            List<int> numbers = new List<int>();
            int head = 0; //indicates position pointed to in array
            int step = 0; //number of steps taken until tape exited
            int direction = 0; //direction from array
            string line = "";

            using (StreamReader reader = new StreamReader("C:/Users/bianc/Desktop/AdventofCode/Twisty/tape.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    int dir = int.Parse(line);
                    numbers.Add(dir);
                }
            }

            for (int iter = 0; iter < numbers.Count; iter++)
            {
                Console.WriteLine($"{numbers[iter]}");
            }

            while (-1 < head && head < numbers.Count) // loop continues until tape exited
            {
                direction = numbers[head]; //get direction
                numbers[head] += 1; //iterate direction in location 1

                head += direction; //add to header
                step++;
            }

            Console.WriteLine($"Maze exited after {step} steps.");
            Console.ReadLine();

        }
    }
}
