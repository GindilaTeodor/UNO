﻿using System;
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
        public List<Card> deck = new List<Card>(); 
        public List<Card> hand = new List<Card>();
        public List<Card> AIhand = new List<Card>();
        public Card table;
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
                    for (int k = 0; k < 4; k++)
                    {
                    //0- stai o tura, 1-schimba sensul, 2- +2 carti
                    Card A = new Card();
                    A.color = colors[k];
                    A.value = j+9;
                    deck.Add(A);

                    }
                }
            }
            for(int i=0;i<4; i++)
            {
                for(int j=0;j<2; j++)
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
                Console.Write(deck[i].value);
                Console.Write(deck[i].color);
                Console.Write(',');
                deck.Remove(deck[i]);

            }
           // Console.WriteLine("AI Hand");
            for (int i = 0; i < 5; i++)
            {
                AIhand.Add(deck[i]);
                deck.Remove(deck[i]);
            }
            table = deck[0];
            Console.WriteLine("Table");
            Console.Write(table.value+table.color.ToString());
            deck.Remove(table);
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
            if (card.color == table.color || table.value == card.value || card.color == colors[4])
            {
                return true;
            }
            
                return false;
        }

        public void takeCard()
        {
            hand.Add(deck[0]);
            deck.Remove(deck[0]);
        }
    }
}
