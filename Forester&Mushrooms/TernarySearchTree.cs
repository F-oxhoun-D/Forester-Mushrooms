namespace Forester_Mushrooms
{
    internal class TernarySearchTree<T>(T node)
    {
        public Node<T> Root { get; set; } = new(node);

        public Node<T> Insert(T element, string pathToInsertTheNode) // вставка
        {
            Root = TraversTheTreeToInsertElement(Root, element, pathToInsertTheNode);

            return Root;
        }

        private static Node<T> TraversTheTreeToInsertElement(Node<T> node, T element, string pathToInsertTheNode)
        {
            int positionOfTheElementToInsert = 0;
            bool checkOnInsert = false;
            while(!checkOnInsert)
            {
                if (positionOfTheElementToInsert == pathToInsertTheNode.Length - 1)
                {
                    if (pathToInsertTheNode[positionOfTheElementToInsert] == '1')
                        node.Left = new(element);
                    else if (pathToInsertTheNode[positionOfTheElementToInsert] == '2')
                        node.Eq = new(element);
                    else
                        node.Right = new(element);

                    return node;
                }

                if (pathToInsertTheNode[positionOfTheElementToInsert] == '1')
                    node.Left = TraversTheTreeToInsertElement(node.Left, element,
                        pathToInsertTheNode.Substring(positionOfTheElementToInsert + 1, pathToInsertTheNode.Length - 1 - positionOfTheElementToInsert));
                else if (pathToInsertTheNode[positionOfTheElementToInsert] == '2')
                    node.Eq = TraversTheTreeToInsertElement(node.Eq, element,
                        pathToInsertTheNode.Substring(positionOfTheElementToInsert + 1, pathToInsertTheNode.Length - 1 - positionOfTheElementToInsert));
                else
                    node.Right = TraversTheTreeToInsertElement(node.Right, element,
                        pathToInsertTheNode.Substring(positionOfTheElementToInsert + 1, pathToInsertTheNode.Length - 1 - positionOfTheElementToInsert));
                checkOnInsert = true;
            }

            return node;
        }

        /*public bool Search(string word) // поиск
        {
            if (string.IsNullOrEmpty(word))
                return false;

            return SearchHelper(root, word, 0);
        }*/

        /*private static bool SearchHelper(Node<T> node, string word,
                                  int index)
        {
            if (node == null)
                return false;

            if (word[index] < node.data)
            {
                return SearchHelper(node.left, word, index);
            }
            else if (word[index] > node.data)
            {
                return SearchHelper(node.right, word, index);
            }
            else
            {
                if (index == word.Length - 1)
                {
                    return node.isEndOfString;
                }
                else
                {
                    return SearchHelper(node.eq, word,
                                        index + 1);
                }
            }
        }*/

        public void Traverse() // обход
        {
            TraverseHelper(Root, "");
        }

        private static void TraverseHelper(Node<T> node, string buffer)
        {
            if (node == null)
                return;

            TraverseHelper(node.Left, buffer);

            buffer += node.data;

            if (node.isEndOfString)
            {
                Console.WriteLine(buffer);
            }

            TraverseHelper(
                node.Eq, buffer[..^1]
                             + node.data);

            TraverseHelper(
                node.Right,
                buffer[..^1]);
        }
    }
}
