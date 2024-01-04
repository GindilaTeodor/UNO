using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows;
using Uno.Factory;
using Uno.Model;
using Uno.Providers;

namespace Uno.ViewModel
{
    public class CardsVM : INotifyPropertyChanged
    {
        private CardsModel _cardsModel;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Card> _hand;
        public ObservableCollection<Card> Hand
        {
            get { return _hand; }
            set
            {
                _hand = value;
                OnPropertyChanged(nameof(Hand));
            }
        }

        private ObservableCollection<Card> _aiHand;
        public ObservableCollection<Card> AIHand
        {
            get { return _aiHand; }
            set
            {
                _aiHand = value;
                OnPropertyChanged(nameof(AIHand));
            }
        }

        private Card _table;
        public Card Table
        {
            get { return _table; }
            set
            {
                _table = value;
                OnPropertyChanged(nameof(Table));
            }
        }

        public CardsVM()
        {
            ICardFactory cardFactory = new CardFactory();
            IDeckFactory deckFactory = new DeckFactory(); // Replace with your actual DeckFactory
            ICardPlayStrategy colorStrategy = new ColorMatchStrategy();
            ICardPlayStrategy valueStrategy = new ValueMatchStrategy();
            ICardPlayStrategy wildStrategy = new WildCardStrategy();
            List<ICardPlayStrategy> strategies = new List<ICardPlayStrategy>();
            strategies.Add(colorStrategy);
            strategies.Add(valueStrategy);
            strategies.Add(wildStrategy);
            _cardsModel = new CardsModel(cardFactory, deckFactory, strategies);
            Hand = new ObservableCollection<Card>();
            AIHand = new ObservableCollection<Card>();
            InitializeGame();
        }

        public void InitializeGame()
        {
           // await GenerateDeckAsync();
            _cardsModel.generateDeck();

            Hand = new ObservableCollection<Card>(_cardsModel.hand);
            AIHand = new ObservableCollection<Card>(_cardsModel.AIhand);
            Table = _cardsModel.table;
        }



        public void PlayCard(Card a)
                
        {
            
                if (_cardsModel.playCard(a))
                {
                Table = a;
                Hand.Remove(a);
                OnPropertyChanged(nameof(Hand));  // Notify UI that Hand has changed
                OnPropertyChanged(nameof(Table));
            }      
        }

        public bool AIPlayCard(Card a)
        {
            if (_cardsModel.AIplayCard(a))
            {
                Table = a;
                AIHand.Remove(a);  
                OnPropertyChanged(nameof(Table));
                return true;
            }
            return false;
        }

       public void Take()
        {

            if (Hand.Any())
            {
                _cardsModel.takeCard();

                // Dispatch UI update to the main/UI thread
              
                    Hand = new ObservableCollection<Card>(_cardsModel.hand);
               
            }

        }
        public void AITake()
        {

            _cardsModel.AItakeCard();
            
                AIHand = new ObservableCollection<Card>(_cardsModel.AIhand);
            

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

