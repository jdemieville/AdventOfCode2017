using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha
{
    class Program
    {
        static void Main(string[] args)
        {
            //Captcha Day 1
            //sum digits that have duplicates in sequence; circular
            //ex: 1122 --> 1 + 2 = 3
            //1111 --> 1 + 1 + 1 + 1 = 4
            // 1234 --> 0
            //91212129 --> 9
            //assumption that numbers are 1-9 only; 0 will add nothing to sum

            //Console.WriteLine("Enter captcha: ");
            string captcha = "";
            string input = "";
            int[] captchaArray = new int[] { };
            int sum = 0;

            using (StreamReader sr = new StreamReader(@"C:\Users\bianc\Desktop\AdventofCode\Captcha\CapCode.txt"))
            {
                while ((input = sr.ReadLine()) != null)
                {
                    captcha += input; //string modification, memory allocation heavy
                }
            }

            captchaArray = captcha.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray(); //convert string to array of integers

            for (int pos = 0; pos < captchaArray.Length - 1; pos++)
            {
                if (captchaArray[pos] == captchaArray[pos + 1]) //if current value = next value, add value to sum
                {
                    sum += captchaArray[pos];
                }
            }


            if (captchaArray[0] == captchaArray[captchaArray.Length-1]) //if first value = last, add to sum, outside of loop as only 1 test needed
            {
                sum += captchaArray[0];
            }

            //O(n) algorithmic efficiency, each element inspected once

            Console.WriteLine($"First value is {captchaArray[0]}");
            Console.WriteLine($"Last value is {captchaArray[captchaArray.Length-1]}");
            Console.WriteLine($"The solution is {sum}");
            Console.ReadLine();
        }
    }
}
