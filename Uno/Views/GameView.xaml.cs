using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Uno.Providers;
using Uno.ViewModel;

namespace Uno.Views
{
    public partial class GameView : Window
    {
        bool Wildused = false;
        public ObservableCollection<string> Hand { get; set; }
        private readonly CardsVM _cardsVM;
        public GameView(CardsVM cardsVM)
        {
            _cardsVM = cardsVM;
            InitializeComponent();

            // Set the DataContext to the provided CardsVM instance
            DataContext = cardsVM;

            // Initialize the Hand collection
            Hand = new ObservableCollection<string>();

            // Attach the PropertyChanged event handler
            cardsVM.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(cardsVM.Hand))
                {
                    
                        Hand.Clear();
                        foreach (var card in cardsVM.Hand)
                        {
                            Hand.Add(card.value.ToString());
                        }
                    
                }
            };

            // Call GenerateDeck after attaching the event handler
            // Print the number of cards (for debugging)
           

            // Add more initialization code if needed
        }

        private void More_Clicked(object sender, RoutedEventArgs e)
        {
            if (Wildused == true) { 
            if(_cardsVM.Table.value=="+2" || _cardsVM.Table.value == "+4"|| _cardsVM.Table.value == "Culoare" || _cardsVM.Table.value == "O" || _cardsVM.Table.value == "<=>" )
            {
                    if(_cardsVM.Table.value == "+2")
                    {
                        for(int i=0;i<2;i++)
                        {
                            _cardsVM.Take();
                        }
                    }
                    else if (_cardsVM.Table.value == "+4")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _cardsVM.Take();
                        }

                    }
             Wildused = false;
            }
            }
            else
            {

            _cardsVM.Take();
            AIMove();
            }
        }

        private void Play_Clicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(_cardsVM.AIHand.Count);
            if (Wildused == true)
            {
                if (_cardsVM.Table.value == "+2" || _cardsVM.Table.value == "+4" || _cardsVM.Table.value == "Culoare" || _cardsVM.Table.value == "O" || _cardsVM.Table.value == "<=>")
                {
                    if (_cardsVM.Table.value == "+2")
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            _cardsVM.Take();
                        }
                    }
                    else if (_cardsVM.Table.value == "+4")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _cardsVM.Take();
                        }

                    }
                    Wildused = false;
                    AIMove();
                }
            }
            else
            {
                Button clickedButton = (Button)sender;
                Card clickedCard = (Card)clickedButton.DataContext;
                
                bool test = _cardsVM.PlayCard(clickedCard);

                if (_cardsVM.AIHand.Count == 0 || _cardsVM.Hand.Count == 0)
                {
                    MessageBox.Show("You win");
                    MainWindow w = new MainWindow();
                    w.Show();
                    this.Close();
                }
                if (_cardsVM.Table.value == "+2" || _cardsVM.Table.value == "+4" || _cardsVM.Table.value == "Culoare" || _cardsVM.Table.value == "O" || _cardsVM.Table.value == "<=>")
                {
                    Wildused = true;
                }
                if(test)
                {
                    AIMove();
                }
            }
                

        }

        private void AIMove()
        {
            if (Wildused == true)
            {
                if (_cardsVM.Table.value == "+2" || _cardsVM.Table.value == "+4" || _cardsVM.Table.value == "Culoare" || _cardsVM.Table.value == "O" || _cardsVM.Table.value == "<=>")
                {
                    if (_cardsVM.Table.value == "+2")
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            _cardsVM.AITake();
                        }
                    }
                    else if (_cardsVM.Table.value == "+4")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _cardsVM.AITake();
                        }

                    }
                    Wildused = false;
                }
            }
            else
            {
                bool CardPlayed = false;
                for (int i = 0; i < _cardsVM.AIHand.Count; i++)
                {
                    if (_cardsVM.AIPlayCard(_cardsVM.AIHand[i]))
                    {
                        CardPlayed = true;
                        if (_cardsVM.Table.value == "+2" || _cardsVM.Table.value == "+4" || _cardsVM.Table.value == "Culoare" || _cardsVM.Table.value == "O" || _cardsVM.Table.value == "<=>")
                        {
                            Wildused = true;
                        }
                        break;
                    }
                }
                if (_cardsVM.AIHand.Count == 0)
                {
                    MessageBox.Show("You Lost");
                    MainWindow w = new MainWindow();
                    w.Show();
                    this.Close();
                }
                if (CardPlayed == false)
                {
                    _cardsVM.AITake();
                }
            }
        }
    }
}
