using System.Collections.Generic;

namespace Lib.Model
{
    public class MonteCarloTest
    {
        public IList<Prize> RunTests(int numberOfTimes) {
            var prizes = new List<Prize>(10);

            for (var i = 0; i < numberOfTimes; i++) {
                var montyHallGame = new MontyHallGame(_randomizer, _contestantWantsToSwitch);
                prizes.Add(montyHallGame.Play());
            }

            return prizes;
        }

        private readonly Randomizer _randomizer;
        private readonly bool _contestantWantsToSwitch;

        public MonteCarloTest(Randomizer randomizer, bool contestantWantsToSwitch = false)
        {
            _randomizer = randomizer;
            _contestantWantsToSwitch = contestantWantsToSwitch;
        }
    }
}