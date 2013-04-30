using System;

namespace Lib.Model
{
    public class Randomizer
    {
        public virtual int GetNextNumber(int lower, int upper) {
            return BoxRandomizer.Next(lower, upper);
        }

        private static readonly Random BoxRandomizer = new Random((int)DateTime.Now.Ticks);
    }
}