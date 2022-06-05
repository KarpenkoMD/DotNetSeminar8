/* Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию 
элементы каждой строки двумерного массива. */

(int, int) GetArraySize()
{
    int rowSize = 0;
    int colSize = 0;
    string enteredSymbol = string.Empty;
    do
    {
        Console.Clear();
        Console.Write("Создать случайный 2D массив? Нажмите y/n: ");
        enteredSymbol = Console.ReadLine();
        if (enteredSymbol == "y")
        {
            rowSize = new Random().Next(2, 11);
            colSize = new Random().Next(2, 11);
            Console.WriteLine("Значение m: {0}", rowSize);
            Console.WriteLine("Значение n: {0}", colSize);
            Console.WriteLine();
            break;
        }
        else if (enteredSymbol == "n")
        {
            Console.Write("Введите значение m:");
            rowSize = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите значение n:");
            colSize = Convert.ToInt32(Console.ReadLine());
            break;
        }
    } while (true);

    return (rowSize, colSize);
}
void Fill2DArray(int[,] ArrayToFill, int deviation = 10)
{
    for (int i = 0; i < ArrayToFill.GetLength(0); i++)
    {
        for (int j = 0; j < ArrayToFill.GetLength(1); j++)
        {
            ArrayToFill[i, j] = new Random().Next(-deviation, deviation + 1);
        }
    }
}
void Print2DArray(int[,] ArrayToPrint, int coloredElement = 0)
{
    int rowColoredElement = (coloredElement - 1) / ArrayToPrint.GetLength(1);
    int colColoredElement = coloredElement - 1 - rowColoredElement * ArrayToPrint.GetLength(1);
    Console.Write("[X]\t");
    for (int i = 0; i < ArrayToPrint.GetLength(1); i++)
    {
        Console.Write($"[{i}]\t", i);
    }
    Console.WriteLine();
    for (int i = 0; i < ArrayToPrint.GetLength(0); i++)
    {
        Console.Write($"[{i}]\t", i);
        for (int j = 0; j < ArrayToPrint.GetLength(1); j++)
        {
            if (i == rowColoredElement
                && j == colColoredElement)
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            if (ArrayToPrint[i, j] < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.Write(ArrayToPrint[i, j] + "\t");
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}
void DescendingArrayRowSort(int[,] arrayToSort)
{
    int temp = 0;
    for (int i = 0; i < arrayToSort.GetLength(0); i++)
    {
        for (int j = 0; j < arrayToSort.GetLength(1); j++)
        {
            for (int k = j + 1; k < arrayToSort.GetLength(1); k++)
            {
                if (arrayToSort[i, j] < arrayToSort[i, k])
                {
                    temp = arrayToSort[i, j];
                    arrayToSort[i, j] = arrayToSort[i, k];
                    arrayToSort[i, k] = temp;
                }
            }
        }
    }
}


int rowSize = 0, colSize = 0;
(rowSize, colSize) = GetArraySize();
int[,] arrayToOperate = new int[rowSize, colSize];
Fill2DArray(arrayToOperate, deviation: 90);
Console.WriteLine("Неотсортированный массив:");
Print2DArray(arrayToOperate);
DescendingArrayRowSort(arrayToOperate);
Console.WriteLine();
Console.WriteLine("Отсортированный массив:");
Print2DArray(arrayToOperate);

