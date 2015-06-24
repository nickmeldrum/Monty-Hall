using System;
using System.Linq;
using Lib.Model;
using NUnit.Framework;

namespace Lib.Simulations {
    [TestFixture]
    [Category("Simulation")]
    public class SimulationFixture {
        [Test]
        [TestCase(100000)]
        public void MonteCarloTest_WhenRunNTimes_ThenWeReportOurResults(int numberOfTimes) {
            // Arrange
            var monteCarloTest = new Simulation();

            // Act
            var prizes = monteCarloTest.RunSimulationStickingEveryTime(numberOfTimes);

            // Assert
            Console.WriteLine("Run {0} times (no contestantWantsToSwitch): {1} cars won.", numberOfTimes, prizes.Count(p => p == Prize.Car));
        }

        [Test]
        [TestCase(100000)]
        public void MonteCarloTest_WhenRunNTimesOnSwitchingContestants_ThenWeReportOurResults(int numberOfTimes) {
            // Arrange
            var monteCarloTest = new Simulation();

            // Act
            var prizes = monteCarloTest.RunSimulationSwitchingEveryTime(numberOfTimes);

            // Assert
            Console.WriteLine("Run {0} times (contestantWantsToSwitch): {1} cars won.", numberOfTimes, prizes.Count(p => p == Prize.Car));
        }

        [Test]
        [TestCase(100000)]
        public void MonteCarloTest_WhenRunNTimes_ThenTheContestantsShouldWinAThirdOfTheTime(int numberOfTimes) {
            // Arrange
            var monteCarloTest = new Simulation();

            // Act
            var prizes = monteCarloTest.RunSimulationStickingEveryTime(numberOfTimes);
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
            var monteCarloTest = new Simulation();
            
            // Act
            var prizes = monteCarloTest.RunSimulationSwitchingEveryTime(numberOfTimes);
            var prizeCount = prizes.Count(p => p == Prize.Car);
            var percentWon = (int)(((float)prizeCount / numberOfTimes) * 100);

            // Assert
            Assert.AreEqual(66, percentWon);
            Console.WriteLine("Run {0} times (contestantWantsToSwitch): {1} cars won. Contestant won {2}% of the time",
                numberOfTimes, prizeCount, percentWon);
        }
    }
}
