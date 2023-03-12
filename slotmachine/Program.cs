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

        Console.WriteLine("Welcome to the Slot Machine game!");
        Console.WriteLine($"You have {coins} coins");

        while (true)
        {
            int winnings = 0; // added this line to reset winnings to zero
            Console.WriteLine($"How much would you like to bet? ({MIN_BET}-{MAX_BET})"); Console.Write("Bet: ");
            int betAmount = int.Parse(Console.ReadLine());

            if (betAmount < MIN_BET || betAmount > MAX_BET)
            {
                Console.WriteLine("Invalid bet amount. Please try again.");
                continue;
            }

            if (coins < betAmount)
            {
                Console.WriteLine("You don't have enough coins to place that bet.");
                continue;
            }

            coins -= betAmount;

            for (int i = 0; i < spin.GetLength(0); i++)
            {
                for (int j = 0; j < spin.GetLength(1); j++)
                {
                    spin[i, j] = rand.Next(0, 3);
                    Console.Write($"{spin[i, j]}\t");
                }
                Console.WriteLine();
            }

            int matches = 0;

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
                Console.WriteLine($"The number of matches: {matches}");
                Console.WriteLine($"You won {winnings} dollars!");
            }

            else
            {

                if (coins <= 0)
                {
                    Console.WriteLine("You are out of coins");
                    Console.WriteLine("\nSorry, you lost.");
                    Console.ReadLine();
                }

            }


            Console.WriteLine($"You have {coins} coins");
            Console.Write("Would you like to play again? (y/n) ");
            string playAgainStr = Console.ReadLine();

            if (playAgainStr.ToLower() == "y")
            {
                playAgain = true;
            }
            else
            {
                return;
            }

            Console.WriteLine();
        }
    }
}
