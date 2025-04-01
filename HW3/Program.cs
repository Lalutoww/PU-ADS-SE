namespace HW3;

class Program
{
    static void Main(string[] args)
    {
        /*1. Да се състави програма, чрез която се въвеждат 9 реални числа от интервала [-99.99..99.99].
           Проверете дали въведената редица е монотонно нарастваща.
           Пример: 1 2 3 3 е, но 1 3 2 4 не е монотонно нарастваща
           Използвайте рекурсия
           */

        TaskOne.Run();
    }
}

class TaskOne
{
    public static void Run()
    {
        List<double> numbers = GetNumbers();

        string output = CheckMonotonic(numbers, 0)
            ? "The array is monotonically increasing"
            : "The array is not monotonically increasing";

        Console.WriteLine(output);
    }

    private static bool CheckMonotonic(List<double> numbers, int index)
    {
        if (index >= numbers.Count - 1)
        {
            return true;
        }


        if (numbers[index] > numbers[index + 1])
        {
            return false;
        }

        return CheckMonotonic(numbers, index + 1);
    }

    private static List<double> GetNumbers()
    {
        List<double> numbers = new List<double>();

        Console.WriteLine("Fill the array with numbers in range [-99.99 ... 99.99]");
        while (numbers.Count < 5)
        {
            Console.Write("Please enter a number: ");
            double number = double.Parse(Console.ReadLine());

            if (number <= -100 || number >= 100)
            {
                Console.WriteLine("Please enter a number in range [-99.99 ... 99.99]!");
                continue;
            }

            numbers.Add(number);
        }

        return numbers;
    }
}