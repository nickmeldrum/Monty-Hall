using System;
using Lib.Model;
using Moq;
using NUnit.Framework;
using Randomizer = Lib.Model.Randomizer;

namespace Lib.Tests {
    [TestFixture]
    [Category("Unit")]
    public class RandomBoxChooserFixture {
        [Test]
        public void RandomBoxChooser_WhenAskingForFirstRandomChoice_ThenYouGetAGoodChoiceBack() {
            // Arrange
            var mockRandomizer = new Mock<Randomizer>();
            var randomBoxChooser = new RandomBoxChooser(mockRandomizer.Object);
            mockRandomizer.Setup(x => x.GetNextNumber(1, 4)).Returns(1);

            // Act
            var choice = randomBoxChooser.GetFirstRandomChoice();

            // Assert
            Assert.AreEqual(1, choice);
        }

        [Test]
        public void RandomBoxChooser_WhenAskingForSecondRandomChoice_ThenYouDontGetYourFirstChoiceBack() {
            // Arrange
            var mockRandomizer = new Mock<Randomizer>();
            var randomBoxChooser = new RandomBoxChooser(mockRandomizer.Object);
            mockRandomizer.Setup(x => x.GetNextNumber(1, 4)).Returns(1);
            mockRandomizer.Setup(x => x.GetNextNumber(1, 3)).Returns(1);

            // Act
            var firstChoice = randomBoxChooser.GetFirstRandomChoice();
            var secondChoice = randomBoxChooser.GetSecondRandomChoice(firstChoice);

            // Assert
            Assert.AreNotSame(firstChoice, secondChoice);
        }

        [Test]
        public void RandomBoxChooser_WhenRunANumberOfTimes_ReportsSomeRealResultsForAnalysis()
        {
            // Arrange
            var randomBoxChooser = new RandomBoxChooser(new Randomizer());

            // Act
            // Assert
            for (var i = 0; i < 100; i++)
            {
                var firstChoice = randomBoxChooser.GetFirstRandomChoice();
                var secondChoice = randomBoxChooser.GetSecondRandomChoice(firstChoice);
                Console.WriteLine("First choice: {0}, Second choice: {1}", firstChoice, secondChoice); 
                
            }
        }
    }
}