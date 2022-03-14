using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var IsEven = delegate (int num)
            {
                return (num % 2 == 0);
            };

            var IsNotEven = delegate (int num)
             {
                 return (!IsEven(num));
             };

            var Has3 = delegate (int num)
            {
                return num.ToString().Contains("3");
            };

            var HasSameNumberSequance = delegate (int num)
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
            };

            //
            int[] array = new int[] { 1, 2, 3, 5, 6, 11, 12, 13, 14, 22, 23, 33, 44, 55, 554 };
            int[] evenArray = GetFiltered(array, IsEven);
            int[] notEvenArray = GetFiltered(array, IsNotEven);
            int[] has3Array = GetFiltered(array, Has3);
            int[] hasSameNumberArray = GetFiltered(array, HasSameNumberSequance);

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
        static void Print(int[] str)
        {
            Console.WriteLine(String.Join(",", str));
        }
    }
}
