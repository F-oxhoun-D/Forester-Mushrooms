namespace Forester_Mushrooms
{
    public class Node
    {
        public char data;

        public Node Left { get; set; }

        public Node Eq { get; set; }

        public Node Right { get; set; }

        public Node(char data)
        {
            this.data = data;
            Left = Eq = Right = null!;
        }
    }
}
