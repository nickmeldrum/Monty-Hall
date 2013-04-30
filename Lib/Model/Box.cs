using System;

namespace Lib.Model
{
    public class Box
    {
        public Prize Prize { get { return _prize; } }
        public bool Opened { get; private set; }
        public Type OpenedBy { get; private set; }

        public Prize Open(object opener) {
            OpenedBy = opener.GetType();
            Opened = true;
            return _prize;
        }

        private readonly Prize _prize;

        public Box(Prize prize)
        {
            _prize = prize;
        }

        public override bool Equals(object obj)
        {
            var otherBox = obj as Box;

            if (otherBox == null)
                return false;

            return _prize == otherBox._prize;
        }
    }
}