using System;
using System.Collections.Generic;
using System.Linq;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task One:");
            /* 1. Да се създаде програма за работа с масив от реални числа, в която след въвеждане на цяло положително число N (N<20) чрез функции се реализира следното:
               -въвеждане на елементите на масива, N на брой;
               -намиране на сумата на първите N елементa. */

            TaskOne.PrintResult();


            Console.WriteLine("Task Two:");
            /* 2. Да се въведат в целочислен масив n на брой случайни положителни двуцифрени числа 
             и да се намери числото, което се среща най-често в масива и колко пъти се среща. */

            TaskTwo.PrintResult();

            Console.WriteLine("Task Three:");
            /* 3. Една квадратна таблица от числа се нарича магически квадрат, когато е изпълнено следното условие: 
               - всички суми, получени поотделно от сбора на елементите по всеки ред/всеки стълб/всеки от двата диагонала са равни.
               - Да се състави програма, която въвежда естествени числа от интервала [1..20] в дадена квадратна таблица
                и определя дали те образуват магически квадрат. */

            TaskThree.PrintResult();


        }
        public class TaskOne
        {
            public static void PrintResult()
            {
                int n = TaskUtils.GetNumber(1, 19);
                double[] arr = FillArray(n);
                Console.WriteLine("Enter amount of numbers to sum:");
                int amountOfNumbersToSum = TaskUtils.GetNumber(1, arr.Length);
                double sum = arr.Take(amountOfNumbersToSum).Sum();
                Console.WriteLine("Sum is: " + sum);
            }

            private static double[] FillArray(int n)
            {
                double[] arr = new double[n];

                for (int i = 0; i < n; i++)
                {
                    while (true)
                    {
                        Console.Write($"Enter number {i + 1}: ");
                        if (double.TryParse(Console.ReadLine(), out arr[i]))
                        {
                            break;
                        }
                        Console.WriteLine("Invalid input! Please enter a valid real number.");
                    }
                }
                return arr;
            }
        }

        public class TaskTwo
        {
            public static void PrintResult()
            {
                int n = TaskUtils.GetNumber(1,100);
                int[] arr = GenerateRandomArray(n);
                TaskUtils.PrintArray(arr);
                KeyValuePair<int, int> mostFrequent = FindMostFrequentNumber(arr);
                Console.WriteLine($"Most frequent number: {mostFrequent.Key} (occurs {mostFrequent.Value} times)");
            }

            private static int[] GenerateRandomArray(int n)
            {
                Random rnd = new Random();
                int[] arr = new int[n];

                for (int i = 0; i < n; i++)
                {
                    arr[i] = rnd.Next(10, 100);
                }

                return arr;
            }

            private static KeyValuePair<int,int> FindMostFrequentNumber(int[] arr)
            {
                Dictionary<int, int> frequency = new Dictionary<int, int>();

                foreach (int num in arr)
                {
                    if (frequency.ContainsKey(num))
                        frequency[num]++;
                    else
                        frequency[num] = 1;
                }

                KeyValuePair<int, int> mostFrequent = frequency.OrderByDescending(x => x.Value).First();
                return mostFrequent;
            }

        }

        public class TaskThree
        {
            public static void PrintResult()
            {
                int n = TaskUtils.GetNumber(1, 20);
                int[,] matrix = FillMatrix(n);  // Използваме int[,] за двумерен масив
                if (IsMagicSquare(matrix))
                {
                    Console.WriteLine("The square is a magic square.");
                }
                else
                {
                    Console.WriteLine("The square is not a magic square.");
                }
            }

            private static int[,] FillMatrix(int n)
            {
                int[,] matrix = new int[n, n];

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        while (true)
                        {
                            Console.Write($"Enter value for position ({row + 1},{col + 1}) [1..20]: ");
                            if (int.TryParse(Console.ReadLine(), out int currentValue))
                            {
                                if (currentValue >= 1 && currentValue <= 20)
                                {
                                    matrix[row, col] = currentValue;
                                    break;
                                }
                            }
                            Console.WriteLine("Invalid input! Please enter a number between 1 and 20.");
                        }
                    }
                }
                return matrix;
            }

            private static bool IsMagicSquare(int[,] matrix)
            {
                int n = matrix.GetLength(0);
                int targetSum = 0;

                // Взима сумата от първи ред, за да я използваме като целева сума
                for (int i = 0; i < n; i++)
                {
                    targetSum += matrix[0, i];
                }

                // Проверка на редовете
                for (int row = 0; row < n; row++)
                {
                    int rowSum = 0;
                    for (int col = 0; col < n; col++)
                    {
                        rowSum += matrix[row, col];
                    }
                    if (rowSum != targetSum)
                    {
                        return false; // Ако някой ред не дава целевата сума, не е магически квадрат
                    }
                }

                // Проверка на стълбовете
                for (int col = 0; col < n; col++)
                {
                    int colSum = 0;
                    for (int row = 0; row < n; row++)
                    {
                        colSum += matrix[row, col];
                    }
                    if (colSum != targetSum)
                    {
                        return false; // Ако някой стълб не дава целевата сума, не е магически квадрат
                    }
                }

                // Проверка на главния диагонал
                int mainDiagonalSum = 0;
                for (int row = 0; row < n; row++)
                {
                    mainDiagonalSum += matrix[row, row];
                }
                if (mainDiagonalSum != targetSum)
                {
                    return false; // Ако главният диагонал не дава целевата сума, не е магически квадрат
                }

                // Проверка на втория диагонал
                int secondaryDiagonalSum = 0;
                for (int row = 0; row < n; row++)
                {
                    secondaryDiagonalSum += matrix[row, n - row - 1];
                }
                if (secondaryDiagonalSum != targetSum)
                {
                    return false; // Ако втория диагонал не дава целевата сума, не е магически квадрат
                }

                // Ако всички проверки са преминати, значи е магически квадрат
                return true;
            }
        }

        public class TaskUtils
        {
            public static int GetNumber(int lowerBound, int higherBound)
            {
                int n;
                while (true)
                {
                    Console.Write($"Please enter a number [{lowerBound},{higherBound}]: ");
                    if (int.TryParse(Console.ReadLine(), out n))
                    {
                        if (n >= lowerBound && n <= higherBound)
                        {
                            return n;
                        }
                        Console.WriteLine("Number is out of bounds! Please enter a number between 1 and 19.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a valid integer.");
                    }
                }
            }

            public static void PrintArray(int[] arr)
            {
                Console.WriteLine("Generated array: " + string.Join(", ", arr));
            }

        }
    }
}
