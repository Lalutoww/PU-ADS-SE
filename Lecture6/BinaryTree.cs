using System.Transactions;

namespace Lecture6;

public class BinaryTree<T> : IComparable<T> where T : IComparable<T>
{
    private Node<T> root;

    public BinaryTree(T element)
    {
        if (this.root != null)
        {
            Node<T> currentRoot = this.root;
            this.root = new Node<T>(element);
            this.root.parent = currentRoot;
        }
        else
        {
            this.root = new Node<T>(element);
        }
    }

    public BinaryTree(T element, BinaryTree<T>? leftTree, BinaryTree<T>? rightTree)
    {
        this.root = new Node<T>(element)
        {
            leftChild = leftTree?.root,
            rightChild = rightTree?.root
        };

        if (this.root.leftChild != null)
        {
            this.root.leftChild.parent = this.root;
        }

        if (this.root.rightChild != null)
        {
            this.root.rightChild.parent = this.root;
        }
    }

    public Node<T> BinarySearch(T targetElement)
    {
        return BinarySearchHelper(this.root, targetElement);
    }

    public void Add(T value)
    {
        BinarySearchAdd(this.root, value);
    }

    private static Node<T> BinarySearchHelper(Node<T> root, T target)
    {
        int comparison = target.CompareTo(root.element);

        if (comparison == 0)
        {
            return root;
        }
        else if (comparison < 0)
        {
            return BinarySearchHelper(root.leftChild, target);
        }
        else
        {
            return BinarySearchHelper(root.rightChild, target);
        }
    }

    private static Node<T> BinarySearchAdd(Node<T>? root, T value)
    {
        if (root == null)
        {
            return new Node<T>(value);
        }

        int comparison = value.CompareTo(root.element);

        if (comparison < 0)
        {
            root.leftChild = BinarySearchAdd(root, root.leftChild.element);
        }
        else if (comparison > 0)
        {
            root.rightChild = BinarySearchAdd(root, root.rightChild.element);
        }

        return root;
    }


    public int CompareTo(T? other)
    {
        return root.element.CompareTo(other);
    }
}