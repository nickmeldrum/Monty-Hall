using System.Collections.Generic;

namespace Lib.Model
{
    public class Simulation
    {
        public IList<Prize> RunSimulationStickingEveryTime(int numberOfTimes)
        {
            return this.RunSimulation(numberOfTimes, false);
        }

        public IList<Prize> RunSimulationSwitchingEveryTime(int numberOfTimes)
        {
            return this.RunSimulation(numberOfTimes, true);
        }

        private IList<Prize> RunSimulation(int numberOfTimes, bool contestantWantsToSwitch = false) {
            var prizes = new List<Prize>();

            for (var i = 0; i < numberOfTimes; i++)
            {
                var montyHallGame = new Game();
                if (contestantWantsToSwitch)
                    prizes.Add(montyHallGame.PlayAndDecideToSwitch());
                else
                    prizes.Add(montyHallGame.PlayAndDecideToStick());
            }

            return prizes;
        }
    }
}