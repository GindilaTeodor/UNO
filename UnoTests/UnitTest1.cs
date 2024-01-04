using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Uno.ViewModel;

namespace UnoTests
{
    [TestClass]
    public class CardsVMTests
    {
        [TestMethod]
        public void InitializeGame_ShouldPopulateHandsAndTable()
        {
            // Arrange
            var cardsVM = new CardsVM();

            // Assert
            Assert.IsNotNull(cardsVM.Hand);
            Assert.IsNotNull(cardsVM.AIHand);
            Assert.IsNotNull(cardsVM.Table);
            Assert.AreEqual(5, cardsVM.Hand.Count); // Assuming initial hand size is 7
            Assert.AreEqual(5, cardsVM.AIHand.Count); // Assuming initial AI hand size is 7
        }

        [TestMethod]
        
        public void PlayCard_ShouldUpdateTableAndRemoveFromHand_WhenCardCanBePlayed()
        {
            // Arrange
            var cardsVM = new CardsVM();
            cardsVM.InitializeGame();
            var initialTable = cardsVM.Table;
            var cardToPlay = cardsVM.Hand.FirstOrDefault();

            // Act
            cardsVM.PlayCard(cardToPlay);

            // Assert
            if (cardsVM.Table != initialTable)
            {
                // Card can be played
                CollectionAssert.DoesNotContain(cardsVM.Hand.ToList(), cardToPlay);
            }
            else
            {
                // Card cannot be played, should not have changed the table or hand
                Assert.AreEqual(initialTable, cardsVM.Table);
                CollectionAssert.Contains(cardsVM.Hand.ToList(), cardToPlay);
            }
        }


        [TestMethod]
        public void AIPlayCard_ShouldUpdateTableAndRemoveFromAIHand_WhenCardCanBePlayed()
        {
            // Arrange
            var cardsVM = new CardsVM();
            cardsVM.InitializeGame();
            var initialTable = cardsVM.Table;
            var cardToPlay = cardsVM.AIHand.FirstOrDefault();

            // Act
            var result = cardsVM.AIPlayCard(cardToPlay);

            // Assert
            if (result)
            {
                // Card can be played
                Assert.AreNotEqual(initialTable, cardsVM.Table);
                CollectionAssert.DoesNotContain(cardsVM.AIHand.ToList(), cardToPlay);
            }
            else
            {
                // Card cannot be played, should not have changed the table or AI hand
                Assert.AreEqual(initialTable, cardsVM.Table);
                CollectionAssert.Contains(cardsVM.AIHand.ToList(), cardToPlay);
            }
        }


        [TestMethod]
        public void Take_ShouldAddCardToHand()
        {
            // Arrange
            var cardsVM = new CardsVM();
            cardsVM.InitializeGame();
            var initialHandCount = cardsVM.Hand.Count;

            // Act
            cardsVM.Take();

            // Assert
            Assert.AreEqual(initialHandCount + 1, cardsVM.Hand.Count);
        }

        [TestMethod]
        public void AITake_ShouldAddCardToAIHand()
        {
            // Arrange
            var cardsVM = new CardsVM();
            cardsVM.InitializeGame();
            var initialAIHandCount = cardsVM.AIHand.Count;

            // Act
            cardsVM.AITake();

            // Assert
            Assert.AreEqual(initialAIHandCount + 1, cardsVM.AIHand.Count);
        }
    }
}
