using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ChecksumB
{
    class Program
    {
        static void Main(string[] args)
        {
            //open excel doc
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWork = xlApp.Workbooks.Open(@"C:\Users\bianc\Desktop\AdventofCode\ChecksumPart2\inputCheck.xlsx");
            Excel._Worksheet xlSheet = xlWork.Sheets[1];
            Excel.Range xlRange = xlSheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            int sum = 0;

            int[,] xlData = new int[rowCount, colCount];

            //fill array with excel data
            for (int rowIter = 1; rowIter <= rowCount; rowIter++)
            {

                for (int colIter = 1; colIter <= colCount; colIter++)
                {
                    if (xlRange.Cells[rowIter, colIter] != null && xlRange.Cells[rowIter, colIter].Value2 != null)
                    {
                        xlData[rowIter - 1, colIter - 1] = (int)xlRange[rowIter, colIter].Value2;
                        Console.Write(xlData[rowIter - 1, colIter - 1]);           
                    }
                }

                Console.WriteLine();
            }

            //compare values, checks foward values only to prevent unnecessary checks
            for (int rowPos = 0; rowPos < rowCount; rowPos++)
            {
                for (int colPos = 0; colPos < colCount - 1; colPos++)
                {
                    for (int secCol = colPos + 1; secCol < colCount; secCol++)
                    {
                        Console.WriteLine($"First num = {xlData[rowPos, colPos]}, Sec num = {xlData[rowPos, secCol]}");
                        if (((xlData[rowPos, colPos]) % (xlData[rowPos, secCol])) == 0) //if current value divides evenly into following value in row, add result of division to sum
                        {
                            sum += ((xlData[rowPos, colPos]) / (xlData[rowPos, secCol]));
                            Console.WriteLine($"Sum is {sum}, part 1, row {rowPos}, col {xlData[rowPos, colPos]}, 2 col {xlData[rowPos, secCol]}");
                        }

                        if (((xlData[rowPos, secCol]) % (xlData[rowPos, colPos])) == 0) //if second value divides evenly into current value in row, add to result of division to sum
                        {
                            sum += ((xlData[rowPos, secCol]) / (xlData[rowPos, colPos]));
                            Console.WriteLine($"Sum is {sum}, part 2, row {rowPos}, col {xlData[rowPos, colPos]}, 2 col {xlData[rowPos, secCol]}");
                        }
                    }
                    
                    Console.WriteLine($"Current sum is {sum}");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Final sum is {sum}");

            Console.ReadLine();

            //close excel
            xlWork.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlSheet);
            Marshal.ReleaseComObject(xlWork);
            Marshal.ReleaseComObject(xlApp);
            }
        }
    }
