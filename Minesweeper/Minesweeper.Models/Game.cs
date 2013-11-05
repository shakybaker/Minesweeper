using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Models
{
    public class Game
    {
        public string[,] Grid = { 
                           { "0", "0", "0", "0", "0", "0", "0", "0" }, 
                           { "0", "0", "0", "0", "0", "0", "0", "0" }, 
                           { "0", "0", "0", "0", "0", "0", "0", "0" }, 
                           { "0", "0", "0", "0", "0", "0", "0", "0" }, 
                           { "0", "0", "0", "0", "0", "0", "0", "0" }, 
                           { "0", "0", "0", "0", "0", "0", "0", "0" }, 
                           { "0", "0", "0", "0", "0", "0", "0", "0" }, 
                           { "0", "0", "0", "0", "0", "0", "0", "0" }
                       };
        private List<string> validNonNumeric = new List<string> { "*", "!" };

        public void PlaceBombsOnGrid()
        {
            for (var i = 0; i < 10; i++)
            {
                var keepRandomising = true;
                var row = -1;
                var cell = -1;
                while (keepRandomising)
                {
                    row = GetRandom();
                    cell = GetRandom();

                    keepRandomising = Grid[row, cell] == "*";
                }
                Grid[row, cell] = "*";
            }
        }

        public void GenerateProximityNumbersOnGrid()
        {
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    if (Grid[i, j] != "*")
                    {
                        try
                        {
                            if (Grid[i - 1, j - 1] == "*")
                                IncrementNumber(i, j);
                            if (Grid[i - 1, j] == "*")
                                IncrementNumber(i, j);
                            if (Grid[i - 1, j + 1] == "*")
                                IncrementNumber(i, j);
                            if (Grid[i, j - 1] == "*")
                                IncrementNumber(i, j);
                            if (Grid[i, j + 1] == "*")
                                IncrementNumber(i, j);
                            if (Grid[i + 1, j - 1] == "*")
                                IncrementNumber(i, j);
                            if (Grid[i + 1, j] == "*")
                                IncrementNumber(i, j);
                            if (Grid[i + 1, j + 1] == "*")
                                IncrementNumber(i, j);
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            //do nothing
                        }
                    }
                }
            }
        }

        private void IncrementNumber(int i, int j)
        {
            Grid[i, j] = (int.Parse(Grid[i, j]) + 1).ToString();
        }

        private int GetRandom()
        {
            var r = new Random();
            return r.Next(8);
        }
    }
}
