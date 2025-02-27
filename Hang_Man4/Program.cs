using System;

namespace Hang_Man4
{
    internal class Program
    {
        static string[] wordList = {
                                "programming", "computer", "developer", "software",
                                "algorithm", "variable", "function", "database",
                                "keyboard", "monitor", "application", "interface"
                                   };
        static Random rand = new Random();

        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Try to guess the secret word one letter at a time.\n" +
                "               The Concept of the words 'IT Landscape'");

            // Select a random word
            string secretWord = wordList[rand.Next(wordList.Length)];
            char[] guessedWord = new char[secretWord.Length];

            // Fill guessedWord with placeholders
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }

            List<char> guessedLetters = new List<char>();
            int incorrectGuesses = 0;
            const int MAX_INCORRECT_GUESSES = 6;

            bool gameOver = false;

            while (!gameOver)
            {
                // Display current state
                Console.WriteLine("\nWord: " + string.Join(" ", guessedWord));
                Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
                Console.WriteLine("Incorrect guesses: " + incorrectGuesses + "/" + MAX_INCORRECT_GUESSES);
                DrawHangman(incorrectGuesses);

                // Get player's guess
                Console.Write("\nEnter a letter: ");
                char guess = Console.ReadKey().KeyChar;
                guess = Char.ToLower(guess);
                Console.WriteLine();

                // Validate input
                if (!Char.IsLetter(guess))
                {
                    Console.WriteLine("Please enter a valid letter.");
                    continue;
                }

                // Check if letter was already guessed
                if (guessedLetters.Contains(guess))
                {
                    Console.WriteLine("You already guessed that letter!");
                    continue;
                }

                // Add to guessed letters
                guessedLetters.Add(guess);

                // Check if guess is correct
                bool correctGuess = false;
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        guessedWord[i] = guess;
                        correctGuess = true;
                    }
                }

                // Handle incorrect guess
                if (!correctGuess)
                {
                    incorrectGuesses++;
                    Console.WriteLine("Incorrect guess!");
                }

                // Check for win condition
                if (!guessedWord.Contains('_'))
                {
                    Console.WriteLine("\nWord: " + string.Join(" ", guessedWord));
                    Console.WriteLine("Congratulations! You guessed the word!");
                    gameOver = true;
                }

                // Check for lose condition
                if (incorrectGuesses >= MAX_INCORRECT_GUESSES)
                {
                    Console.WriteLine("\nYou ran out of guesses!");
                    Console.WriteLine("The word was: " + secretWord);
                    gameOver = true;
                }
            }

            Console.WriteLine("Game Over! Press any key to exit.");
            Console.ReadKey();

        }

        static void DrawHangman(int incorrectGuesses)
        {
            switch (incorrectGuesses)
            {
                case 0:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 1:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 2:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 3:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 4:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 5:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" /    |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 6:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" / \\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                }
            }
        }
    }
