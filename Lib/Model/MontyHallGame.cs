using System.Collections.Generic;
using Lib.Tests;

namespace Lib.Model {
    public class MontyHallGame {
        public Prize Play() {
            var box = _contestant.OpenRandomBox(_boxes);
            _host.OpensABoxWithAGoatInIt(_boxes);

            if (_contestantWantsToSwitch)
                box = _contestant.ChoosesToSwitch(_boxes);

            return box.Prize;
        }

        private readonly Randomizer _randomizer;
        private readonly bool _contestantWantsToSwitch;
        private readonly Host _host;
        private readonly Contestant _contestant;
        private IList<Box> _boxes;

        // TODO: poor mans IOC starting to look like a smell now - next time this happens - bring in IOC container!
        public MontyHallGame(Host host, IList<Box> boxes, Contestant contestant, bool contestantWantsToSwitch) {
            _host = host;
            _boxes = boxes;
            _contestant = contestant;
            _contestantWantsToSwitch = contestantWantsToSwitch;
        }

        public MontyHallGame(Randomizer randomizer, bool contestantWantsToSwitch) {
            _randomizer = randomizer;
            _contestantWantsToSwitch = contestantWantsToSwitch;

            _host = new Host();
            SetupBoxes();
            _contestant = new Contestant(new RandomBoxChooser(_randomizer));

        }

        private void SetupBoxes() {
            _boxes = new List<Box>(3) { new Box(Prize.Goat), new Box(Prize.Goat), new Box(Prize.Car) };
        }
    }
}