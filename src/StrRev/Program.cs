#nullable disable

namespace StrRev;

class Program
{
    static void Main(string[] args)
    {
        bool continueProgram;

        do
        {
            Console.WriteLine("Please enter a string to reverse:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                Console.WriteLine("Invalid input. Please enter a non-empty string.");

            else
            {
                string reversedString = ReverseString(input);
                Console.WriteLine($"Reversed string: {reversedString}");
            }

            // Ask the user if they want to continue and validate the input
            continueProgram = AskToContinue();

        } while (continueProgram);

        Console.WriteLine("Thank you for using the StrRev program. Goodbye!");
    }

    // Method to reverse the string
    static string ReverseString(string input)
    {
        // Convert the string to a character array
        char[] charArray = input.ToCharArray();

        // Reverse the array
        Array.Reverse(charArray);

        // Return the reversed string
        return new string(charArray);
    }

    // Method to ask the user if they want to continue and validate the input
    static bool AskToContinue()
    {
        while (true)
        {
            Console.WriteLine("Do you want to reverse another string? (y/n):");
            string userChoice = Console.ReadLine()?.Trim().ToLower();

            if (userChoice == "y")
                return true;

            else if (userChoice == "n")
                return false;

            else
                Console.WriteLine("Invalid input. Please enter 'y' to continue or 'n' to exit.");
        }
    }
}
