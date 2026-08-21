class Program
{
    static void Main()
    {
        //Задание 1
        // С помощью цикла for (или while) выведите первые 10 чисел Фиббоначи (см. Задание из 3 урока)
        uint elementsNumber = 10;
        int firstNumber = 0;
        int secondNumber = 1;

        Console.WriteLine($"\nFirst {elementsNumber} numbers of Fibonacci sequence: ");
        for (int i = 0; i < elementsNumber; i++)
        {
            Console.Write($"{firstNumber} ");

            int nextNumber = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = nextNumber;
        }

        // Задание 2
        // Используя цикл for, выведите все чётные числа от 2 до 20
        int minNumber = 2;
        int maxNumber = 20;

        Console.WriteLine($"\n\nEven numbers from {minNumber} to {maxNumber}: ");
        for (int i = minNumber; i <= maxNumber; i += 2)
        {
            if(i % 2 == 0)
            {
                Console.Write($"{i} ");
            }
        }

        // Задание 3
        // С помощью вложенных циклов for выведите таблицу умножения от 1 до 5. Каждая строка таблицы должна быть выведена в отдельной строке.
        int baseNumber = 5;

        Console.WriteLine($"\n\nMultiplication table for number {baseNumber}: ");

        //верхняя строка
        Console.Write("\t");
        for (int i = 1; i <= baseNumber; i++)
        {
            Console.Write($"{i}\t");
        }
        Console.WriteLine();

        for (int i = 1; i <= baseNumber; i++)
        {
            Console.Write($"{i}\t"); //левый столбик
            for (int j = 1; j <= baseNumber; j++)
            {
                Console.Write($"{i * j}\t");
            }
            Console.WriteLine();
        }

        // Задание 4
        // Дана строка string password = “qwerty”; Напишите программу для ввода пароля, которая считывает пользовательский ввод Console.ReadLine. Подсказка: используйте do-while
       
        string password = "qwerty";
        string result;
        int triesNumber = 3;

        do
        {
            Console.Write("\nEnter your password: ");
            result = Console.ReadLine();
            if (result != password)
            {
                triesNumber--;
                Console.WriteLine($"Wrong password. Attempts left: {triesNumber}");
            }
            else
            {
                Console.WriteLine("Welcome, @userName!");
                return;
            }
            
        } while(triesNumber > 0);

        Console.WriteLine("Sign in is blocked. You've tried too many times.");
    }
}