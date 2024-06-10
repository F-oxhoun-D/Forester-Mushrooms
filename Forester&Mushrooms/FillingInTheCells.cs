namespace Forester_Mushrooms
{
    public static class FillingInTheCells
    {
        public static void Fill(char[,] field)
        {
            int n = field.GetLength(0);
            int numberLine = 1;

            while (numberLine != n + 1)
            {
                bool checkCorrectLine = false;
                while (!checkCorrectLine)
                {
                    Console.WriteLine($"{numberLine}-я строка: ");
                    string line = string.Join("", Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.Length >= 3)
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
                    if (!string.IsNullOrEmpty(enterSymbol))
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
