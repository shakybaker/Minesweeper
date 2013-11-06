using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Models
{
    public class Game
    {
        public enum AdjacentCell
        {
            TopLeft,
            TopMiddle,
            TopRight,
            MiddleLeft,
            MiddleRight,
            BottomLeft,
            BottomMiddle,
            BottomRight
        }

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
            for (var row = 0; row < 8; row++)
            {
                for (var column = 0; column < 8; column++)
                {
                    if (Grid[row, column] != "*")
                    {
                        IncrementNumber(row, column, -1, -1); //top left
                        IncrementNumber(row, column, -1, 0); //top middle
                        IncrementNumber(row, column, -1, 1); //top right
                        IncrementNumber(row, column, 0, -1); //middle left
                        IncrementNumber(row, column, 0, 1); //middle right
                        IncrementNumber(row, column, 1, -1); //bottom left
                        IncrementNumber(row, column, 1, 0); //bottom middle
                        IncrementNumber(row, column, 1, 1); //bottom right
                    }
                }
            }
        }

        private void IncrementNumber(int currentRow, int currentCol, int rowAdjustBy, int colAdjustBy)
        {
            int adjacentRow = currentRow + rowAdjustBy;
            int adjacentCol = currentCol + colAdjustBy;

            if ((adjacentRow >= 0 && adjacentRow <= 7) && (adjacentCol >= 0 && adjacentCol <= 7))
                if (Grid[adjacentRow, adjacentCol] == "*")
                    Grid[currentRow, currentCol] = (int.Parse(Grid[currentRow, currentCol]) + 1).ToString();
        }

        private int GetRandom()
        {
            var r = new Random();
            return r.Next(8);
        }
    }
}
