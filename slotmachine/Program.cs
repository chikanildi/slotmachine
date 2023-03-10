using System;
class SlotMachine
{
    const int STARTING_COINS = 100;
    const int MIN_BET = 1;
    const int MAX_BET = 1000;
    static void Main()
    {
        int coins = STARTING_COINS;
        int[,] spin = new int[3, 3];
        Random rand = new Random();
        bool playAgain = true;
        int winnings = 0;

        int numRows = spin.GetLength(0);
        int numCols = spin.GetLength(1);
        Console.WriteLine("Welcome to the Slot Machine game!");
        Console.WriteLine($"You have {coins} coins");
        while (coins > 0 && playAgain)
        {
            int matches = 0;
            Console.WriteLine($"How much would you like to bet? ({MIN_BET}-{MAX_BET})");
            Console.WriteLine();
            Console.Write("Bet:");
            int betAmount = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (betAmount > coins || betAmount > MAX_BET)
            {
                Console.WriteLine("Invalid bet amount. Please try again.");
                continue;
            }
            else
            {
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        spin[i, j] = rand.Next(0, 3);
                        Console.Write($"{spin[i, j]}\t");
                    }
                    Console.WriteLine();
                }
                // check horizontal lines
                for (int i = 0; i < 3; i++)
                {
                    if (spin[i, 0] == spin[i, 1] && spin[i, 1] == spin[i, 2])
                    {
                        matches++;
                    }
                }
                // check vertical lines
                for (int i = 0; i < 3; i++)
                {
                    if (spin[0, i] == spin[1, i] && spin[1, i] == spin[2, i])
                    {
                        matches++;
                    }
                }
                // check diagonals
                if (spin[0, 0] == spin[1, 1] && spin[1, 1] == spin[2, 2])
                {
                    matches++;
                }
                if (spin[2, 0] == spin[1, 1] && spin[1, 1] == spin[0, 2])
                {
                    matches++;
                }
                if (matches > 0)
                {
                    winnings = matches * betAmount;
                    coins += winnings;
                    Console.WriteLine();
                    Console.WriteLine($"The number of matches:{matches}");
                    Console.WriteLine($"You won {winnings} dollars!");
                }
                else
                {
                    Console.WriteLine("\nSorry, you lost.");
                    coins -= betAmount;

                }
                Console.WriteLine($"You have {coins} coins");
                Console.WriteLine("Would you like to play again? (y/n)");
                string playAgainStr = Console.ReadLine();
                if (playAgainStr == "y")
                {
                    playAgain = true;
                    matches = 0;
                }
                else
                {
                    playAgain = false;
                }
            }
        }
    }
}