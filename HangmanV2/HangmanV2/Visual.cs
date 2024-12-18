namespace HangmanV2;
public abstract class Visual {
    private static string[,] hangmanMatrix =  {
        {" ", " ", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═", "═"},
        {" ", " ", "│", "│", " ", "/", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│", " "}, 
        {" ", " ", "│", "│", "/", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
        {" ", " ", "│", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "}, 
        {" ", " ", "│", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
        {" ", " ", "│", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
        {" ", " ", "│", "│", " ", "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "}, //x is the position of the guessed letters
        {" ", " ", "│", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
        {"┌", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "┐", " ", " ", "y", " ", " "}  //y is the position of the word in 'secret' form

    };
    public static void draw() {
        switch (Game.lives) {
            case 5: hangmanMatrix[2,16] = "o" ; break;    
            case 4: hangmanMatrix[3,16] = "║";  break;
            case 3: hangmanMatrix[3,15] = "/";  break;
            case 2: hangmanMatrix[3,17] = "\\"; break;
            case 1: hangmanMatrix[4,15] = "/";  break;
            case 0: hangmanMatrix[4,17] = "\\"; break;    
        }
        
        hangmanMatrix[6, 5] = Guess.guessedLetters();
        hangmanMatrix[8,15] = Guess.progress();
        
        for (int i = 0; i < hangmanMatrix.GetLength(0); i++) {
            for (int j = 0; j < hangmanMatrix.GetLength(1); j++) {
                Console.Write(hangmanMatrix[i, j]);
                if (j == 17) {
                    Console.WriteLine();
                }
            }
        }
    }
}