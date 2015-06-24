using System.Collections.Generic;
using System.Linq;
using Lib.Model;
using Moq;
using NUnit.Framework;
using Randomizer = Lib.Model.Randomizer;

namespace Lib.Tests {
    [TestFixture]
    [Category("Unit")]
    public class HostFixture {
        [Test]
        public void Host_WhenOpeningAGoatBoxFromTheBoxes_ThenTheBoxesOnlyHas2BoxesLeftUnopen() {
            // Arrange
            var host = new Host();
            var boxes = new List<Box>(3) { new Box(new Car()), new Box(new Goat()), new Box(new Goat()) };

            // Act
            host.OpensABoxWithAGoatInIt(boxes);
            var unopenBoxes = boxes.Count(box => box.Opened == false);

            // Assert
            Assert.AreEqual(2, unopenBoxes);
        }

        [Test]
        public void Host_WhenOpeningAGoatBoxFromTheBoxesAfterAContestantHasChosenAGoat_ThenTheHostHasntChosenTheContestantsBox() {
            // Arrange
            var mockRandomizer = new Mock<Randomizer>();
            var randomBoxChooser = new RandomBoxChooser(mockRandomizer.Object);
            mockRandomizer.Setup(x => x.GetNextNumber(1, 4)).Returns(1);

            var host = new Host();
            var contestant = new Contestant(randomBoxChooser);
            var boxes = new List<Box>(3) { new Box(new Car()), new Box(new Goat()), new Box(new Goat()) };
            var contestantsBox = contestant.OpenRandomBox(boxes);

            // Act
            var hostsBox = host.OpensABoxWithAGoatInIt(boxes);

            // Assert
            Assert.AreNotSame(contestantsBox, hostsBox);
        }

    }
}