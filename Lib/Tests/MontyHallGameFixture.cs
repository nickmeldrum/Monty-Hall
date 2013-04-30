using System.Collections.Generic;
using Lib.Model;
using Moq;
using NUnit.Framework;
using Randomizer = Lib.Model.Randomizer;

namespace Lib.Tests {
    [TestFixture]
    [Category("Unit")]
    public class MontyHallGameFixture {
        [Test]
        public void MontyHallGame_WhenPlayed_ThenWeReceiveAPrize() {
            // Arrange
            var montyHallGame = new MontyHallGame(new Randomizer(), false);

            // Act
            var prize = montyHallGame.Play();

            // Assert
            Assert.NotNull(prize);
        }

        [Test]
        public void MontyHallGame_WhenContestantPicksFirstBoxAndFirstBoxContainsACar_ThenWeReceiveACarAsAPrize() {
            // Arrange
            var boxes = new List<Box>(3) {new Box(Prize.Car), new Box(Prize.Goat), new Box(Prize.Goat)};

            var randomizerMock = new Mock<Randomizer>();
            randomizerMock.Setup(x => x.GetNextNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var montyHallGame = new MontyHallGame(new Host(), boxes,
                new Contestant(new RandomBoxChooser(randomizerMock.Object)), false);

            // Act
            var prize = montyHallGame.Play();

            // Assert
            Assert.AreEqual(Prize.Car, prize);
        }
    }
}
