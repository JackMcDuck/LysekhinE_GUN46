using System.Text;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nChoose a functuion to use:\n1. Concatenate two strings\n2. Greet a user\n3. Get string info\n4. Get first 5 symbols of the string\n5. Append strings array\n6. Replace word in text\n7. Exit");
            int.TryParse(Console.ReadLine(), out int userInput);
            switch (userInput)
            {
                case 1:
                    ConcatenationRoutine();
                    break;
                case 2:
                    GreetingRoutine();
                    break;
                case 3:
                    StringInfoRoutine();
                    break;
                case 4:
                    FirstFiveSymbolsRoutine();
                    break;
                case 5:
                    AppendStringsArrayRoutine();
                    break;
                case 6:
                    ReplaceWordsRoutine();
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Unknown command. Try again");
                    break;
            }
        }
    }

    static string ConcatenateStrings(string? str1, string? str2)
    {
        return str1 + str2;
    }

    static void ConcatenationRoutine()
    {
        Console.Write("You need to type two parts of text\nType first part: ");
        string? input1 = Console.ReadLine();
        Console.Write("Type second part: ");
        string? input2 = Console.ReadLine();
        Console.WriteLine(ConcatenateStrings(input1, input2));
    }

    static string GreetUser(string? name, int age)
    {
        return $"Hello, {name}!\nYou are {age} years old.";
    }

    static void GreetingRoutine()
    {
        Console.Write("What is your name? ");
        string? name = Console.ReadLine();
        Console.Write("How old are you? ");
        int.TryParse(Console.ReadLine(), out int age);
        Console.WriteLine(GreetUser(name, age));
    }

    static string StringInfo(string? input)
    {
        return $"String has {input?.Length} symbols.\nIn upper case: {input?.ToUpper()}\nIn lower case: {input?.ToLower()}";
    }

    static void StringInfoRoutine()
    {
        Console.Write("Type a string to get info: ");
        string? input = Console.ReadLine();
        Console.WriteLine(StringInfo(input));
    }

    static string FirstFiveSymbols(string? input)
    {
        return input.Substring(0, 5);
    }

    static void FirstFiveSymbolsRoutine()
    {
        Console.Write("Type a string at least five symbols length to get first five symbols: ");
        string? input = Console.ReadLine();
        while(input.Length < 5)
        {
            Console.Write("Your text have less than five symbols. Try again: ");
            input = Console.ReadLine();
        }
        Console.WriteLine(FirstFiveSymbols(input));
    }

    static StringBuilder AppendStringsArray(string?[] strings)
    {
        StringBuilder sb = new();
        for (int i = 0; i < strings.Length; i++)
        {
            sb.Append(strings[i]);
            sb.Append(" ");
        }
        return sb;
    }

    static void AppendStringsArrayRoutine()
    {
        Console.Write("Type a number of elements in string array: ");
        int.TryParse(Console.ReadLine(), out int elementsNumber);
        while(elementsNumber < 1)
        {
            Console.Write("Array must have at least one element. Try again: ");
            int.TryParse(Console.ReadLine(), out elementsNumber);
        }
        string?[] stringsArray = new string[elementsNumber];
        for(int i = 0; i < elementsNumber; i++)
        {
            Console.Write($"Type string number {i + 1}: ");
            stringsArray[i] = Console.ReadLine();
        }
        Console.WriteLine(AppendStringsArray(stringsArray));
    }

    static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
    {
        return inputString.Replace(wordToReplace, replacementWord);
    }

    static void ReplaceWordsRoutine()
    {
        Console.Write("Type an original string you want to modify: ");
        string? inputString = Console.ReadLine();
        Console.Write("Type a word to replace from original string: ");
        string? wordToReplace = Console.ReadLine();
        while(wordToReplace == "")
        {
            Console.Write("Word to replace mast have at least one symbol. Try again: ");
            wordToReplace = Console.ReadLine();
        }
        Console.Write("Type a replacement word: ");
        string? replacementWord = Console.ReadLine();
        Console.WriteLine(ReplaceWords(inputString, wordToReplace, replacementWord));
    }
}