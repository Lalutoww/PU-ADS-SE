namespace Lecture6;

public class Node<T>
{
    public T element;
    public Node<T> parent;
    public Node<T> leftChild;
    public Node<T> rightChild;


    public Node(T element)
    {
        this.element = element;
    }
}