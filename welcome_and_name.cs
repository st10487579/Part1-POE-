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
            Console.WriteLine("      GUARDIO: SECURITY PROTOCOL");
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
            // Checks if the user provided an actual name (not spaces or null).
            if (!string.IsNullOrWhiteSpace(username))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Guardio: Identity Confirmed. Hello, {username}!");
                Console.ResetColor();
                return true;
            }
            else
            {
                // Error message for invalid input.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Guardio Error: Name entry is required for system access.");
                Console.ResetColor();
                return false;
            }
        }
    }
}