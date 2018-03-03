using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMemory
{
    class Program
    { 

        static void Main(string[] args)
        {
            //spiral pattern
            //track position of mid, subtract position of number in question

            int userNum = int.Parse(Console.ReadLine());
            int count = userNum;
            int root = (int)Math.Round(Math.Sqrt(userNum));
            int start = root - ((root * root) - userNum); //number to start on in row, addresses column element

            int maxRow = root;
            int minRow = 1;
            int currentRow = maxRow;
            int maxColumn = root;
            int minColumn = 1;
            int currentColumn = start;

            int checkValue = 1;
            int distance = 0;
            int[] oneLoc = new int[2];
            int[] searchLoc = new int[2];

            IDictionary<int, int[]> spiral = new Dictionary<int, int[]>(); //count as key value, int 1 is column (x), int 2 is row (y)

            spiral.Add(count, new int[] {currentColumn, currentRow});
            count--;
            currentColumn--;

            while (count != 0)
            {
                while (currentColumn >= minColumn) //go left
                {
                    spiral.Add(count, new int[] { currentColumn, currentRow });
                    count--;
                    currentColumn--;
                }

                currentColumn = minColumn;
                currentRow--; //move to row above
                maxRow--; //bottom row complete

                while (currentRow >= minRow) //go up
                {
                    spiral.Add(count, new int[] { currentColumn, currentRow });
                    count--;
                    currentRow--;
                }
                currentRow = minRow;
                currentColumn++; //move to right column
                minColumn++; //left column complete

                while (currentColumn <= maxColumn) //go right
                {
                    spiral.Add(count, new int[] { currentColumn, currentRow });
                    count--;
                    currentColumn++;
                }

                currentColumn = maxColumn;
                currentRow++; //move to row below
                minRow++; //top row complete

                while (currentRow <= maxRow) //go down
                {
                    spiral.Add(count, new int[] { currentColumn, currentRow });
                    count--;
                    currentRow++;
                }

                currentRow = maxRow;
                currentColumn--; //move to left column
                maxColumn--; //right column complete
            }

            foreach (var num in spiral)
            {
                Console.WriteLine($"Count: {num.Key}; Column: {num.Value[0].ToString()}; Row: {num.Value[1].ToString()}");
            }


            Console.WriteLine("Enter number to check distance from 1");
            checkValue = int.Parse(Console.ReadLine());            
            
            if (checkValue > userNum)
            {
                Console.WriteLine("Number not in spiral.");
            }
            else
            {
                oneLoc = spiral[1];
                searchLoc = spiral[checkValue];

                if (searchLoc[1] >= oneLoc[1])
                {
                    distance = searchLoc[1] - oneLoc[1];
                }
                else
                {
                    distance = oneLoc[1] - searchLoc[1];
                }
                
                if (searchLoc[0] >= oneLoc[0])
                {
                    distance += searchLoc[0] - oneLoc[0];
                }
                else
                {
                    distance += oneLoc[0] - searchLoc[0];
                }
                
            }

            Console.WriteLine($"Distance is {distance}");

            Console.ReadLine();

        }

       
    }
}
