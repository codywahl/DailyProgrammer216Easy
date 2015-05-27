using System;
using System.Collections.Generic;

namespace _216_Easy.Model
{
    public class DeckOfCards
    {
        private readonly List<string> CardValues = new List<string>
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "Jack", "Queen", "King", "Ace"
        };

        private readonly List<string> Suits = new List<string>
        {
            "Hearts", "Clubs", "Spades", "Diamonds"
        };

        private List<string> TheDeck = new List<string>();

        public DeckOfCards()
        {
            NewDeck();
        }

        public void NewDeck()
        {
            MakeNewDeck();
            ShuffleDeck();
        }

        public string GetCardFromTopOfDeck()
        {
            if (TheDeck.Count > 0)
            {
                string card = TheDeck[TheDeck.Count - 1];
                TheDeck.RemoveAt(TheDeck.Count - 1);

                return card;
            }

            return null;
        }

        private void MakeNewDeck()
        {
            TheDeck = new List<string>();

            foreach (string cardValue in CardValues)
            {
                foreach (string suit in Suits)
                {
                    TheDeck.Add(cardValue + " of " + suit);
                }
            }
        }

        private void ShuffleDeck()
        {
            Random rng = new Random();
            int n = TheDeck.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = TheDeck[k];
                TheDeck[k] = TheDeck[n];
                TheDeck[n] = value;
            }
        }
    }
}