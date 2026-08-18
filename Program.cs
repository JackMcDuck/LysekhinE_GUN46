class Program
{
    static void Main()
    {
        Console.WriteLine("Type first number: ");
        if (!int.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("Not a number");
            return;
        }
        
        Console.WriteLine("\nType second number: ");
        if (!int.TryParse(Console.ReadLine(), out int b))
        {
            Console.WriteLine("Not a number");
            return;
        }

        Console.WriteLine("\nType bitwise operation symbol(&, |, ^)");
        string? symbol = Console.ReadLine();

        int result = 0;
        
        switch (symbol)
        {
            case "&":
                Console.WriteLine($"\n--> Your operation in binary: {Convert.ToString(a, 2)} & {Convert.ToString(b, 2)}\n");
                result = a & b;
                break;
            case "|":
                Console.WriteLine($"\n--> Your operation in binary: {Convert.ToString(a, 2)} | {Convert.ToString(b, 2)}\n");
                result = a | b;
                break;
            case "^":
                Console.WriteLine($"\n--> Your operation in binary: {Convert.ToString(a, 2)} ^ {Convert.ToString(b, 2)}\n");
                result = a ^ b;
                break;
            default:
                Console.WriteLine("Unknown operation");
                break;
        }

        Console.WriteLine($"Result:\nDecimal (Base-10): {result}");
        Console.WriteLine($"Binary (Base-2): {Convert.ToString(result, 2)}");
        Console.WriteLine($"Hexadecimal (Base-16): {result:X}");

    }
}