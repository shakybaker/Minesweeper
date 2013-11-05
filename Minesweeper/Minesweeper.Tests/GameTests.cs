using Minesweeper.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Can_create_an_game_grid_with_8_rows()
        {
            var game = new Game();
            var x = game.Grid[8, 0];
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Can_create_an_game_grid_with_8_columns()
        {
            var game = new Game();
            var x = game.Grid[0, 8];
        }

        [Test]
        public void Can_create_10_bombs_on_the_grid()
        {
            var game = new Game();
            game.PlaceBombsOnGrid();

            var count = 0;

            for (var i = 0; i < 8; i++ )
                for (var j = 0; j < 8; j++ )
                    if (game.Grid[i,j] == "*")
                        count++;

            Assert.AreEqual(10, count);
        }

        [Test]
        public void Can_generate_proximity_numbers_on_grid()
        {
            var game = new Game();
            game.Grid[0, 0] = "*";
            game.Grid[0, 6] = "*";
            game.Grid[1, 3] = "*";
            game.Grid[2, 0] = "*";
            game.Grid[2, 5] = "*";
            game.Grid[3, 7] = "*";
            game.Grid[4, 4] = "*";
            game.Grid[5, 0] = "*";
            game.Grid[7, 1] = "*";
            game.Grid[7, 5] = "*";
            game.GenerateProximityNumbersOnGrid();

            Assert.AreEqual("1", game.Grid[0, 1]);
            Assert.AreEqual("2", game.Grid[1, 0]);
        }
    }
}
