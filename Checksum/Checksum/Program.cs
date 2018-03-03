using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace Checksum
{
    class Program
    {
        static void Main(string[] args)
        {
            //open Excel doc
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWork = xlApp.Workbooks.Open(@"C:\Users\bianc\Desktop\AdventofCode\Checksum\inputCheck.xlsx");
            Excel._Worksheet xlSheet = xlWork.Sheets[1];
            Excel.Range xlRange = xlSheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            int large = 0;
            int small = 1000000000; //large value assigned to flag small values
            int diff = 0;
            int sum = 0;

            int[,] xlData = new int[rowCount, colCount]; //2 dimensional array to store excel data

            for (int rowIter = 1; rowIter <= rowCount; rowIter++) //iterate through each row
            {

                Console.WriteLine($"Current large is {large}, small is {small}"); //test output

                large = 0;
                small = 1000000000;

                for (int colIter = 1; colIter <= colCount; colIter++) //iterate through each column
                {
                    if (xlRange.Cells[rowIter, colIter] != null && xlRange.Cells[rowIter, colIter].Value2 != null) //if cell exists and contains a value
                    {
                        xlData[rowIter - 1, colIter - 1] = (int)xlRange[rowIter, colIter].Value2; //save value into 2d array (offset by 1 to account for array start of 0)
                        Console.Write(xlData[rowIter - 1, colIter - 1]); //test output

                        if (xlData[rowIter - 1, colIter - 1] > large) //if number added to array is larger than current large, replace value
                        {
                            large = xlData[rowIter - 1, colIter - 1];
                        }
                        if (xlData[rowIter - 1, colIter - 1] < small) //if number added to array is smaller than current small, replace value
                        {
                            small = xlData[rowIter - 1, colIter - 1];
                        }

                    }
                }

                Console.WriteLine($"Current small is {small}, large {large}");
                diff = large - small; //current difference
                Console.WriteLine($"Difference is {diff}");
                sum += diff; //add difference to sum
                Console.WriteLine($"Current sum is {sum}");
            }


            Console.WriteLine();
            Console.WriteLine($"Final sum is {sum}");

            //close excel file
            xlWork.Close(false, null, null);
            xlApp.Quit();

            Console.ReadLine();
        }
    }
}
