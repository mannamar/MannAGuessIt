// Amardeep Mann
// 10-20-22
// Mini CHallenge #8 - Guess it
// Randomly generate a number and have the user try to guess it

bool playAgain = true;
string playAgainResponse = "";

do
{
  Console.Clear();

  string difficulty = "";
  int difficultyNum = 0;
  bool isDiffAnInt = false;

  Console.WriteLine("We're going to play a guessing game. I'll pick a secret number and you try to guess it!");
  Console.WriteLine("\nPlease choose a difficulty:\n1 - Easy\n2 - Medium\n3 - Hard\n4 - Custom");
  while (difficultyNum > 4 || difficultyNum <= 0) {
    difficulty = Console.ReadLine();
    isDiffAnInt = Int32.TryParse(difficulty, out difficultyNum);
    if (difficultyNum > 4 || difficultyNum <= 0) {
      Console.WriteLine("Please enter a number between 1-4 corresponding to the options above");
    }
  }

  int guessThisNum = 0;
  int min = 0;
  int max = 0;
  string userValue = "";
  bool isUserValueANum = false;

  if (difficultyNum == 1) {
    min = 1; max = 10;
  } else if (difficultyNum == 2) {
    min = 1; max = 50;
  } else if (difficultyNum == 3) {
    min = 1; max = 100;
  } else if (difficultyNum == 4) {
    Console.WriteLine("\nPlease enter a minimum value");
    while (!isUserValueANum) {
      userValue = Console.ReadLine();
      isUserValueANum = Int32.TryParse(userValue, out min);
      if (!isUserValueANum) {
        Console.WriteLine("Please enter a valid number for the minimum value");
      }
    }
    isUserValueANum = false;
    Console.WriteLine("Please enter a maximum value");
    max = min;
    while (!isUserValueANum || max <= min) {
      userValue = Console.ReadLine();
      isUserValueANum = Int32.TryParse(userValue, out max);
      if (!isUserValueANum) {
        Console.WriteLine("Please enter a valid number for the maximum value");
      } else if (max <= min) {
        Console.WriteLine("Please choose a max value that's larger than " + min);
      }
    }
  }

  Random randNum = new Random();
  guessThisNum = randNum.Next(min, max+1);
  // Console.WriteLine("Debug: Random number is " + guessThisNum); // Debug
  Console.WriteLine("\nI have picked a secret number between " + min + " and " + max);

  int guesses = 0;
  string userGuess = "";
  int userGuessNum = 0;
  bool isUserGuessANum = false;

  while (userGuessNum != guessThisNum) {
    isUserGuessANum = false;
    Console.WriteLine("Guess a number any number");
    while (!isUserGuessANum) {
      userGuess = Console.ReadLine();
      isUserGuessANum = Int32.TryParse(userGuess, out userGuessNum);
    }
    if (userGuessNum < guessThisNum) {
      Console.WriteLine("The secret number is higher than your guess of " + userGuessNum);
    } else if (userGuessNum > guessThisNum) {
      Console.WriteLine("The secret number is lower than your guess of " + userGuessNum);
    }
    guesses++;
  }

  string tryVar = "tries";
  if (guesses == 1) {
    tryVar = "try";
  }

  Console.WriteLine($"\nYou got it! The secret number was {guessThisNum}. It only took you {guesses} {tryVar}. Good job!");

  Console.WriteLine("\nDo you want to play again?");
  playAgainResponse = Console.ReadLine().ToLower();
  while (playAgainResponse != "yes" && playAgainResponse != "no") {
    Console.WriteLine("Please enter either \"yes\" or \"no\"");
    playAgainResponse = Console.ReadLine().ToLower();
  }
  if (playAgainResponse == "no") {
    playAgain = false;
    Console.WriteLine("\nWe had a good run. Til next time!");
  }

} while (playAgain);