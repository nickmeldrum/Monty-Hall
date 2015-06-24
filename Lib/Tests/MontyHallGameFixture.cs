using System.Collections.Generic;
using Lib.Model;
using Moq;
using NUnit.Framework;
using Randomizer = Lib.Model.Randomizer;

namespace Lib.Tests {
    using Lib.Ioc;

    [TestFixture]
    [Category("Unit")]
    public class MontyHallGameFixture {
        [Test]
        public void MontyHallGame_WhenPlayed_ThenWeReceiveAPrize() {
            // Arrange
            var container = new IocContainer();
            var montyHallGame = container.GetInstance<Player>();

            // Act
            var prize = montyHallGame.Play();

            // Assert
            Assert.NotNull(prize);
        }

        [Test]
        public void MontyHallGame_WhenContestantPicksFirstBoxAndFirstBoxContainsACar_ThenWeReceiveACarAsAPrize() {
            // Arrange
            var container = new IocContainer();
            var boxes = new List<Box>(3) {new Box(new Car()), new Box(new Goat()), new Box(new Goat())};

            var randomizerMock = new Mock<Randomizer>();
            randomizerMock.Setup(x => x.GetNextNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            var montyHallGame = container.GetInstance<Player>();

            // Act
            var prize = montyHallGame.Play();

            // Assert
            Assert.AreEqual(new Car(), prize);
        }
    }
}
