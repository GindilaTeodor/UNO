using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Uno.Providers;

public class DeckFactory : IDeckFactory
{
    private Colors[] colors = (Colors[])Enum.GetValues(typeof(Colors));
    public List<Card> CreateDeck(ICardFactory cardFactory)
    {
        List<Card> deck = new List<Card>();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Card A = cardFactory.CreateCard(i.ToString(), colors[j]);
                if (i == 0)
                {
                    deck.Add(A);
                }
                else
                {
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
                    if (j == 0)
                    {

                        Card A = cardFactory.CreateCard("O", colors[k]);
                        deck.Add(A);
                    }
                    else if (j == 1)
                    {
                        Card A = cardFactory.CreateCard("<=>", colors[k]);
                        deck.Add(A);
                    }
                    else if (j == 2)
                    {
                        Card A = cardFactory.CreateCard("+2", colors[k]);
                        deck.Add(A);

                    }
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                //3- schimba culoarea , 4- +4 carti
                if (j == 0)
                {
                    Card A = cardFactory.CreateCard("Culoare", colors[4]);
                    deck.Add(A);

                }
                else
                {
                    Card A = cardFactory.CreateCard("+4", colors[4]);
                    deck.Add(A);
                }
                
            }
        }

        return deck;
    }
}