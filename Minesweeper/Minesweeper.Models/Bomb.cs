using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Models
{
    public class Bomb
    {
        public int[] Position { get; set; }

        public Bomb()
        {
            Position = new int[2];
        }
    }
}
