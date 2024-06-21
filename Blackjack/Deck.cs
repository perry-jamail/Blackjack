using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Deck
    {
        Random rand = new Random();

        List<Card> hearts = new List<Card>
        {
            new Card("Two of Hearts", "Hearts", 2),
            new Card("Three of Hearts", "Hearts", 3),
            new Card("Four of Hearts", "Hearts", 4),
            new Card("Five of Hearts", "Hearts", 5),
            new Card("Six of Hearts", "Hearts", 6),
            new Card("Seven of Hearts", "Hearts", 7),
            new Card("Eight of Hearts", "Hearts", 8),
            new Card("Nine of Hearts", "Hearts", 9),
            new Card("Ten of Hearts", "Hearts", 10),
            new Card("Jack of Hearts", "Hearts", 10),
            new Card("Queen of Hearts", "Hearts", 10),
            new Card("King of Hearts", "Hearts", 10),
            new Card("Ace of Hearts", "Hearts", 11)
        };

        List<Card> spades = new List<Card>
        {
            new Card("Two of Spades", "Spades", 2),
            new Card("Three of Spades", "Spades", 3),
            new Card("Four of Spades", "Spades", 4),
            new Card("Five of Spades", "Spades", 5),
            new Card("Six of Spades", "Spades", 6),
            new Card("Seven of Spades", "Spades", 7),
            new Card("Eight of Spades", "Spades", 8),
            new Card("Nine of Spades", "Spades", 9),
            new Card("Ten of Spades", "Spades", 10),
            new Card("Jack of Spades", "Spades", 10),
            new Card("Queen of Spades", "Spades", 10),
            new Card("King of Spades", "Spades", 10),
            new Card("Ace of Spades", "Spades", 11)
        };

        List<Card> diamonds = new List<Card>
        {
            new Card("Two of Diamonds", "Diamonds", 2),
            new Card("Three of Diamonds", "Diamonds", 3),
            new Card("Four of Diamonds", "Diamonds", 4),
            new Card("Five of Diamonds", "Diamonds", 5),
            new Card("Six of Diamonds", "Diamonds", 6),
            new Card("Seven of Diamonds", "Diamonds", 7),
            new Card("Eight of Diamonds", "Diamonds", 8),
            new Card("Nine of Diamonds", "Diamonds", 9),
            new Card("Ten of Diamonds", "Diamonds", 10),
            new Card("Jack of Diamonds", "Diamonds", 10),
            new Card("Queen of Diamonds", "Diamonds", 10),
            new Card("King of Diamonds", "Diamonds", 10),
            new Card("Ace of Diamonds", "Diamonds", 11)
        };

        List<Card> clubs = new List<Card>
        {
            new Card("Two of Clubs", "Clubs", 2),
            new Card("Three of Clubs", "Clubs", 3),
            new Card("Four of Clubs", "Clubs", 4),
            new Card("Five of Clubs", "Clubs", 5),
            new Card("Six of Clubs", "Clubs", 6),
            new Card("Seven of Clubs", "Clubs", 7),
            new Card("Eight of Clubs", "Clubs", 8),
            new Card("Nine of Clubs", "Club ", 9),
            new Card("Ten of Clubs", "Clubs", 10),
            new Card("Jack of Clubs", "Clubs", 10),
            new Card("Queen of Clubs", "Clubs", 10),
            new Card("King of Clubs", "Clubs", 10),
            new Card("Ace of Clubs", "Clubs", 11)
        };

        public List<Card> deck;

        public Deck()
        {
            deck = new List<Card>();

            foreach (Card card in hearts)
            {
                deck.Add(card);
            }

            foreach (Card card in spades)
            {
                deck.Add(card);
            }

            foreach (Card card in diamonds)
            {
                deck.Add(card);
            }

            foreach (Card card in clubs)
            {
                deck.Add(card);
            }
        }

        public Card Draw()
        {
            Card drawnCard = deck[rand.Next(0, deck.Count)];
            deck.Remove(drawnCard);
            return drawnCard;
        }
    }
}
