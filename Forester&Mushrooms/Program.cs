namespace Forester_Mushrooms
{
    internal class Program
    {
        static char[,]? field;

        static readonly string pathToTheFileDescribingTheTask = "info.txt";

        static void Main()
        {
            TernarySearchTree tree = new('*');
            /*tree.Insert('.', "1");
            tree.Insert('C', "10");
            tree.Insert('.', "11");
            tree.Insert('C', "12");
            tree.Insert('.', "110");
            tree.Insert('C', "1100");
            tree.Insert('C', "11000");
            tree.Insert('.', "1101");
            tree.Insert('.', "120");
            tree.Insert('C', "1200");
            tree.Insert('C', "12000");
            tree.Insert('.', "1201");*/

            using StreamReader reader = new(pathToTheFileDescribingTheTask);
            string? lineOfTheFile;
            while ((lineOfTheFile = reader.ReadLine()) != null)
                Console.WriteLine(lineOfTheFile);

            int n = 0;
            Console.Write("\n\n\nРазмерноость поля n = ");
            while (!int.TryParse(Console.ReadLine(), out n))
                Console.Write("Введите число ");
            field = new char[n, 3];

            Console.WriteLine("\nЗаполните клетки поля (возможны только символы '.', 'W' и 'C'");
            FillingInTheCells.Fill(field);

            tree = FillingInTheTree.Fill(tree, field);
        }
    }
}
