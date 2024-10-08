//the word(s) to be guessed - can contain numbers(but probably shouldn't), spaces and "," "." "-" "!"
string wordToGuess = "type here".ToUpper();

//number of lives - hangman standard is 6 (head, torso, two arms, two legs)
int lives = 6;

hangmanGame();
void hangmanGame()
{
//strings to keep track of the wordToGuess
    string[] wordToGuessArr = new string[wordToGuess.Length]; //array of the word to be guessed
    for (int i = 0; i < wordToGuess.Length; i++)
    {
        wordToGuessArr[i] =
            Convert.ToString(wordToGuess[i]); //converts the char-elements to strings, to place them in the string array
    }

    string[] secretWord = new string[wordToGuess.Length]; //array of the word to be guessed, but in "secret form"
    for (int i = 0; i < secretWord.Length; i++)
    {
        if (wordToGuessArr[i] == " " || wordToGuessArr[i] == "." || wordToGuessArr[i] == "," || wordToGuessArr[i] == "-" || wordToGuessArr[i] == "!")
        {
            secretWord[i] = wordToGuessArr[i] + " "; //creates a space/sign in the secret word 
        }
        else
        {
            secretWord[i] = "_ "; //creates the "_" spots for the secret word
        }
    }

//guessed letters
    string[] guessedLetters = new string[lives]; //array of guessed letters
    int indexOfGuessedLetters = 0; //index to keep track of the array above

    while (wordGuessed() == false)
    {
        if (lives == 0) //user runs out of lives
        {
            printProgress();
            draw();
            Console.WriteLine("Sorry, you lose!"); //you lose when you run out of lives
            break;
        }
        else
        {
            getGuess();
        }
        if (wordGuessed() == true) //if the word is guessed, you win
        {
            printProgress();
            draw();
            Console.WriteLine("You win!");
        }
    }

    bool wordGuessed()
    {
        if (secretWord.Contains("_ "))
        {
            return false; //if the secret word contains "_", the word has not been guessed yet
        }
        else
        {
            return true;
        }
    }

    void printProgress()
    {
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            Console.Write(
                secretWord[i]); //prints the progress of the guessing, by looping through the word in secret form
        }

        Console.WriteLine();
    }

    void removeLife()
    {
        lives--;
    }

    void draw()
    {
        switch (lives)
                {
                    case 6:
                    {
                        Console.WriteLine("{0,7}","______");
                        Console.WriteLine("{0,1}{1}{0,6}", "|", "/");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("{0,7}","______");
                        Console.WriteLine("{0,1}{1}{0,6}", "|", "/");
                        Console.Write("{0,1}", "|");
                        Console.WriteLine("{0,7}", "O");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("{0,7}","______");
                        Console.WriteLine("{0,1}{1}{0,6}", "|", "/");
                        Console.Write("{0,1}", "|");
                        Console.WriteLine("{0,7}", "O");
                        Console.Write("{0,1}", "|");
                        Console.WriteLine("{0,7}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("{0,7}","______");
                        Console.WriteLine("{0,1}{1}{0,6}", "|", "/");
                        Console.Write("{0,1}", "|");
                        Console.WriteLine("{0,7}", "O");
                        Console.Write("{0,1}", "|");
                        Console.Write("{0,6}","/");
                        Console.WriteLine("{0}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("{0,7}","______");
                        Console.WriteLine("{0,1}{1}{0,6}", "|", "/");
                        Console.Write("{0,1}", "|");
                        Console.WriteLine("{0,7}", "O");
                        Console.Write("{0,1}", "|");
                        Console.Write("{0,6}","/");
                        Console.Write("{0}", "|");
                        Console.WriteLine("{0}", "\\");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine();
                        break;
                    }
                    case 1:
                    {
                        Console.WriteLine("{0,7}","______");
                        Console.WriteLine("{0,1}{1}{0,6}", "|", "/");
                        Console.Write("{0,1}", "|");
                        Console.WriteLine("{0,7}", "O");
                        Console.Write("{0,1}", "|");
                        Console.Write("{0,6}","/");
                        Console.Write("{0}", "|");
                        Console.WriteLine("{0}", "\\");
                        Console.Write("{0,1}", "|");
                        Console.WriteLine("{0,6}", "/");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine();
                        break;
                    }
                    case 0:
                    {
                        Console.WriteLine("{0,7}","______");
                        Console.WriteLine("{0,1}{1}{0,6}", "|", "/");
                        Console.Write("{0,1}", "|");
                        Console.WriteLine("{0,7}", "O");
                        Console.Write("{0,1}", "|");
                        Console.Write("{0,6}","/");
                        Console.Write("{0}", "|");
                        Console.WriteLine("{0}", "\\");
                        Console.Write("{0,1}", "|");
                        Console.Write("{0,6}", "/");
                        Console.WriteLine("{0,2}", "\\");
                        Console.WriteLine("{0,1}", "|");
                        Console.WriteLine();
                        break;
                    }   
                } //draws the gallow and man in ASCII
    }

    void formatting()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }
    
//user input
    void getGuess()
    {
        printProgress();
        draw();
        for (int i = 0; i < indexOfGuessedLetters; i++)
        {
            Console.Write(guessedLetters[i] + " "); //prints all wrong, guessed letters
        }
        Console.WriteLine();
        Console.Write("Guess a letter: ");
        string guess = (Console.ReadLine().ToUpper());
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (guessedLetters.Contains(guess) || secretWord.Contains(guess + " ")) //guess has already been guessed - invalid
            {
                formatting();
                Console.WriteLine(guess + " has already been tried - guess again!");
                break;
            }

            if (guess.Length != 1) //guess is more than one character - invalid
            {
                formatting();
                Console.WriteLine("Guesses can only be one letter - guess again!");
                break;
            }
            
            if (wordToGuess.Contains(guess) && guess.Length == 1) //guess is in "wordToGuess" and is only one character - valid 
            {
                formatting();
                for (int j = 0; j < wordToGuess.Length; j++)
                {
                    if (guess == wordToGuessArr[j]) //checks if the guess is in any of the "wordToGuessArr" indexes
                    {
                        secretWord[j] = guess + " "; //if the guess is in the "wordToGuessArr", it changes all matching positions in the secretWord to the guess
                    }
                }
                break;
            }

            if (guess.Length == 1 && (guessedLetters.Contains(guess) == false)) //if the guess is valid, but wrong
            {
                formatting();
                removeLife();
                guessedLetters[indexOfGuessedLetters] = guess; //the guess is put in the "guessedLetters" array in index "indexOfGuessedLetters"
                indexOfGuessedLetters++; //indexOfGuessedLetters is increased, when there is a wrong guess
                break;
            }
        }
    }
}