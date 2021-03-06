using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int[] array = new int[] { 1, 2, 3, 5, 6, 11, 12, 13, 14, 22, 23, 33, 44, 55, 554 };
            int[] evenArray = GetFiltered(array, (num) => num % 2 == 0);
            int[] notEvenArray = GetFiltered(array, (num) => num % 2 != 0);
            int[] has3Array = GetFiltered(array, (num) => num.ToString().Contains("3"));
            int[] hasSameNumberArray = GetFiltered(array, (num) =>
            {
                string numToString = num.ToString();
                if (numToString.Length == 1)
                    return true;
                else
                    for (int i = 0; i < numToString.Length - 1; i++)
                    {
                        if (!(numToString[i] == numToString[i + 1]))
                            return false;
                    }
                return true;
            });

            Console.WriteLine("Original array items:");
            Print(array);
            Console.WriteLine("\n********************");
            Console.WriteLine("Even array items:");
            Print(evenArray);
            Console.WriteLine("\n********************");
            Console.WriteLine("Not even array items:");
            Print(notEvenArray);
            Console.WriteLine("\n********************");
            Console.WriteLine("Has 3 array items:");
            Print(has3Array);
            Console.WriteLine("\n********************");
            Console.WriteLine("Has same number array items:");
            Print(hasSameNumberArray);
            Console.WriteLine("\n********************");
        }
        private static int[] GetFiltered(int[] arr, Func<int, bool> filter)
        {
            int[] newArray = new int[0];
            foreach (int number in arr)
            {
                if (filter(number))
                {
                    Array.Resize(ref newArray, newArray.Length + 1);
                    newArray[(newArray.Length - 1)] = number;
                }
            }
            return newArray;
        }
            static void Print(int[] num)
            {
                Console.WriteLine(String.Join(",", num));
            }
        //delegate bool Del(int num);
        //delegate bool Filtered(int[] num, Del filtered);
        //delegate bool Prt(int[] str);
    }
}
