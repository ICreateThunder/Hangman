using System.ComponentModel;
using System.Text;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Read words from file into list as lower case
            List<String> words = File.getFile("Files/words.txt").ToLower().Split('\n').ToList<String>();

            // Choose a word randomly
            String word = words[random.Next(0, words.Count-1)];

            // Game prompt/instructions
            Console.WriteLine("---           ---\n-    Hangman    -\n---           ---\n\nWelcome, the game is simple: Hangman.\nGuess characters that make up the word\nFor each correct character it fills the blank\n\nGood luck\n\n");

            // Game variables
            string[] hangman =
            {
                "  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n========="
            };

            StringBuilder sb = new StringBuilder(new String('_',word.Length - 1));
            byte score = 0;
            int guesses = 0;
            char input;
            bool hasWon = false;

            while (score < 7 && !hasWon)
            {
                // Prompt
                Console.Write($"\n[WORD]\n\n\t{sb.ToString()}\n\n[HANGMAN]\n\n{hangman[score]}\n\nPlease enter your character: ");

                try
                {
                    // Read input
                    input = Convert.ToChar(Console.ReadLine());

                    // Check if valid (a-z) if not then continue
                    if (input <= 'a' && input >= 'z')
                    {
                        Console.WriteLine("\n\n[!] ERROR :: Please enter a character between a-z\n\n");
                        continue;
                    }

                    int index = 0;

                    // Check if chracter is within the word
                    if (word.Contains(input))
                    {
                        while ((index = word.IndexOf(input, index)) != -1)
                        {
                            sb.Remove(index, 1);
                            sb.Insert(index, input);
                            index++;
                            guesses++;
                        }
                        if (!sb.ToString().Contains('_'))
                            hasWon = true;
                        continue;
                    }
                    else
                        guesses++;
                        score++;
                }
                catch(Exception e)
                {
                    Console.WriteLine($"[!] ERROR :: Something went wrong, please enter a vaild character\n\nEXCEPTION :: {e}");
                }
            }

            if (hasWon)
                Console.WriteLine($"[-] INFO :: Well done you have won in {guesses} guesses.\n\nThe word was: {word}");
            else
                Console.WriteLine($"[-] INFO :: Unfortunately you have lost. Better luck next time\n\nThe word was: {word}\n\n;(");
        }
    }
}