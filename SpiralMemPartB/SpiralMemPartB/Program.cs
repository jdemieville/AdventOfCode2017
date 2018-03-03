using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMemPartB
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

            Dictionary<int, int[]> spiral = new Dictionary<int, int[]>(); //count as key value, int 1 is column (x), int 2 is row (y), int 3 is sum

            spiral.Add(count, new int[] { currentColumn, currentRow, 0});
            count--;
            currentColumn--;

            while (count != 0)
            {
                while (currentColumn >= minColumn) //go left
                {
                    spiral.Add(count, new int[] { currentColumn, currentRow, 0});
                    count--;
                    currentColumn--;
                }

                currentColumn = minColumn;
                currentRow--; //move to row above
                maxRow--; //bottom row complete

                while (currentRow >= minRow) //go up
                {
                    spiral.Add(count, new int[] { currentColumn, currentRow, 0});
                    count--;
                    currentRow--;
                }
                currentRow = minRow;
                currentColumn++; //move to right column
                minColumn++; //left column complete

                while (currentColumn <= maxColumn) //go right
                {
                    spiral.Add(count, new int[] { currentColumn, currentRow, 0});
                    count--;
                    currentColumn++;
                }

                currentColumn = maxColumn;
                currentRow++; //move to row below
                minRow++; //top row complete

                while (currentRow <= maxRow) //go down
                {
                    spiral.Add(count, new int[] { currentColumn, currentRow, 0});
                    count--;
                    currentRow++;
                }

                currentRow = maxRow;
                currentColumn--; //move to left column
                maxColumn--; //right column complete
            }

            foreach (var num in spiral)
            {
                Console.WriteLine($"Count: {num.Key}; Column: {num.Value[0].ToString()}; Row: {num.Value[1].ToString()}, Sum: {num.Value[2].ToString()}");
            }

            spiral[1][2] = 1;
            count = 2;

            while (count < userNum)
            {
                currentColumn = spiral[count][0];
                currentRow = spiral[count][1];
                spiral[count][2] = findSum(spiral, currentColumn, currentRow);
                count++;
            }

            foreach (var num in spiral)
            {
                Console.WriteLine($"Count: {num.Key}; Column: {num.Value[0].ToString()}; Row: {num.Value[1].ToString()}, Sum: {num.Value[2].ToString()}");
            }

            Console.ReadLine();

        }

        public static int findSum(Dictionary<int, int[]> dict, int column, int row)
        {
            int result = 0;
            
            foreach (var num in dict)
            {
                if(num.Value[0] == column) //check values in same column, row+/-
                {
                    if (num.Value[1] == row + 1)
                    {
                        result += num.Value[2];
                    }

                    if (num.Value[1] == row - 1)
                    {
                        result += num.Value[2];
                    }
                }

                if (num.Value[1] == row) //check values in same row, column+/-
                {
                    if (num.Value[0] == column + 1)
                    {
                        result += num.Value[2];
                    }

                    if (num.Value[0] == column - 1)
                    {
                        result += num.Value[2];
                    }
                }

                if (num.Value[0] == column + 1)  //check values diagonal, row+/- and column+/-
                {
                    if (num.Value[1] == row + 1)
                    {
                        result += num.Value[2];
                    }

                    if (num.Value[1] == row - 1)
                    {
                        result += num.Value[2];
                    }
                }

                if (num.Value[0] == column - 1)
                {
                    if (num.Value[1] == row + 1)
                    {
                        result += num.Value[2];
                    }

                    if (num.Value[1] == row - 1)
                    {
                        result += num.Value[2];
                    }
                }

                //if (num.Value[1] == row + 1)
                //{
                //    if (num.Value[0] == column + 1)
                //    {
                //        result += num.Value[2];
                //    }

                //    if (num.Value[0] == column - 1)
                //    {
                //        result += num.Value[2];
                //    }
                //}

                //if (num.Value[1] == row - 1)
                //{
                //    if (num.Value[0] == column + 1)
                //    {
                //        result += num.Value[2];
                //    }

                //    if (num.Value[0] == column - 1)
                //    {
                //        result += num.Value[2];
                //    }
                
            }               

            return result;
        }

    }
}
        
       
