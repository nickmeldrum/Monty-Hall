using System;

namespace Lib.Model
{
    public class Randomizer
    {
        public virtual int GetNextNumber(int lower, int upper) {
            return RandomNumberGenerator.Next(lower, upper);
        }

        private static readonly Random RandomNumberGenerator = new Random((int)DateTime.Now.Ticks);
    }
}