namespace Forester_Mushrooms
{
    public class Node<T>
    {
        public T data;

        public bool isEndOfString;

        public Node<T> Left { get; set; }

        public Node<T> Eq { get; set; }

        public Node<T> Right { get; set; }

        public Node(T data)
        {
            this.data = data;
            isEndOfString = false;
            Left = Eq = Right = null!;
        }
    }
}
