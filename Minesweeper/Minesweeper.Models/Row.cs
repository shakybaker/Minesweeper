using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Models
{
    public class Row
    {
        public IList<Cell> Cells { get; set; }

        public Row()
        {
            Cells = new List<Cell>
            {
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell()
            };
        }
    }
}
