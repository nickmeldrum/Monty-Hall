using System.Collections.Generic;
using Lib.Model;
using Moq;
using NUnit.Framework;
using Randomizer = Lib.Model.Randomizer;

namespace Lib.Tests {
    [TestFixture]
    [Category("Unit")]
    public class ContestantFixture {
        [Test]
        public void Contestant_WhenOpeningABox_GetsAPrize() {
            // Arrange
            var contestant = new Contestant(new RandomBoxChooser(new Randomizer()));
            var boxes = new List<Box>(3) { new Box(new Car()), new Box(new Goat()), new Box(new Goat()) };

            // Act
            var prize = contestant.OpenRandomBox(boxes);

            // Assert
            Assert.IsNotNull(prize);
        }

        [Test]
        public void Contestant_WhenChoosingToSwitch_GetsANewBox() {
            // Arrange
            var contestant = new Contestant(new RandomBoxChooser(new Randomizer()));
            var boxes = new List<Box>(3) { new Box(new Car()), new Box(new Goat()), new Box(new Goat()) };
            var host = new Host();

            var firstBox = contestant.OpenRandomBox(boxes);
            host.OpensABoxWithAGoatInIt(boxes);

            // Act
            var secondBox = contestant.ChoosesToSwitch(boxes);

            // Assert
            Assert.AreNotSame(firstBox, secondBox);
        }
    }
}