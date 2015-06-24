using System.Collections.Generic;
using System.Linq;
using Lib.Model;
using Moq;
using NUnit.Framework;
using Randomizer = Lib.Model.Randomizer;

namespace Lib.Tests {
    using Lib.Ioc;

    [TestFixture]
    [Category("Unit")]
    public class MonteCarloTestFixture {
        [Test]
        public void MonteCarloTest_WhenRun10Times_WeGet10ContestantResults() {
            // Arrange
            var container = new IocContainer();
            var monteCarloTest = new MonteCarloTest(container);

            // Act
            var prizes = monteCarloTest.RunTests(10, false);

            // Assert
            Assert.AreEqual(10, prizes.Count());
        }

        [Test]
        public void MonteCarloTest_When5ContestantsReceivedACarOutOf10_WeReportThatCorrectly()
        {
            // Arrange
            var container = new IocContainer();
            var mockRandomizer = new Mock<Randomizer>();
            mockRandomizer.Setup(x => x.GetNextNumber(1, 4)).Returns(
                new Queue<int>(new[] { 1, 3, 2, 3, 2, 3, 2, 3, 2, 3 }).Dequeue);
            // Note: the way the Boxes is setup at the moment the car is always in position 3

            var monteCarloTest = new MonteCarloTest(container);

            // Act
            var prizes = monteCarloTest.RunTests(10, false);

            // Assert
            Assert.AreEqual(10, prizes.Count());
            Assert.AreEqual(5, prizes.Count(p => p == new Car()));
        }
    }
}