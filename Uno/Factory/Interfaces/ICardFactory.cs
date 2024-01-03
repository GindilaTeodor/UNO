using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Providers;

    public interface ICardFactory
    {
        Card CreateCard(string value, Colors color);
    }

