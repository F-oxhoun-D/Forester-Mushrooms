namespace Forester_Mushrooms
{
    internal class Program
    {
        static char[,]? field;

        static readonly string pathToTheFileDescribingTheTask = "info.txt";

        static int n = 1;

        static void Main()
        {
            TernarySearchTree<char> tree = new('*');
            tree.Insert('.', "2");
            tree.Insert('C', "21");
            tree.Insert('.', "22");
            tree.Insert('C', "23");
            tree.Insert('.', "223");


            using StreamReader reader = new(pathToTheFileDescribingTheTask);
            string? lineOfTheFile;
            while ((lineOfTheFile = reader.ReadLine()) != null)
                Console.WriteLine(lineOfTheFile);

            Console.Write("\n\n\nРазмерноость поля n = ");
            while (!int.TryParse(Console.ReadLine(), out n))
                Console.Write("Введите число ");
            field = new char[n, 3];

            Console.WriteLine("\nЗаполните клетки поля (возможны только символы '.', 'W' и 'C'");
            FillInTheField();
            
        }

        static void FillInTheField()
        {
            int numberLine = 1;
            while (numberLine != n + 1)
            {
                bool checkCorrectLine = false;
                while (!checkCorrectLine)
                {
                    Console.WriteLine($"{numberLine}-я строка: ");
                    string line = Console.ReadLine()!;
                    if (string.IsNullOrEmpty(line))
                    {
                        if (line.Length == 3)
                        {
                            for (int numberColumn = 0; numberColumn < line.Length; numberColumn++)
                            {
                                char c = line[numberColumn];
                                if (c is not '.' and not 'W' and not 'C')
                                    c = GetCorrectCellValue(ref c);

                                field![numberLine - 1, numberColumn] = c;
                            }
                            numberLine++;
                            checkCorrectLine = true;
                        }
                        else
                            Console.WriteLine($"К-во символов {line.Length} меньше необходимого: 3)");
                    }
                    else
                        Console.WriteLine("Введена пустая строка");
                }
            }
        }

        static char GetCorrectCellValue(ref char cellValue)
        {
            if (cellValue is not '.' and not 'W' and not 'C')
            {
                Console.WriteLine($"Замените символ {cellValue} на один из  трёх: '.', 'W', 'C'");
                bool checkTheCorrectOfTheCharInput = false;
                while (!checkTheCorrectOfTheCharInput)
                {
                    string enterSymbol = Console.ReadLine()!;
                    if (string.IsNullOrEmpty(enterSymbol))
                    {
                        char symbol = Convert.ToChar(enterSymbol);
                        return GetCorrectCellValue(ref symbol);
                    }
                    else
                        Console.WriteLine("Введён пустой символ");
                }
            }
            return cellValue;
        }

    }
}
