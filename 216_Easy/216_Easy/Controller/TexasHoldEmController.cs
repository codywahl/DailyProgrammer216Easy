using _216_Easy.Model;
using System;
using System.Collections.Generic;

namespace _216_Easy
{
    public class TexasHoldEmController
    {
        public string PlayAGameOfTexasHoldEm(string playerName, int numberOfPlayers)
        {
            List<Player> players = new List<Player>();
            DeckOfCards deck = new DeckOfCards();
            CommunityCards communityCards = new CommunityCards();

            string gameResults = Environment.NewLine;

            players.Add(new Player() { Name = playerName });

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                players.Add(new Player() { Name = "CPU" + i.ToString() });
            }

            foreach (Player player in players)
            {
                player.CardOne = deck.GetCardFromTopOfDeck();
                player.CardTwo = deck.GetCardFromTopOfDeck();

                gameResults += player.Name + "'s Hand: " + player.CardOne + ", " + player.CardTwo + Environment.NewLine;
            }

            gameResults += Environment.NewLine;

            //Burn a card
            deck.GetCardFromTopOfDeck();

            //The Flop
            communityCards.Flop1 = deck.GetCardFromTopOfDeck();
            communityCards.Flop2 = deck.GetCardFromTopOfDeck();
            communityCards.Flop3 = deck.GetCardFromTopOfDeck();
            gameResults += "The Flop: " + communityCards.Flop1 + ", " + communityCards.Flop2 + ", " + communityCards.Flop3 + Environment.NewLine;

            //Burn a card
            deck.GetCardFromTopOfDeck();

            //The Turn
            communityCards.Turn = deck.GetCardFromTopOfDeck();
            gameResults += "The Turn: " + communityCards.Turn + Environment.NewLine;

            //Burn a card
            deck.GetCardFromTopOfDeck();

            //The River
            communityCards.River = deck.GetCardFromTopOfDeck();
            gameResults += "The River: " + communityCards.River + Environment.NewLine;

            return gameResults;
        }
    }
}