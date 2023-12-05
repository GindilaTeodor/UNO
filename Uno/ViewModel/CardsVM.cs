using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Uno.Model;
using Uno.Providers;

namespace Uno.ViewModel
{
    internal class CardsVM
    {
        private CardsModel _cardsModel=new CardsModel();
        private List<Card> deck=new List<Card>();
        private Card table = new Card();
        private List<Card> hand = new List<Card>();
        private List<Card> AIhand = new List<Card>();
        bool isFinished = false;
        public void startGame()
    {
            _cardsModel.generateDeck();
            _cardsModel.getDeck();
            deck = _cardsModel.deck;
            hand = _cardsModel.hand;
            AIhand = _cardsModel.AIhand;
            table=_cardsModel.table;
            Play();
        }

        public void Play()
        {
            for(int i = 0; i < hand.Count; i++)
            {
                if (_cardsModel.playCard(hand[i])==true)
                {
                    Console.Write(hand[i].value + hand[i].color.ToString()+"can be played");
                }
                else
                {
                    Console.Write(hand[i].value + hand[i].color.ToString() + "cant be played");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Testare tras carte");
            _cardsModel.takeCard();
            hand = _cardsModel.hand;
            for (int j = 0; j < hand.Count; j++)
            {
                Console.WriteLine("test");
                Console.Write(hand[j].value);
                Console.Write(hand[j].color);
                Console.Write(',');

            }

        }
    }

   

}
