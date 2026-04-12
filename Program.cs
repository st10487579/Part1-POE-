using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;   

namespace Part1
{ // The Program class is the entry point of the application.
        // It manages the high-level flow of the chatbot's startup.
        public class Program
        {
            static void Main(string[] args)
            {
                // TASK 1: Initialize and play the voice greeting.
                // Using a constructor to trigger logic immediately.
                new voice();

                // TASK 2: Initialize and display the ASCII logo.
                new logo();

                // TASK 3: Manage the greeting and identity collection.
                welcome_and_name greet_name = new welcome_and_name();

                // Displays the decorative welcome message.
                greet_name.welcome();

                // TASK 3: Prompts for the user's name and validates it.
                // We store the return value in a local variable for the chat system.
                string name = greet_name.ask_name();

                // TASK 4 & 6: Start the main chatbot interaction loop.
                chats chatting = new chats();
                chatting.ai_user(name);
            }
        }
    }