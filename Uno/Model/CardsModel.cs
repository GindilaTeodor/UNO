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
        private Colors[] colors = (Colors[])Enum.GetValues(typeof(Colors));
        private List<Card> deck = new List<Card>();
        private List<Card> hand { set; get; }
        private List<Card> AIhand { set; get; }
        private Card table;
        public void generateDeck()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card A = new Card();
                    if (i == 0)
                    {
                        A.value = i;
                        A.color = colors[j];
                        deck.Add(A);
                    }
                    else
                    {
                        A.value = i;
                        A.color = colors[j];
                        deck.Add(A);
                        deck.Add(A);
                    }

                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //0- stai o tura, 1-schimba sensul, 2- +2 carti
                    Card A = new Card();
                    A.color = colors[4];
                    A.value = j;
                    deck.Add(A);
                }
            }
            for(int i=0;i<4; i++)
            {
                for(int j=3;j<5; j++)
                {
                    //3- schimba culoarea , 4- +4 carti
                    Card A = new Card();
                    A.color = colors[4];
                    A.value = j;
                    deck.Add(A);
                }
            }
        }
        public void  getDeck()
        {
            Shuffle(deck);
            for (int i = 0; i < 5; i++)
            {
                hand.Add(deck[i]);
                deck.Remove(deck[i]);
                Console.Write(deck[i].value);
                Console.WriteLine(deck[i].color);

            }
            Console.WriteLine("AI Hand");
            for (int i = 0; i < 5; i++)
            {
                AIhand.Add(deck[i]);
                deck.Remove(deck[i]);
                Console.Write(deck[i].value);
                Console.WriteLine(deck[i].color);
            }
            table = deck[0];
            Console.WriteLine("Table");
            Console.Write(deck[0]);
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


        bool playCard(Card card)
        {
            if (card.color == table.color || table.value == card.value || card.color == colors[4])
            {
                return true;
            }
            
                return false;
        }
    }
}
