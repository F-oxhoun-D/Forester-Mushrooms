namespace Forester_Mushrooms
{
    public class FillingInTheTree(char[,] field)
    {
        readonly TernarySearchTree tree = new();

        readonly char[,] field = field;

        public TernarySearchTree Fill() => BypassAndInsert();

        private TernarySearchTree BypassAndInsert()
        {
            string pathTree = string.Empty; // путь до узла (0 - левый, 1 - средний, 2 - правый узлы)
            string passedСol = string.Empty; // пройденные колонки (последовательность номеров колонок служит для того, чтобы мы не попадали в ранее пройденный)
            int row = 0;
            int col = 0;
            int counter; // счётчик количества узлов

            while (true)
            {
                if (row < field.GetLength(0) && col < field.GetLength(1))
                {
                    if (col == 3)
                        break;
                    if (field[row, col] == 'W')
                    {
                        col++;
                        continue;
                    }
                    else
                    {
                        counter = TernarySearchTree.GetCountNumber(tree, pathTree); // считаем сколько узлов у текущего
                        if (counter == 3) // если три, то обход завершён
                            break;
                        if (counter == 2 && col == 2 && passedСol[^1] == '2') // если попали в крайний правый элемент
                        {
                            pathTree = pathTree[..^2];

                            col = int.Parse(passedСol.Substring(passedСol.Length - 1, 1));
                            row = col == 2 ? --row : row;

                            passedСol = passedСol[..^2];
                            continue;
                        }

                        pathTree += counter;
                        tree.Insert(field[row, col], pathTree);
                        passedСol += col;

                        bool checkIfTheLineHasBeenViewed = false;
                        bool checkLeftNodeHasBeenViewed = false;
                        bool checkEqNodeHasBeenViewed = false;
                        bool checkRightNodeHasBeenViewed = false;

                        while (!checkIfTheLineHasBeenViewed)
                        {
                            if (row + 1 < field.GetLength(0) && col - 1 < field.GetLength(1) && col - 1 >= 0
                                && !checkLeftNodeHasBeenViewed)
                            {
                                if (field[row + 1, col - 1] != 'W')
                                {
                                    row++;
                                    col--;

                                    checkIfTheLineHasBeenViewed = true;
                                }
                                checkLeftNodeHasBeenViewed = true;
                            }
                            else if (row + 1 < field.GetLength(0) && col < field.GetLength(1) && col >= 0
                                && !checkEqNodeHasBeenViewed)
                            {
                                if (field[row + 1, col] != 'W')
                                {
                                    row++;

                                    checkIfTheLineHasBeenViewed = true;
                                }
                                checkEqNodeHasBeenViewed = true;
                            }
                            else if (row + 1 < field.GetLength(0) && col + 1 < field.GetLength(1) && col + 1 >= 0
                                && !checkRightNodeHasBeenViewed)
                            {
                                if (field[row + 1, col + 1] != 'W')
                                {
                                    row++;
                                    col++;

                                    checkIfTheLineHasBeenViewed = true;
                                    continue;
                                }
                                checkRightNodeHasBeenViewed = true;
                            }
                            else
                            {
                                pathTree = pathTree[..^1]; // возвращаемся на шаг назад

                                // извлекаем номер колонки из которой мы пришли
                                col = int.Parse(passedСol.Substring(passedСol.Length - 1, 1));
                                row = col == 2 ? --row : row; // если мы находились в правом углу, то поднимаемся на строку вверх
                                col = col == 2 ? col : ++col;

                                passedСol = passedСol[..^1];

                                checkIfTheLineHasBeenViewed = true;
                            }
                        }
                    }
                }
                else // если дошли до последней строки
                {
                    // переходим на строку ниже
                    row--;
                    if (row == -1)
                        break;
                    pathTree = pathTree[..^1];

                    col = int.Parse(passedСol.Substring(passedСol.Length - 1, 1));
                    col++;

                    passedСol = passedСol[..^1];
                }
            }
            return tree;
        }
    }
}
