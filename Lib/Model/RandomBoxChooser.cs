using System.Collections.Generic;

namespace Lib.Model
{
    public class RandomBoxChooser
    {
        public int GetFirstRandomChoice() {
            return _randomizer.GetNextNumber(1, 4);
        }

        public int GetSecondRandomChoice(int firstChoice) {
            var newSelection = new List<int>(2);
            if (firstChoice != 1) newSelection.Add(1);
            if (firstChoice != 2) newSelection.Add(2);
            if (firstChoice != 3) newSelection.Add(3);

            return newSelection[_randomizer.GetNextNumber(0, 2)];
        }

        private readonly Randomizer _randomizer;

        public RandomBoxChooser(Randomizer randomizer)
        {
            _randomizer = randomizer;
        }
    }
}