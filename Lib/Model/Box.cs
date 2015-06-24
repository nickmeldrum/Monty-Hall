namespace Lib.Model
{
    public class Box
    {
        public bool Opened { get; private set; }
        public bool Selected { get; set; }
        public Prize Prize { get; private set; }

        public Box(Prize prize)
        {
            Prize = prize;
        }

        public void Open()
        {
            Opened = true;
        }

        public void Unselect()
        {
            Selected = true;
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