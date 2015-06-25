namespace Lib.Model
{
    public class Box
    {
        public bool Opened { get; private set; }
        public bool Selected { get; private set; }
        public Prize Prize { get; private set; }

        public Box(Prize prize)
        {
            Prize = prize;
        }

        public void Open()
        {
            this.Opened = true;
        }

        public void Select()
        {
            this.Selected = true;
        }

        public void SwitchSelected()
        {
            this.Selected = !this.Selected;
        }

        public bool BoxIsNotSelectedAndNotOpenedAndContainsAGoat()
        {
            return !this.Selected && !this.Opened && Prize.Equals(Prize.Goat);
        }

        public override bool Equals(object obj)
        {
            var otherBox = obj as Box;

            if (otherBox == null)
                return false;

            return Prize == otherBox.Prize;
        }
    }
}