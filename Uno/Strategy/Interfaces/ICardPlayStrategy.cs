using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Providers;

public interface ICardPlayStrategy
{
    bool CanPlay(Card tableCard, Card handCard);
}