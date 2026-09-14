namespace Homework
{
    internal class Program
    {
        private class ListTask
        {
            private List<string> words = new() {"one", "two", "three"};

            public void TaskLoop()
            {
                string? userInput = "";
                while(userInput != "exit")
                {
                    Console.WriteLine("Type any word to add to the list, or type \"list\" to see all words, or type \"exit\" to leave\n");
                    userInput = Console.ReadLine();
                    if(userInput == "list")
                    {
                        Console.WriteLine();
                        foreach (var word in words)
                        {
                            Console.WriteLine(word);
                        }
                    }
                    else if(userInput != null && userInput != "exit")
                    {
                        Console.WriteLine("Type 1 to add at the end or 2 to add in the middle: ");
                        bool isValid = false;
                        while (!isValid)
                        {
                            if(int.TryParse(Console.ReadLine(), out int input))
                            {
                                switch (input)
                                {
                                    case 1:
                                        words.Add(userInput);
                                        Console.WriteLine($"Word \"{userInput}\" added to the end of the list");
                                        isValid = true;
                                        break;
                                    case 2:
                                        words.Insert(words.Count / 2, userInput);
                                        Console.WriteLine($"Word \"{userInput}\" added in the middle of the list");
                                        isValid = true;
                                        break;
                                    default:
                                        Console.WriteLine("Unknown command. Type 1 to add at the end or 2 to add in the middle: ");
                                        break;
                                }

                            }
                        }
                    }
                } 
            }
        }

        private class DictionaryTask
        {
            private Dictionary<string, int> studentsGrades = new();

            public void TaskLoop()
            {
                int input;
                do
                {
                    Console.WriteLine("Choose your command: \n1. Add new student\n2. Check existing student\n3. Exit");
                    if(Int32.TryParse(Console.ReadLine(), out input))
                    {
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Type a name of the student");
                                string? student = Console.ReadLine();
                                   
                                while(student == null)
                                {
                                    Console.WriteLine("Name must have at least 1 letter");
                                    student = Console.ReadLine();
                                }
                                Console.WriteLine("Type a grade of the student");
                                do
                                {
                                    if(Int32.TryParse(Console.ReadLine(), out int grade))
                                    {
                                        if(grade > 5 || grade < 2)
                                        {
                                            Console.WriteLine("Grade must be a number between 2 and 5");
                                            continue;
                                        }
                                        else
                                        {
                                            studentsGrades[student] = grade;
                                            Console.WriteLine($"You've added student {student} with grade {grade}\n");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Type a number");
                                        continue;
                                    }
                                } while(true);
                                break;
                            case 2:
                                Console.WriteLine("Type a name of the student to check grade");
                                string? studentName = Console.ReadLine();
                                if (studentName != null && studentsGrades.ContainsKey(studentName))
                                {
                                    Console.WriteLine($"Student {studentName} has grade {studentsGrades.GetValueOrDefault(studentName)}\n");
                                }
                                else
                                {
                                    Console.WriteLine("There is no such student yet");
                                }
                                break;
                            case 3:
                                break;
                            default:
                                Console.WriteLine("Unknown command");
                                break;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Unknown command");
                    }
                } while (input != 3);
            }
        }

        private class LinkedListTask
        {
            private class Node
            {
                public int Value;
                public Node? Next;
                public Node? Prev;   
            }

            public void TaskLoop()
            {
                Console.WriteLine("Type a number of nodes between 3 and 6 or type exit to quit");
                int count;

                while (true)
                {
                    Console.WriteLine("How many nodes do you want?");
                    string? input = Console.ReadLine();
                    if (input == "exit")
                    {
                        return;
                    }
                    if (int.TryParse(input, out count) && count >= 3 && count <= 6)
                    {
                        break;
                    }

                    Console.WriteLine("Number of nodes must be a number between 3 and 6\n");

                }

                Node? head = null;
                Node? current = null;

                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Type a #{i + 1} number: ");
                    int.TryParse(Console.ReadLine(), out int value);

                    var node = new Node {Value = value};
                    if (head == null)
                    {
                        head = node;
                        current = node;
                    }
                    else
                    {
                        current.Next = node;
                        node.Prev = current;
                        current = node;
                    }
                }

                Console.WriteLine("\nIn order:");
                var forward = head;
                while (forward != null)
                {
                    Console.WriteLine(forward.Value);
                    forward = forward.Next;
                }

                Console.WriteLine("\nInversed order:");
                var backward = current;
                while (backward != null)
                {
                    Console.WriteLine(backward.Value);
                    backward = backward.Prev;
                }
                
            }

        }

        static void Main()
        {
            int input;
            do
            {
                Console.WriteLine("Enter 1,2 or 3 to check task 1,2 3 or type 4 to exit");
                int.TryParse(Console.ReadLine(), out input);
                switch (input)
                {
                    case 1:
                        CheckTaskOne();
                        break;
                    case 2:
                        CheckTaskTwo();
                        break;
                    case 3:
                        CheckTaskThree();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Unknown command.Try again");
                        break;
                } 
            }
            while (input != 4);
        }

        private static void CheckTaskOne()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }

        private static void CheckTaskTwo()
        {
            var dictionaryTask = new DictionaryTask();
            dictionaryTask.TaskLoop();
        }

        private static void CheckTaskThree()
        {
            var linkedListTask = new LinkedListTask();
            linkedListTask.TaskLoop();
        }
    }   
}