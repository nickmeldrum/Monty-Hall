using Lib.Model;
using NUnit.Framework;
using Randomizer = Lib.Model.Randomizer;

namespace Lib.Tests {
    [TestFixture]
    [Category("Unit")]
    public class BoxFixture {
        [Test]
        public void Box_WhenOpened_CanReturnEitherAGoatOrACar() {
            // Arrange this badboy
            var box = new Box(Prize.Car);
            var contestant = new Contestant(new RandomBoxChooser(new Randomizer()));

            // Act
            var prize = box.Open(contestant);

            // Assert
            Assert.IsTrue(prize == Prize.Goat || prize == Prize.Car, "Prize isn't either a goat or a car!");
        }


        [Test]
        public void Box_WhenOpenedByContestant_ThenItRemembersItWasOpenedByAContestant() {
            // Arrange
            var box = new Box(Prize.Goat);
            var contestant = new Contestant(new RandomBoxChooser(new Randomizer()));

            // Act
            box.Open(contestant);

            // Assert
            Assert.IsTrue(box.Opened);
            Assert.AreEqual(box.OpenedBy, typeof(Contestant));
        }

    }
}
