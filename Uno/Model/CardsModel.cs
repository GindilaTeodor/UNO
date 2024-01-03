using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Providers;

namespace Uno.Model
{
    internal class CardsModel
    {
        private ICardFactory cardFactory;
        private IDeckFactory deckFactory;
        private List<ICardPlayStrategy> playStrategies = new List<ICardPlayStrategy>();

        public CardsModel(List<ICardPlayStrategy> strategies)
        {
            this.playStrategies = strategies;
        }

        public CardsModel(ICardFactory cardFactory, IDeckFactory deckFactory, List<ICardPlayStrategy> strategies)
        {
            this.cardFactory = cardFactory;
            this.deckFactory = deckFactory;
            this.playStrategies = strategies;
            //generateDeck();
        }


        private Colors[] colors = (Colors[])Enum.GetValues(typeof(Colors));
        public List<Card> deck = new List<Card>();
        public List<Card> hand = new List<Card>();
        public List<Card> AIhand = new List<Card>();
        public Card table;

        public List<Card> GetDeck()
        {
            return deck;
        }

        public void generateDeck()
        {
            deck.Clear();
            List<Card> newDeck = deckFactory.CreateDeck(cardFactory);
            deck = newDeck;
            Shuffle(deck);
            for(int i = 0;i<5;i++)
            {
                hand.Add(deck[i]);
            }
            deck.RemoveRange(0, Math.Min(5, deck.Count));
            for (int i = 0; i < 5; i++)
            {
                AIhand.Add(deck[i]);
            }
            deck.RemoveRange(0, Math.Min(5, deck.Count));
            table = deck[0];
            deck.RemoveRange(0, Math.Min(1, deck.Count));
        }
        void ShuffleDeck()
        {
            Shuffle(deck);

        }

        void Shuffle<T>(List<T> list)
        {
            Random random = new Random();

            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                // Swap list[i] and list[j]
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }


        public bool playCard(Card card)
        {
            bool CanPlay = false;
            if (playStrategies[0].CanPlay(table,card) || playStrategies[1].CanPlay(table, card)|| playStrategies[2].CanPlay(table, card) || table.color==Colors.Black)
            {
                CanPlay = true;
                table = card;
                hand.Remove(card);
            }
            return CanPlay;
        }

        public bool AIplayCard(Card card)
        {
            bool CanPlay = false;
            if (playStrategies[0].CanPlay(table, card) || playStrategies[1].CanPlay(table, card) || playStrategies[2].CanPlay(table, card) || table.color == Colors.Black)
            {
                CanPlay = true;
                table = card;
                AIhand.Remove(card);
            }
            return CanPlay;
        }

        public void takeCard()
        {
            hand.Add(deck[0]);
            deck.Remove(deck[0]);
        }
        public void AItakeCard()
        {
            AIhand.Add(deck[0]);
            deck.Remove(deck[0]);
        }
    }
}
