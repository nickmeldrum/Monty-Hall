namespace Lib.Model
{
    using System;
    using System.Linq;

    public class Game
    {
        private readonly Randomizer randomizer;
        private readonly Box[] boxes;

        public Game()
        {
            this.randomizer = new Randomizer();
            this.boxes = new [] { new Box(Prize.Goat), new Box(Prize.Goat), new Box(Prize.Car)};
        }

        public Prize PlayAndDecideToSwitch()
        {
            return this.Play(true);
        }

        public Prize PlayAndDecideToStick()
        {
            return this.Play(false);
        }

        private Prize Play(bool decideToSwitch)
        {
            var box = SelectRandomBox();
            OpenABoxWithAGoatInIt();

            if (decideToSwitch)
                box = SwitchSelectedBox();

            return box.Prize;
        }

        private void OpenABoxWithAGoatInIt()
        {
            CheckABoxHasBeenSelectedAndNoBoxesHaveBeenOpened();
            boxes.First(box => !box.Selected && !box.Opened && box.Prize.Equals(Prize.Goat)).Open();
        }

        private Box SelectRandomBox()
        {
            CheckNoBoxesHaveBeenSelectedOrOpened();
            var box = boxes[randomizer.GetNextNumber(0, 3)];
            box.Selected = true;
            return box;
        }

        private Box SwitchSelectedBox()
        {
            Box selectedBox = null;
            CheckABoxHasBeenSelectedAndABoxHasBeenOpened();
            foreach (var box in boxes)
            {
                box.Selected = !box.Selected;
                if (box.Selected) selectedBox = box;
            }
            return selectedBox;
        }

        private void CheckABoxHasBeenSelectedAndNoBoxesHaveBeenOpened()
        {
           if (this.NumberOfBoxesOpened() != 0)
                throw new Exception("Expected no boxes to be opened");
            if (this.NumberOfBoxesSelected() != 1)
                throw new Exception("Expected only 1 box to be selected");
        }

        private void CheckNoBoxesHaveBeenSelectedOrOpened()
        {
           if (this.NumberOfBoxesOpened() != 0)
                throw new Exception("Expected no boxes to be opened");
            if (this.NumberOfBoxesSelected() != 0)
                throw new Exception("Expected no boxes to be selected");
        }

        private void CheckABoxHasBeenSelectedAndABoxHasBeenOpened()
        {
           if (this.NumberOfBoxesOpened() != 1)
                throw new Exception("Expected only 1 box to be opened");
            if (this.NumberOfBoxesSelected() != 1)
                throw new Exception("Expected only 1 box to be selected");
        }

        private int NumberOfBoxesSelected()
        {
            return this.boxes.Count(box => box.Selected);
        }

        private int NumberOfBoxesOpened()
        {
            return this.boxes.Count(box => box.Opened);
        }
    }
}
