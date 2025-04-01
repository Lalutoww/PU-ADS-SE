using System.Diagnostics;
using System.Threading.Channels;

namespace HW3;

class Program
{
    static void Main(string[] args)
    {
        //1. Напишете методи за сечение и обединение на списъци.
        Console.WriteLine("------TASK ONE------");
        TaskOne.Run();

        /*  2. Напишете метод, който намира най-дългата подредица от равни числа в даден List<int> и
            връща като резултат нов List<int> със тази подредица.
        */
        Console.WriteLine("------TASK TWO------");
        TaskTwo.Run();
        
        //3. Напишете програма, която премахва всички отрицателни числа от дадена редица.
        Console.WriteLine("------TASK THREE------");
        TaskThree.Run();
    }
}

class TaskOne
{
    private static readonly List<int> ListOne = [1, 2, 2, 3];
    private static readonly List<int> ListTwo = [2, 2, 2, 3, 3];

    public static void Run()
    {
        Console.WriteLine("List One: " + String.Join(", ", ListOne));
        Console.WriteLine("List Two: " + String.Join(", ", ListTwo));
        Console.WriteLine("Union: " + String.Join(", ", (Union(ListOne, ListTwo))));
        Console.WriteLine("Intersection: " + String.Join(", ", (Intersection(ListOne, ListTwo))));
    }

    private static HashSet<int> Union(List<int> listOne, List<int> listTwo)
    {
        HashSet<int> union = new HashSet<int>(listOne);

        foreach (int number in listTwo)
        {
            union.Add(number);
        }

        return union;
    }

    private static HashSet<int> Intersection(List<int> listOne, List<int> listTwo)
    {
        HashSet<int> set = new HashSet<int>(listOne);
        HashSet<int> intersection = new HashSet<int>();


        foreach (int number in listTwo)
        {
            if (set.Contains(number))
            {
                intersection.Add(number);
            }
        }


        return intersection;
    }
}

class TaskTwo
{
    private static readonly List<int> ListOne = [1, 3, 2, 2, 2, 2, 5, 5, 5, 5, 5, 3, 3, 3];

    public static void Run()
    {
        Console.WriteLine("Biggest sequence is: " + String.Join(", ", FindBiggestSequence(ListOne)));
    }

    private static List<int> FindBiggestSequence(List<int> listOne)
    {
        int maxLength = 0;
        int maxStartIndex = 0;

        for (int i = 0; i < listOne.Count - 1; i++)
        {
            if (listOne[i] == listOne[i + 1])
            {
                int currentLength = 1;

                for (int j = i; j < listOne.Count - 1; j++)
                {
                    if (listOne[j] == listOne[j + 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxStartIndex = i;
                }
            }
        }

        return listOne.GetRange(maxStartIndex, maxLength);
    }
}

class TaskThree
{
    private static readonly List<int> ListOne = [1, 2, 3, 4, -5, -6, 7, 8, -9, 10, -11, -12, 13, -14, 15];

    public static void Run()
    {
        Console.WriteLine("List With no negative numbers is: " + String.Join(", ", GetOnlyPositiveNumbers(ListOne)));
    }

    private static List<int> GetOnlyPositiveNumbers(List<int> list)
    {
        return list.Where(x => x >= 0).ToList();
    }
}