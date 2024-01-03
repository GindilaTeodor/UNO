using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Providers;

public class ColorMatchStrategy : ICardPlayStrategy
{
    public bool CanPlay(Card tableCard, Card handCard)
    {
        return handCard.color == tableCard.color;
    }
}

public class ValueMatchStrategy : ICardPlayStrategy
{
    public bool CanPlay(Card tableCard, Card handCard)
    {
        return handCard.value == tableCard.value;
    }
}

public class WildCardStrategy : ICardPlayStrategy
{
    public bool CanPlay(Card tableCard, Card handCard)
    {
        return handCard.color == Colors.Black;
    }
}
