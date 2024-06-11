namespace Forester_Mushrooms
{
    public class TernarySearchTree
    {
        List<string> treeBranches = [];

        public Node Tree { get; set; }

        public TernarySearchTree(char data)
        {
            Tree = new(data);
        }

        public TernarySearchTree()
        {
            Tree = new('#');
        }

        // вставка
        public Node Insert(char element, string pathToInsertTheNode) 
        {
            Tree = TraversTheTreeToInsertElement(Tree, element, pathToInsertTheNode);

            return Tree;
        }

        // обход и вставка
        private static Node TraversTheTreeToInsertElement(Node node, char element, string pathToInsertTheNode)
        {
            int positionOfTheElementToInsert = 0;
            bool checkOnInsert = false;
            while (!checkOnInsert)
            {
                if (positionOfTheElementToInsert == pathToInsertTheNode.Length - 1)
                {
                    if (pathToInsertTheNode[positionOfTheElementToInsert] == '0')
                        node.Left = new(element);
                    else if (pathToInsertTheNode[positionOfTheElementToInsert] == '1')
                        node.Eq = new(element);
                    else
                        node.Right = new(element);

                    return node;
                }

                if (pathToInsertTheNode[positionOfTheElementToInsert] == '0')
                    node.Left = TraversTheTreeToInsertElement(node.Left, element,
                        pathToInsertTheNode.Substring(positionOfTheElementToInsert + 1,
                        pathToInsertTheNode.Length - 1 - positionOfTheElementToInsert));
                else if (pathToInsertTheNode[positionOfTheElementToInsert] == '1')
                    node.Eq = TraversTheTreeToInsertElement(node.Eq, element,
                        pathToInsertTheNode.Substring(positionOfTheElementToInsert + 1,
                        pathToInsertTheNode.Length - 1 - positionOfTheElementToInsert));
                else
                    node.Right = TraversTheTreeToInsertElement(node.Right, element,
                        pathToInsertTheNode.Substring(positionOfTheElementToInsert + 1,
                        pathToInsertTheNode.Length - 1 - positionOfTheElementToInsert));
                checkOnInsert = true;
            }

            return node;
        }

        public bool SearchByPath(string path)
        {
            return true;
        }

        public static int GetCountNumber(TernarySearchTree tree, string path) // получить номер следующего узла
        {
            int count = 0;
            Node node = tree.Tree.Left;
            if (node == null)
                return 0;
            for (int i = 0; i < path.Length + 1; i++)
            {
                if (i == 0 && i == path.Length - 1 || i == path.Length)
                {
                    if (node.Left != null)
                        count++;
                    if (node.Eq != null)
                        count++;
                    if (node.Right != null)
                        count++;
                    break;
                }
                if (i == 0)
                    continue;

                if (path[i] == '0')
                    node = node.Left;
                else if (path[i] == '1')
                    node = node.Eq;
                else
                    node = node.Right;

                if (node == null)
                    break;
            }
            return count;
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

        // обход
        public void Traverse() =>  PrintPaths(Tree, "");

        private static void PrintPaths(Node node, string path)
        {
            if (node == null) return;

            // Добавляем текущий узел к пути
            path += node.data + " ";

            // Если это листовой узел, выводим путь
            if (node.Left == null && node.Eq == null && node.Right == null)
            {
                Console.WriteLine(path);
                return;
            }

            // Рекурсивно обходим левое, среднее и правое поддеревья
            PrintPaths(node.Left!, path);
            PrintPaths(node.Eq!, path);
            PrintPaths(node.Right!, path);
        }

        public List<string> GetBranches() => GetPaths(Tree, "");

        private List<string> GetPaths(Node node, string path)
        {
            if (node == null) return treeBranches;

            // Добавляем текущий узел к пути
            path += node.data + " ";

            // Если это листовой узел, выводим путь
            if (node.Left == null && node.Eq == null && node.Right == null)
            {
                treeBranches.Add(path);
                return treeBranches;
            }

            // Рекурсивно обходим левое, среднее и правое поддеревья
            GetPaths(node.Left!, path);
            GetPaths(node.Eq!, path);
            GetPaths(node.Right!, path);

            return treeBranches;
        }

        public int CalcMaxPossibleNumberOfMushroomsCollected()
        {
            if (treeBranches.Count == 0) return 0;
            else
            {
                int maxCount = 0;
                char mushroom = 'C';

                foreach (var branch in treeBranches)
                {
                    int count = branch.Count(c => c == mushroom);
                    maxCount = count >= maxCount ? count : maxCount;
                }

                return maxCount;
            }
        }
    }   
}
