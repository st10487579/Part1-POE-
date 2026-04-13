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
            // Populate the response database with deep cybersecurity knowledge.

            // --- PERSONAL & PURPOSE QUESTIONS ---
            answers.Add("How are you? -> I am functioning at 100% and ready to secure your data!");
            answers.Add("Purpose? -> I am Guardio. My mission is to help you browse the web safely.");
            answers.Add("What can I ask? -> You can ask me about passwords, phishing, or safe browsing.");

            // --- PASSWORD SAFETY ---
            answers.Add("Password -> A strong password should be at least 12 characters long and include symbols (!@#). Avoid using your birthday!");
            answers.Add("MFA -> Multi-Factor Authentication adds a second layer of security, like a code sent to your phone.");

            // --- PHISHING ---
            answers.Add("Phishing -> Phishing is a scam where hackers send fake emails to trick you into clicking malicious links. Always check the sender's email address!");
            answers.Add("Scams -> If an email sounds too good to be true (like winning a free iPhone), it is probably a scam.");

            // --- SAFE BROWSING ---
            answers.Add("Browsing -> Only enter personal info on websites that start with 'HTTPS'. The 'S' stands for Secure.");
            answers.Add("Public Wi-Fi -> Avoid logging into your bank account while on public Wi-Fi at coffee shops or airports; it is easy for hackers to spy there.");
            answers.Add("Updates -> Always keep your browser and apps updated to patch security holes that hackers might use.");

            // Words to filter out during the search process to focus on keywords.
            ignoring.Add("what");
            ignoring.Add("is");
            ignoring.Add("the");
            ignoring.Add("tell");
            ignoring.Add("about");

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
            // TASK 5: Validate that the user actually typed something.
            if (string.IsNullOrWhiteSpace(question))
            {
                Console.WriteLine("Guardio: I'm waiting for your question. Please type something!");
                return true;
            }

            // Check for exit command.
            if (question.ToLower() == "exit")
            {
                Console.WriteLine("\nGuardio: 👋 Session Terminated. Stay secure, " + "!");
                return false;
            }

            // Split the input string into individual words to search for matches.
            string[] finds_words = question.ToLower().Split(' ');
            bool found = false;

            foreach (string words in finds_words)
            {
                // Skip common words like "the" or "is".
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
                Console.WriteLine("Guardio: I don't have information on that yet. Try asking about 'phishing', 'passwords', or 'WiFi'.");
            }

            return true;
        }
    }
}