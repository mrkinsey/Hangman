public class ProgramUI
{
    int livesRemaining = 6;

    public void Run()
    {
        Game();
    }

    public void Game()
    {
        // Set game up - Username and give instructions
        System.Console.WriteLine("Please enter a username");
        string userName = Console.ReadLine();
        System.Console.WriteLine($"Welcome {userName} to Fruit Hangman!");
        System.Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
        System.Console.WriteLine("How to play: A random fruit will generate and you have six lives to guess what fruit it is.\nThe number of characters to guess will be depicted by a '_'.\nA prompt to guess a guess the letter will be on the screen.\nIf the guessed letter is correct, it will replace the '_' with the guessed letter.\nIf the guessed letter is incorrect, a prompt indicating the letter was incorrect will formulate along with the number of lives remaining.\n\nPress enter to continue.");
        Console.ReadLine();

        // Creates the new random word from RandomWordGenerator
        RandomWordGenerator randomWordGenerator = new RandomWordGenerator();
        string randomWord = randomWordGenerator.GenerateRandomWord();

        // Creates a blank List<string> of guesses. Will be filled in later as the user inputs guesses.
        List<string> letters = new List<string>();

        // Game runs if lives are > 0
        while (livesRemaining != 0)
        {
            // Counter of characters left to guess.
            int charactersLeft = 0;

            // Loop through all the characters of the word
            foreach (char character in randomWord)
            {
                // Make the letter a string (easier for conditions).
                string letter = character.ToString();

                // If the letter in the loop is in our array of used letters, we write the letter, otherwise we show an underscore (as a letter left to guess).
                if (letters.Contains(letter))
                {
                    Console.Write(letter + " ");
                }
                else
                {
                    Console.Write("_ ");

                    // We also increase the count of letters left, used to track whether the game is finished or not.
                    charactersLeft++;
                }
            }
            Console.WriteLine(string.Empty);

            // If there are no characters left, the game is over and we can break out of the loop.
            if (charactersLeft == 0)
            {
                break;
            }

            System.Console.Write("Letters already guessed: ");
            foreach (string letter in letters)
            {
                System.Console.Write(letter + " ");
            }
            Console.Write("\nType in a letter: ");

            // Read the input character and transform it to lowercase to compare to already used letters 
            string key = Console.ReadKey().Key.ToString().ToLower();
            Console.WriteLine(string.Empty);

            // Is the letter already in our array of used letters? 
            if (letters.Contains(key))
            {
                Console.WriteLine("You already entered this letter!");
                continue;
            }

            // If the letter has not already been used, we add it to our array of letters.
            letters.Add(key);

            //Call in incorrect guess 
            incorrectGuess(randomWord, key);
        }

        gameEnding(userName, livesRemaining, randomWord);
    }

    // If the chosen word doesn't contain the given letter, we reduce the number of lives remaining by 1
    public void incorrectGuess(string randomWord, string key)
    {
        if (!randomWord.Contains(key))
        {
            livesRemaining--;

            if (livesRemaining > 0)
            {
                Console.WriteLine($"The letter {key} is not in the word. You have {livesRemaining} {(livesRemaining == 1 ? "try" : "tries")} left.");
            }
        }
    }

    public void gameEnding(string userName, int livesRemaining, string randomWord)
    {
        if (livesRemaining > 0)
        {
            Console.WriteLine($"Congratulations {userName}, you won with {livesRemaining} {(livesRemaining == 1 ? "life" : "lives")} left!");
        }
        else
        {
            Console.WriteLine($"Sorry {userName}, you lost! The word was {randomWord}.");
        }
    }

}