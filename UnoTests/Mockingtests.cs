using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Uno.Model;
using Uno.Providers;

[TestClass]
public class CardsModelTests
{
    [TestMethod]
    public void PlayCard_ShouldPlayCardSuccessfully()
    {
        // Arrange
        var cardFactoryMock = new Mock<ICardFactory>();
        var deckFactoryMock = new Mock<IDeckFactory>();
        var cardMock = new Mock<Card>();
        var strategiesMock = new Mock<ICardPlayStrategy>();

        var cardsModel = new CardsModel(cardFactoryMock.Object, deckFactoryMock.Object, new List<ICardPlayStrategy> { strategiesMock.Object });

        // Setup behavior of the mocks
        deckFactoryMock.Setup(factory => factory.CreateDeck(cardFactoryMock.Object)).Returns(new List<Card> { cardMock.Object });
        strategiesMock.Setup(strategy => strategy.CanPlay(It.IsAny<Card>(), It.IsAny<Card>())).Returns(true);

        // Act
        //cardsModel.generateDeck();
        var result = cardsModel.playCard(cardMock.Object);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(cardMock.Object, cardsModel.table);
        Assert.IsFalse(cardsModel.hand.Contains(cardMock.Object));
    }

    [TestMethod]
    public void AIPlayCard_ShouldPlayCardSuccessfully()
    {
        // Arrange
        var cardFactoryMock = new Mock<ICardFactory>();
        var deckFactoryMock = new Mock<IDeckFactory>();
        var cardMock = new Mock<Card>();
        var strategiesMock = new Mock<ICardPlayStrategy>();

        var cardsModel = new CardsModel(cardFactoryMock.Object, deckFactoryMock.Object, new List<ICardPlayStrategy> { strategiesMock.Object });

        // Setup behavior of the mocks
        deckFactoryMock.Setup(factory => factory.CreateDeck(cardFactoryMock.Object)).Returns(new List<Card> { cardMock.Object });
        strategiesMock.Setup(strategy => strategy.CanPlay(It.IsAny<Card>(), It.IsAny<Card>())).Returns(true);

        // Act
       // cardsModel.generateDeck();
        var result = cardsModel.AIplayCard(cardMock.Object);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(cardMock.Object, cardsModel.table);
        Assert.IsFalse(cardsModel.AIhand.Contains(cardMock.Object));
    }

    
}
