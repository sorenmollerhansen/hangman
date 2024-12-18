namespace HangmanV2;
public abstract class Guess {
    private static char[] wordToGuessArray = Game.wordToGuess.ToCharArray();
    private static char[] secretWordArray = new char[wordToGuessArray.Length];
    private static List<char> guessedLettersList = new List<char>();

    public static void start() {
        Console.WriteLine("Set new word? y/n \n");
        char answer = Console.ReadKey(true).KeyChar;
        if (answer == 'y') {
            Console.Write("Write new word: ");
                Game.wordToGuess = Console.ReadLine()!.ToUpper();
        }

        Console.CursorVisible = false;
        setSecretWordArray();
        Console.Clear();
        Console.WriteLine();
    }
    
    private static void setSecretWordArray() {
        for (int i = 0; i < secretWordArray.Length; i++) {
            secretWordArray[i] = '_';
        }
    }

    public static string progress() {
        return string.Join(" ", secretWordArray.ToArray());
    }

    public static string guessedLetters() {
        return string.Join(" ", guessedLettersList.ToArray());
    }

    public static void takeGuess() {
        char guess = char.ToUpper(Console.ReadKey(true).KeyChar);
        Console.Clear();
        
        if (guessedLettersList.Contains(guess) || secretWordArray.Contains(guess)) {
            Console.WriteLine("Invalid guess: {0} has already been guessed", guess);
        }

        else if (!wordToGuessArray.Contains(guess)) {
            Console.WriteLine("Wrong guess: " + guess);
            guessedLettersList.Add(guess);
            Game.lives--;
            if (Game.lives == 0) {
                Console.WriteLine("You lose!");
                Game.done = true;
            }
        } 
        
        else {
            Console.WriteLine();
            for (int i = 0; i < secretWordArray.Length; i++) {
                if (wordToGuessArray[i] == guess) {
                    secretWordArray[i] = wordToGuessArray[i];
                }
            }
            if (!secretWordArray.Contains('_')) {
                Console.WriteLine("You win!");
                Game.done = true;
            }
        }
    }
}