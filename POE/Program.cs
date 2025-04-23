using System;
using System.Media;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main()
        {
            // Set the title of the window
            Console.Title = "Cybersecurity Awareness Bot";

            // Play the greeting sound (if available)
            PlayVoiceGreeting();

            // Show a lock-themed ASCII art intro
            DisplayAsciiArt();

            // Print a line to separate sections
            PrintDivider();

            // Ask the user for their name
            string userName = GetUserName();

            // Greet the user with a typing effect
            TypeEffect($"\n👋 Hello {userName}! I'm your Cybersecurity Awareness Bot.", 40);

            // Another divider line
            PrintDivider();

            // Show the list of things the user can ask about
            ShowOptions();

            // Loop so the bot keeps running until the user types "exit"
            while (true)
            {
                Console.Write("\n Ask me something (or type 'exit' to quit): ");
                string input = Console.ReadLine();

                // End the program if the user types "exit"
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("\n Goodbye! Stay safe online!");
                    break;
                }

                // Handle the user's question
                HandleUserQuestion(input, userName);
            }
        }

        // Play a sound file to greet the user
        static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("CyberBot Audio.wav");
                player.PlaySync(); // Play and wait until done
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Could not play greeting audio: {ex.Message}. Make sure 'CyberBot Audio.wav' is in the correct directory.");
                Console.ResetColor();
            }
        }

        // Display the lock ASCII art on startup
        static void DisplayAsciiArt()
        {
            string asciiArt = @"
       .--------.
      / .------. \
     / /        \ \
     | |        | |
    _| |________| |_
  .' |_|        |_| '.
  '._____ ____ _____.' 
  |     .'____'.     |
  '.__.'.'    '.'.__.'  
  '.__  | LOCK |  __.' 
  |   '.'.____.'.'   |
  '.____'.____.'____.'
  '.________________.'
 Your Cybersecurity Awareness Assistant
";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }

        // Ask for the user's name and make sure it's not empty
        static string GetUserName()
        {
            Console.Write(" Please enter your name: ");
            string name = Console.ReadLine();

            // Repeat until user enters a valid name
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write(" Name cannot be empty. Try again: ");
                name = Console.ReadLine();
            }

            return name;
        }

        // Answer questions based on keywords found in the user's input
        static void HandleUserQuestion(string input, string userName)
        {
            input = input.ToLower(); // Make input lowercase for easier matching
            Console.ForegroundColor = ConsoleColor.Green;

            // Respond based on what the input includes
            switch (input)
            {
                case var _ when input.Contains("phishing"):
                    Console.WriteLine("Phishing is a scam where attackers trick you into revealing personal info through fake emails or websites.");
                    break;

                case var _ when input.Contains("password"):
                    Console.WriteLine(" Use strong, unique passwords with letters, numbers, and symbols. Consider a password manager.");
                    break;

                case var _ when input.Contains("safe browsing"):
                    Console.WriteLine(" Always check URLs, avoid clicking suspicious links, and use secure (HTTPS) websites.");
                    break;

                case var _ when input.Contains("security tip") || input.Contains("security tips"):
                    ShowSecurityTips();
                    break;

                case var _ when input.Contains("tip 1"):
                    Console.WriteLine(" Tip 1: Keep your software and operating system up to date.");
                    break;

                case var _ when input.Contains("tip 2"):
                    Console.WriteLine(" Tip 2: Avoid using public Wi-Fi for sensitive tasks like online banking.");
                    break;

                case var _ when input.Contains("tip 3"):
                    Console.WriteLine(" Tip 3: Enable two-factor authentication (2FA) on important accounts.");
                    break;

                case var _ when input.Contains("what can i ask"):
                    ShowOptions();
                    break;

                case var _ when input.Contains("how are you"):
                    Console.WriteLine($" I'm doing great, {userName}! Ready to help you stay safe online.");
                    break;

                default:
                    // If input doesn't match anything
                    Console.WriteLine(" I didn't quite understand that. Could you rephrase?");
                    break;
            }

            Console.ResetColor();
        }

        // Show the list of topics the bot can help with
        static void ShowOptions()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" You can ask me about:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    Phishing");
            Console.WriteLine("    Password Safety");
            Console.WriteLine("    Safe Browsing");
            Console.WriteLine("    Security Tips");
            Console.ResetColor();
        }

     
        static void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('-', 60));
            Console.ResetColor();
        }

        // Display text slowly to simulate a typing effect
        static void TypeEffect(string text, int delay = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Wait a short time between each character
            }
            Console.WriteLine();
        }
    }
}



