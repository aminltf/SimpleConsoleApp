#nullable disable

using System.Globalization;

namespace DateConverter;

class Program
{
    static void Main(string[] args)
    {
        bool continueProgram;

        do
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Convert Gregorian date to Persian date");
            Console.WriteLine("2. Convert Persian date to Gregorian date");
            Console.Write("Enter your choice (1 or 2): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ConvertGregorianToPersian();
                    break;
                case "2":
                    ConvertPersianToGregorian();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    break;
            }

            continueProgram = AskToContinue();

        } while (continueProgram);

        Console.WriteLine("Thank you for using the DateConverter program. Goodbye!");
    }

    // Method to convert Gregorian date to Persian date
    static void ConvertGregorianToPersian()
    {
        while (true)
        {
            Console.Write("Enter a Gregorian date (yyyy-MM-dd): ");
            string inputDate = Console.ReadLine();

            if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime gregorianDate))
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                int year = persianCalendar.GetYear(gregorianDate);
                int month = persianCalendar.GetMonth(gregorianDate);
                int day = persianCalendar.GetDayOfMonth(gregorianDate);

                Console.WriteLine($"Persian date: {year}/{month:D2}/{day:D2}");
                break; // Exit the loop if conversion is successful
            }
            else
                Console.WriteLine("Invalid date format. Please use the format yyyy-MM-dd.");
        }
    }

    // Method to convert Persian date to Gregorian date
    static void ConvertPersianToGregorian()
    {
        while (true)
        {
            Console.Write("Enter a Persian date (yyyy/MM/dd): ");
            string inputDate = Console.ReadLine();
            string[] parts = inputDate.Split('/');

            if (parts.Length == 3 &&
                int.TryParse(parts[0], out int year) &&
                int.TryParse(parts[1], out int month) &&
                int.TryParse(parts[2], out int day))
            {
                try
                {
                    PersianCalendar persianCalendar = new PersianCalendar();
                    // Validate the Persian date
                    if (month >= 1 && month <= 12 && day >= 1 && day <= persianCalendar.GetDaysInMonth(year, month))
                    {
                        DateTime gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
                        Console.WriteLine($"Gregorian date: {gregorianDate:yyyy-MM-dd}");
                        break; // Exit the loop if conversion is successful
                    }
                    else
                        Console.WriteLine("Invalid Persian date. Please enter a valid date.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting date: {ex.Message}");
                }
            }
            else
                Console.WriteLine("Invalid date format. Please use the format yyyy/MM/dd.");
        }
    }

    // Method to ask the user if they want to continue and validate the input
    static bool AskToContinue()
    {
        while (true)
        {
            Console.WriteLine("Do you want to perform another conversion? (y/n):");
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
