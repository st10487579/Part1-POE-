using System;
using System.Collections; // Required for ArrayList

namespace Part1
{
    // The main engine for the chatbot interaction.
    public class chats
    {
        // TASK 4: ArrayLists used to store responses and keywords.
        ArrayList answers = new ArrayList();
        ArrayList ignoring = new ArrayList();

        public void ai_user(string name)
        {
            // Populate the response database.
            answers.Add("How are you? -> I am functioning perfectly and ready to help!");
            answers.Add("Purpose? -> My purpose is to teach you about online safety.");
            answers.Add("Password safety -> Passwords should be 12+ characters with symbols.");
            answers.Add("Phishing -> Phishing is when scammers send fake emails to steal data.");
            answers.Add("Safe browsing -> Only use HTTPS websites and avoid public Wi-Fi for banking.");
            answers.Add("Ask about -> You can ask me about passwords, phishing, or safety tips.");

            // Words to filter out during the search process.
            ignoring.Add("what");
            ignoring.Add("is");
            ignoring.Add("the");
            ignoring.Add("tell");

            string asking = string.Empty;
            Console.WriteLine("\n(Type 'exit' to terminate the session)");

            // The main conversational loop.
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n" + name + ": ");
                Console.ResetColor();
                asking = Console.ReadLine();

            } while (end_chat(asking));
        }

        private Boolean end_chat(string question)
        {
            // TASK 5: Validate that the user actually typed a question.
            if (string.IsNullOrWhiteSpace(question))
            {
                Console.WriteLine("Guardio: System idle. Please enter a question.");
                return true;
            }

            // Check for exit command.
            if (question.ToLower() == "exit")
            {
                Console.WriteLine("\nGuardio: Session Terminated. Stay secure!");
                return false;
            }

            // Split the input string into individual words to search.
            string[] finds_words = question.ToLower().Split(' ');
            bool found = false;

            foreach (string words in finds_words)
            {
                // Skip words in the ignore list.
                if (ignoring.Contains(words)) continue;

                foreach (string find_answer in answers)
                {
                    // If a keyword matches an answer in our ArrayList.
                    if (find_answer.ToLower().Contains(words))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Guardio: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(find_answer);
                        Console.ResetColor();
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            // Fallback response if no keywords were matched.
            if (!found)
            {
                Console.WriteLine("Guardio: My database doesn't have an answer for that. Ask about passwords or phishing.");
            }

            return true;
        }
    }
}