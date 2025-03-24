namespace HW2;

class Program
{

    static void Main(string[] args)
    {
        /* 1. Да се състави програма, чрез която се въвеждат 9 реални числа от интервала [-99.99..99.99].
           Проверете дали въведената редица е монотонно нарастваща.
           Пример: 1 2 3 3 е, но 1 3 2 4 не е монотонно нарастваща
           Използвайте рекурсия */
        Console.WriteLine("----------TASK 1----------");
        TaskOne.Run();

        /* 2. Да се състави програма, чрез която се въвежда естествено число N от интервала [10..100010].
           Програмата да извежда най-близкото по-голямо просто число.
           Пример: 98 Изход 101 */
        
        Console.WriteLine("----------TASK 2----------");
        TaskTwo.Run();

        /* Да се състави програма, чрез която се въвежда естествено число N от интервала [10..10010] и се извежда сумата на цифрите му.
           Пример: 15 Изход: 6
           Използвайте рекурсия. */

        Console.WriteLine("----------TASK 3----------");
        TaskThree.Run();
    }
}

internal static class TaskOne
{
    public static void Run()
    {
        double[] numbers = FillArray();
        Console.WriteLine(CheckIncreasingOrder(0, numbers));
    }

    private static bool CheckIncreasingOrder(int index, double[] numbers)
    {
        if (index == numbers.Length - 1)
        {
            return true;
        }

        if (numbers[index] > numbers[index + 1])
        {
            return false;
        }

        bool isIncreasing = CheckIncreasingOrder(index + 1, numbers);

        return isIncreasing;
    }

    private static double[] FillArray()
    {
        double[] array = new double[10];
        int index = 0;

        Console.WriteLine("Please keep in mind numbers must be in range [-99.99..99.99]");
        foreach (double num in array)
        {
            while (true)
            {
                double number;
                Console.Write("Enter number: ");
                if (Double.TryParse(Console.ReadLine(), out number))
                {
                    if (number <= -100 || number >= 100)
                    {
                        Console.WriteLine("Number out of bounds! Interval is: [-99.99..99.99]");
                        continue;
                    }
                    else
                    {
                        array[index++] = number;
                        break;
                    }
                }

                Console.WriteLine("Invalid number! Please enter a valid real number!");
            }
        }

        return array;
    }
}

internal static class TaskTwo
{
    public static void Run()
    {
        int number = TaskUtils.GetNumber();
        Console.WriteLine("Next prime number is: " + FindNextPrime(number));
    }

    private static double FindNextPrime(int number)
    {
        int nextPrime = number + 1;
        while (!IsPrime(nextPrime))
        {
            nextPrime++;
        }

        return nextPrime;
    }

    private static bool IsPrime(int number)
    {
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}

internal static class TaskThree
{
    public static void Run()
    {
        int number = TaskUtils.GetNumber();
        Console.WriteLine(GetSumOfDigits(number));
    }

    private static int GetSumOfDigits(int number)
    {
        int sum = 0;

        foreach (char digit in number.ToString())
        {
            sum += digit - '0';
        }

        return sum;
    }
}

internal class TaskUtils()
{
    public static int GetNumber()
    {
        Console.WriteLine("Please enter below number in range [10...100010]");
        while (true)
        {
            Console.Write("Enter number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number < 10 || number > 100010)
                {
                    Console.WriteLine("Number is out of bounds! Range is [10...100010]!");
                    continue;
                }

                return number;
            }

            Console.WriteLine("Please enter a valid number!");
        }
    }
}