using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    class Human : Player
    {
        public Human(string name) : base(name)
        {
        }

        public override void BuyCard()
        {
            throw new NotImplementedException();
        }
    }
}
