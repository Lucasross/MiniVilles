using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    public class Die
    {
        public int Face;

        public Die() { }

        public int Throw()
        {
            Random random = new Random();
            int result = random.Next(1, 7);
            this.Face = result;
            return result;
        }
    }
}
