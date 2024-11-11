using System;
using System.IO;
using System.Text;

namespace TheLongGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Gooble™ password manager");
            Console.WriteLine("Enter your username to begin:");
            string username = Console.ReadLine();
            Console.WriteLine($"Great! Welcome, {username}! Let's make some strong passwords!! \nDon't forget to follow the prompts on the screen to get the securest passwords!");

            int score = 0;
            string filename = $"{username}_password_strength.txt";
            StringBuilder password = new StringBuilder();

            // Check if previous score exists
            if (File.Exists(filename))
            {
                string savedScore = File.ReadAllText(filename);
                if (int.TryParse(savedScore, out int previousScore))
                {
                    score = previousScore;
                    Console.WriteLine($"Welcome back, {username}! Last time, you achieved a strength score of {score}.");
                }
            }

            // Game loop
            while (true)
            {
                var key = Console.ReadKey(intercept: true);

                // End game on Enter key
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine($"\nFinal Password Strength Score: {score}");
                    Console.WriteLine("Thank you for keeping your personal information safe ;) !!!!!");
                    File.WriteAllText(filename, score.ToString());
                    break;
                }

                // Increment score and update password
                score++;
                password.Append(key.KeyChar);

                // Display the current password and score
                Console.WriteLine($"Your current password: {password} | Strength Score: {score}");

                // Status report messages for humor
                if (score <= 5)
                    Console.WriteLine("Does not meet requirements, try a special character!");
                else if (score == 10)
                    Console.WriteLine("Does not meet requirements, try adding a capital letter!");
                else if (score == 15)
                    Console.WriteLine("Does not meet requirements, try adding your birthday!");
                else if (score == 20)
                    Console.WriteLine("Does not meet requirements, try adding your first pet's name!");
                else if (score == 30)
                    Console.WriteLine("Does not meet requirements, try adding the three digits on the back of your credit card!");
                else if (score == 50)
                    Console.WriteLine("Does not meet requirements, try adding your social security number!");
            }
        }
    }
}
