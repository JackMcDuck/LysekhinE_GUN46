class Program
{
    static void Main()
    {
            //Задача A: создать 4 массива внутри метода Main

            // Задание 1
            // Чи́сла Фибона́ччи - элементы числовой последовательности в которой первые два числа равны 0 и 1, а каждое последующее число равно сумме двух предыдущих чисел, т.е. 0, 1, 1, 2, 3, 5 и т.д. Создайте массив, сожержащий первые 8 чисел данной последовательности

            int[] fibonacci = new int[8];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            // Задание 2
            // Создайте массив типа string, содержащий название 12 месяцев. Названия должны быть на английском и начинаться с заглавной буквы. Также не нужно использовать пробелы и лишние символы, только строка с названием
            string[] months = new string[]{"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            
            // Задание 3
            // Создайте двумерный массив (матрицу) 3x3. Вам нужно будет создать и проинициализировать двумерный массив типа int. Элементы массива-матрицы: Первая строка - числа 2, 3 и 4 в степени 1 Вторая строка - числа 2,3 и 4 в степени 2 Третья - числа 2,3 и 4 в степени 3

            int[,] matrix = new int[3,3];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i,j] = (int)MathF.Pow((float)j + 2, i + 1);
                } 
            }
            // Задание 4
            // Вам нужно будет создать и проинициализировать jagged array (ломанный массив). То есть массив, содержащий массивы разного размера Должен содержать следующие элементы (тип double) Первый массив - числа от 1 до 5 Второй массив - константы e и pi (используйте класс math) Третий массив - логарифм по основанию 10 чисел 1, 10, 100 и 1000 (используя функцию log).
            // Важно! Используйте статический класс Math для констант и логарифмов Ссылка
            double [][] jaggedArray = new double[3][];

            //массив с числами от 1 до 5
            jaggedArray[0] = new double[5];
            for (int i = 0; i < jaggedArray[0].Length; i++)
            {
                jaggedArray[0][i] = i + 1;
            }

            //массив с константами
            jaggedArray[1] = new double[2];
            jaggedArray[1][0] = Math.E;
            jaggedArray[1][1] = Math.PI;

            //массив с логарифмами
            jaggedArray[2] = new double[4] {1, 10, 100, 1000};
            for (int i = 0; i < jaggedArray[2].Length; i++)
            {
                jaggedArray[2][i] = Math.Log10(jaggedArray[2][i]);
            }



            // Задача Б: Вам дано два массива int[] array = { 1, 2, 3, 4, 5 }; int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
            // Задание 5
            // Скопируйте первые 3 элемента первого массива во второй. Воспользуйтесь классом Array.
            Array.Copy(array, array2, 3);

            //вывод
            Console.WriteLine("\nSecond array with 3 copied elements.");
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write($"{array2[i]} ");
            }
            // Задание 6
            // Измените размер первого массива так, чтобы в нём стало в два раза больше элементов Воспользуйтесь классом Array, метод Resize. ВАЖНО! Массив передаётся через ref. Это же ключевое слово вы будете использовать при вызове метода Resize, то есть: Array.Resize(ref array, newSize);
            Array.Resize(ref array, array.Length * 2);
            //вывод?
            Console.WriteLine($"\n\nFirst array doubled in size.");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

    }
}