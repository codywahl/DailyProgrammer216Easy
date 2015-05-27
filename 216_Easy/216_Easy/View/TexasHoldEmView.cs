using System;

namespace _216_Easy.View
{
    public class TexasHoldEmView
    {
        private const string welcomeMessage = "Welcome to Texas Hold Em!\n";
        private const string playerNameQuestion = "What is your name?: ";

        private const string numberOfPlayersQuestion = "How many other players would you like there to be? (1-7): ";
        private const string playAgainQuestion = "Do you want to play again? (Y/N): ";

        private string PlayerName;
        private int NumberOfPlayers;
        private TexasHoldEmController Game = new TexasHoldEmController();

        public void Run()
        {
            Console.WriteLine(welcomeMessage);

            GetPlayerName();
            bool continuePlaying = false;

            do
            {
                GetNumberOfPlayers();

                Console.WriteLine(Game.PlayAGameOfTexasHoldEm(PlayerName, NumberOfPlayers));

                continuePlaying = PlayAgain();
            } while (continuePlaying);
        }

        private void GetPlayerName()
        {
            bool validInput = false;
            string input = "";

            do
            {
                Console.Write(playerNameQuestion);
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    validInput = true;
                }

                if (!validInput)
                {
                    Console.WriteLine("Invalid name. Please try again!");
                }
            } while (!validInput);

            PlayerName = input;
        }

        private void GetNumberOfPlayers()
        {
            bool validInput = false;
            int input = int.MinValue;

            do
            {
                Console.Write(numberOfPlayersQuestion);

                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= 1 && input <= 7)
                    {
                        validInput = true;
                    }
                }

                if (!validInput)
                {
                    Console.WriteLine("Invalid number of players. Please try again!");
                }
            } while (!validInput);

            NumberOfPlayers = input;
        }

        private bool PlayAgain()
        {
            bool validInput = false;
            string input = "";

            do
            {
                Console.WriteLine(playAgainQuestion);

                input = Console.ReadLine().ToLower();

                if (input.Equals("y") || input.Equals("n"))
                {
                    validInput = true;
                }

                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please try again");
                }
            } while (!validInput);

            return input.Equals("y");
        }
    }
}