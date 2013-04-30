using System;
using System.Collections.Generic;
using System.Linq;
using Lib.Model;

namespace Lib.Tests
{
    public class Host
    {
        public Box OpensABoxWithAGoatInIt(IList<Box> boxes)
        {
            foreach (var boxToOpen in boxes.Where(box => !box.Opened && box.Prize == Prize.Goat))
            {
                boxToOpen.Open(typeof (Host));
                return boxToOpen;
            }

            throw new Exception("Host can't open a box - this shouldn't happen!");
        }
    }
}