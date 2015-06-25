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
            SelectRandomBox();
            OpenABoxWithAGoatInIt();

            if (decideToSwitch)
                SwitchSelectedBox();

            return this.GetPrize();
        }

        private void SelectRandomBox()
        {
            CheckNoBoxesHaveBeenSelectedOrOpened();
            boxes[randomizer.GetNextNumber(0, 3)].Select();
        }

        private void OpenABoxWithAGoatInIt()
        {
            CheckABoxHasBeenSelectedAndNoBoxesHaveBeenOpened();
            boxes.First(box => box.BoxIsNotSelectedAndNotOpenedAndContainsAGoat()).Open();
        }

        private void SwitchSelectedBox()
        {
            CheckABoxHasBeenSelectedAndABoxHasBeenOpened();
            foreach (var box in boxes.Where(b => !b.Opened))
                box.SwitchSelected();
        }

        private Prize GetPrize()
        {
            CheckABoxHasBeenSelectedAndABoxHasBeenOpened();
            return boxes.First(b => b.Selected).Prize;
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
