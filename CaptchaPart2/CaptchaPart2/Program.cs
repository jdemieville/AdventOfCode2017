using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptchaPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Captcha Day 1b
            //sum digits that have duplicates in half way in line; circular
            //ex: 1212 --> length = 4, mid = 2, duplicates 2 steps ahead, 6
            //1221 --> 0
            //123425 --> 4
            //123123 --> 12
            //12141415 --> 4
            //assumption that numbers are 1-9 only; 0 will add nothing to sum

            //Console.WriteLine("Enter captcha: ");
            string captcha = "";
            string input = "";
            int[] captchaArray = new int[] { };
            int checkPos = 0;
            int sum = 0;

            using (StreamReader sr = new StreamReader(@"C:\Users\bianc\Desktop\AdventofCode\CaptchaPart2\CapCode.txt"))
            {
                while ((input = sr.ReadLine()) != null)
                {
                    captcha += input;
                }
            }

            captchaArray = captcha.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray(); //convert string to array of integers

            //test code
            //captcha = Console.ReadLine();
            //captchaArray = captcha.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            //foreach (int num in captchaArray)
            //{
            //    Console.WriteLine(num);
            //}


            for (int pos = 0; pos < captchaArray.Length; pos++)
            {
                if ((pos + (captchaArray.Length/2)) >= captchaArray.Length) //check if position to check is at beginning of array
                {
                    checkPos = ((captchaArray.Length / 2) - (captchaArray.Length - pos)); //midpoint minus remainder minus 1 for array positioning
                }
                else
                {
                    checkPos = pos + (captchaArray.Length / 2);
                }

                if (captchaArray[pos] == captchaArray[(checkPos)]) //if current value = next value, add value to sum
                {
                    sum += captchaArray[pos];
                }
            }


            Console.WriteLine($"First value is {captchaArray[0]}");
            Console.WriteLine($"Last value is {captchaArray[captchaArray.Length - 1]}");
            Console.WriteLine($"The solution is {sum}");
            Console.ReadLine();
        }
    }
    }
