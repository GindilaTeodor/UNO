using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Factory;
using Uno.Providers;

public interface IDeckFactory
{
    List<Card> CreateDeck(ICardFactory cardFactory);
}