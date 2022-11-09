public class RandomWordGenerator
{
    public string GenerateRandomWord()
    {

        // List of potential game options
        List<string> fruitArray = new List<string> {
            "apple",
            "orange",
            "strawberry",
            "watermelon",
            "banana",
            "clementine",
            "blueberry",
            "grape",
            "cantaloupe",
            "pineapple"
        };

        // Creating the random word to start the game
        Random rnd = new Random();
        int fruitArrayIndex = rnd.Next(fruitArray.Count);
        string randomWord = fruitArray[fruitArrayIndex];
        System.Console.WriteLine(randomWord);

        return randomWord;
    }
}