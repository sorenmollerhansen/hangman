namespace HangmanV2;
public abstract class Game {
    public static string wordToGuess = "penguin".ToUpper(); //default word to guess
    public static int lives = 6;
    public static bool done;
    
    
    static void Main() {
        Console.WriteLine("Welcome to Hangman!");
        Guess.start();
        Visual.draw();
        
        while (!done) { 
            Guess.takeGuess(); 
            Visual.draw();
        }
    }
}
