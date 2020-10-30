using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniVilles
{
    public class Die
    {
        public int Face;
        public string name;

        public Die(string name) { this.name = name; }

        public int Throw()
        {
            Console.WriteLine("Le dé {0} est jeter.", name);
            Thread.Sleep(1150);
            Random random = new Random(DateTime.Now.Millisecond);
            int result = random.Next(1, 7);
            Face = result;
            Console.WriteLine("+---+");
            Console.WriteLine("| {0} |", Face);
            Console.WriteLine("+---+");
            Thread.Sleep(500);
            return result;
        }
    }
}
