using System;
using System.Collections.Generic;

namespace Lib.Model
{
    public class Contestant
    {
        public Box OpenRandomBox(IList<Box> boxes) {
            _numberOfOriginalBox = _randomBoxChooser.GetFirstRandomChoice();
            var boxToOpen = boxes[_numberOfOriginalBox - 1];
            boxToOpen.Open(this);

            return boxToOpen;
        }

        public Box ChoosesToSwitch(IList<Box> boxes) {
            for (var i = 0; i < boxes.Count; i++) {
                if (i != _numberOfOriginalBox - 1 && boxes[i].Opened == false)
                    return boxes[i];
            }

            throw new Exception("Contestant can't find a box to switch to - this shouldn't happen!");
        }

        private readonly RandomBoxChooser _randomBoxChooser;
        private int _numberOfOriginalBox;

        public Contestant(RandomBoxChooser randomBoxChooser)
        {
            _randomBoxChooser = randomBoxChooser;
        }
    }
}