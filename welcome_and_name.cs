using System;

namespace Part1
{
    // This class handles user identity and initial formatting.
    public class welcome_and_name
    {
        // Local variable to store the name.
        private string username = string.Empty;

        public void welcome()
        {
            // TASK 6: Enhanced UI using colors and borders.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n======================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("      GUARDIO CYBERSECURITY BOT");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================================");
            Console.ResetColor();
        }

        public string ask_name()
        {
            // TASK 5: Input Validation using a do-while loop.
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nGuardio: Accessing Secure Channel. What is your name? ");
                Console.ForegroundColor = ConsoleColor.Gray;
                username = Console.ReadLine();
                Console.ResetColor();

            } while (!isEmpty()); // Repeat if validation fails.

            return username;
        }

        private Boolean isEmpty()
        {
            // 1. Check if the name is blank or empty
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Guardio: Error. Name entry cannot be empty.");
                Console.ResetColor();
                return false;
            }

            // 2. Check if the name is too short (less than 2 characters)
            if (username.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Guardio: Error. That name is too short. Please use at least 2 letters.");
                Console.ResetColor();
                return false;
            }

            // 3. Check if the name contains numbers
            // We loop through each character to see if it is a digit
            foreach (char c in username)
            {
                if (char.IsDigit(c))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Guardio: Error. Names should only contain letters, not numbers.");
                    Console.ResetColor();
                    return false;
                }
            }

            // If all checks pass:
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Guardio: Access granted. Hello, {username}!");
            Console.ResetColor();
            return true;
        
    
        }
    }
}