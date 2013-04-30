using System;
using System.Linq;
using Lib.Model;
using NUnit.Framework;
using Randomizer = Lib.Model.Randomizer;

namespace Lib.Simulations {
    [TestFixture]
    [Category("Simulation")]
    public class SimulationFixture {
        [Test]
        [TestCase(100000)]
        public void MonteCarloTest_WhenRunNTimes_ThenWeReportOurResults(int numberOfTimes) {
            // Arrange
            var monteCarloTest = new MonteCarloTest(new Randomizer());

            // Act
            var prizes = monteCarloTest.RunTests(numberOfTimes);

            // Assert
            Console.WriteLine("Run {0} times (no contestantWantsToSwitch): {1} cars won.", numberOfTimes, prizes.Count(p => p == Prize.Car));
        }

        [Test]
        [TestCase(100000)]
        public void MonteCarloTest_WhenRunNTimesOnSwitchingContestants_ThenWeReportOurResults(int numberOfTimes) {
            // Arrange
            var monteCarloTest = new MonteCarloTest(new Randomizer(), true);

            // Act
            var prizes = monteCarloTest.RunTests(numberOfTimes);

            // Assert
            Console.WriteLine("Run {0} times (contestantWantsToSwitch): {1} cars won.", numberOfTimes, prizes.Count(p => p == Prize.Car));
        }

        [Test]
        [TestCase(100000)]
        public void MonteCarloTest_WhenRunNTimes_ThenTheContestantsShouldWinAThirdOfTheTime(int numberOfTimes) {
            // Arrange
            var monteCarloTest = new MonteCarloTest(new Randomizer());

            // Act
            var prizes = monteCarloTest.RunTests(numberOfTimes);
            var prizeCount = prizes.Count(p => p == Prize.Car);
            var percentWon = (int)(((float)prizeCount / numberOfTimes) * 100);

            // Assert
            Assert.AreEqual(33, percentWon);
            Console.WriteLine("Run {0} times (contestantWantsToSwitch): {1} cars won. Contestant won {2}% of the time",
                numberOfTimes, prizeCount, percentWon);
        }

        [Test]
        [TestCase(100000)]
        public void MonteCarloTest_WhenRunNTimesAsASwitchingContestant_ThenTheContestantsShouldWinTwoThirdsOfTheTime(int numberOfTimes) {
            // Arrange
            var monteCarloTest = new MonteCarloTest(new Randomizer(), contestantWantsToSwitch: true);
            
            // Act
            var prizes = monteCarloTest.RunTests(numberOfTimes);
            var prizeCount = prizes.Count(p => p == Prize.Car);
            var percentWon = (int)(((float)prizeCount / numberOfTimes) * 100);

            // Assert
            Assert.AreEqual(66, percentWon);
            Console.WriteLine("Run {0} times (contestantWantsToSwitch): {1} cars won. Contestant won {2}% of the time",
                numberOfTimes, prizeCount, percentWon);
        }
    }
}
