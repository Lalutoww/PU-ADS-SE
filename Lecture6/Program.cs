namespace Lecture6;

class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int> binaryTree = new BinaryTree<int>(5, new BinaryTree<int>(1), new BinaryTree<int>(6));
        int targetElement = 5;
        binaryTree.Add(4);
        Console.WriteLine();
    }
}