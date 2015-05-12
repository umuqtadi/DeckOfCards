using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Game
    {
        static void Main(string[] args)
        {
            
        }
    }


    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
	//     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
	//     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
	//     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
	//         discard pile	
    // 
    // A deck knows the following information about itself:
	//     int CardsRemaining -- number of cards left in the deck
	//     List<Card> DeckOfCards -- card waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played
    class Deck
    {
            public int CardsRemaining
            {
                get
                {
                    return DeckOfCards.Count();
                }
            }
            public List<Card> DeckOfCards;
            public List<Card> DiscardedCards;

            public Deck()
                : this(1)
            {

            }
            public Deck(int numberOfDecks)
            {
                DeckOfCards = new List<Card>();
                DiscardedCards = new List<Card>();
                for (int k = 0; k < numberOfDecks; k++)
                {
                    //Init deck with 52 cards
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 2; j < 15; j++)
                        {
                            DeckOfCards.Add(new Card((Card.CardRank)j, (Card.CardSuit)i));
                        }
                    }
                }

            }

            public void Discard(List<Card> cards)
            {
                foreach (Card oneCard in cards)
                {
                    DeckOfCards.Remove(oneCard);
                    DiscardedCards.Add(oneCard);
                }
            }
            public void Discard(Card card)
            {
                DeckOfCards.Remove(card);
                DiscardedCards.Add(card);
            }

            public List<Card> Deal(int numberOfCards)
            {
                // Get cards to deal
                List<Card> dealtCards = DeckOfCards.Take(numberOfCards).ToList<Card>();
                // Remove each card from the DeckOfCards
                foreach (Card oneCard in dealtCards)
                {
                    DeckOfCards.Remove(oneCard);
                }
                // return dealt cards
                return dealtCards;
            }
            public void Shuffle()
            {
                Random rng = new Random();
                List<Card> tempDeck = new List<Card>();

                // While the deck has cards
                while (DeckOfCards.Count > 0)
                {
                    // Pick random card
                    Card tempCard = DeckOfCards.ElementAt(rng.Next(DeckOfCards.Count));
                    // Remove random card from deck
                    DeckOfCards.Remove(tempCard);
                    // Add it to temp deck
                    tempDeck.Add(tempCard);
                }
                // Set random card list to our Deck
                DeckOfCards = tempDeck;
            }
    }

    
    // What makes a card?
	//     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
    //     These enumerations should be "Suit" and "Rank"
    class Card
    {
        public enum CardSuit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public enum CardRank
        {
            two = 2,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
            ten,
            Jack,
            Queen,
            King,
            Ace
        }
        public CardSuit Suit { get; set; }
        public CardRank Rank { get; set; }

        public Card(Card.CardRank rank, Card.CardSuit suit)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
    }
}
