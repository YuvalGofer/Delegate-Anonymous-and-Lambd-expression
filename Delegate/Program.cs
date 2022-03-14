//
delegate bool Del(int num);
public class DelegatePractice
{
    public static void Main()
    {
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
    static bool IsEven(int number)
    {
        return (number % 2 == 0);
    }
    static bool IsNotEven(int number)
    {
        return (!IsEven(number));
    }
    static bool Has3(int number)
    {
        string has3 = number.ToString();
        foreach (int i in has3)
        {
            if (i == '3')
                return true;
        }
        return false;
    }
    static bool HasSameNumberSequance(int number)
    {
        string numToString = number.ToString();
        if (numToString.Length == 1)
            return true;
        else
            for (int i = 0; i < numToString.Length - 1; i++)
            {
                if (!(numToString[i] == numToString[i + 1]))
                    return false;
            }
        return true;
    }
    private static int[] GetFiltered(int[] arr, Del filter)
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
}

















