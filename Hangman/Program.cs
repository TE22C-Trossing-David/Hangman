using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

string word = "spela spel".ToLower();

string[] hiddenWord = wordToLength(word);

List<string> correctGuess = new();
List<string> wrongGuess = new();

int lives = 5;

while (true)
{
    Console.Clear();

    bool guessedSpace = false;

    for (int i = 0; i < word.Length; i++)
    {
        if (word[i] == ' ')
        {
            correctGuess.Add(" ");
        }
    }

    System.Console.WriteLine("Välkommen till hangman :(");

    while (wrongGuess.Count < lives && string.Join("", hiddenWord) != word)
    {
        guessedSpace = false;
        int currentLives = lives - wrongGuess.Count;


        Console.WriteLine(string.Join(" ", hiddenWord));

        System.Console.WriteLine("\n Gissa ett bokstav");
        System.Console.WriteLine("\n Lives:" + currentLives);

        string guess = Console.ReadLine().ToLower();

        if (guess == "")
        {
            Console.Clear();
            System.Console.WriteLine("Bro just type a word");
            guessedSpace = true;
        }
        if (guessedSpace == false)
        {
            if (word.Contains(guess[0]))
            {
                Console.Clear();
                Console.WriteLine("yippie");

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == guess[0])
                    {
                        hiddenWord[i] = guess[0].ToString();
                        correctGuess.Add(guess);
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("buhhh");
                wrongGuess.Add(guess);
            }
        }

    }
    if (string.Join("", hiddenWord) == word)
    {
        Console.Clear();
        Console.WriteLine(string.Join(" ", hiddenWord));
        Console.WriteLine("Congrats you won!");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("YOU ARE FUCKING STUPID YOU RETARDED BITCH");
    }

    while (true)
    {
        System.Console.WriteLine("Klicka på enter för att köra om");
        Console.ReadLine();
        hiddenWord = wordToLength(word);
        wrongGuess.Clear();
        break;
    }
}


static string[] wordToLength(string word)
{

    string[] underscores = new string[word.Length];
    for (int i = 0; i < word.Length; i++)
    {
        underscores[i] = "_";
        if (word[i] == ' ')
        {
            underscores[i] = " ";
        }
    }
    return underscores;
}

