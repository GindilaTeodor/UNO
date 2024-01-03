using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Providers;

namespace Uno.Factory
{
    public class CardFactory : ICardFactory
    {
        public Card CreateCard(string value, Colors color)
        {
            return new Card { value = value, color = color };
        }
    }
}
