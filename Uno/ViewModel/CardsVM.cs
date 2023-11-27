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
        public void startGame()
        {
            _cardsModel.generateDeck();
        
        }
    }

}
