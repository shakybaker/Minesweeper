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

            //multiple assertions == bad, but I think its ok in this case
            Assert.AreEqual("1", game.Grid[0, 1]);
            Assert.AreEqual("1", game.Grid[0, 2]);
            Assert.AreEqual("1", game.Grid[0, 3]);
            Assert.AreEqual("1", game.Grid[0, 4]);
            Assert.AreEqual("1", game.Grid[0, 5]);
            Assert.AreEqual("1", game.Grid[0, 7]);

            Assert.AreEqual("2", game.Grid[1, 0]);
            Assert.AreEqual("2", game.Grid[1, 1]);
            Assert.AreEqual("1", game.Grid[1, 2]);
            Assert.AreEqual("2", game.Grid[1, 4]);
            Assert.AreEqual("2", game.Grid[1, 5]);
            Assert.AreEqual("2", game.Grid[1, 6]);
            Assert.AreEqual("1", game.Grid[1, 7]);

            Assert.AreEqual("1", game.Grid[3, 0]);
            Assert.AreEqual("1", game.Grid[3, 1]);
            Assert.AreEqual("0", game.Grid[3, 2]);
            Assert.AreEqual("1", game.Grid[3, 3]);
            Assert.AreEqual("2", game.Grid[3, 4]);
            Assert.AreEqual("2", game.Grid[3, 5]);
            Assert.AreEqual("2", game.Grid[3, 6]);

            Assert.AreEqual("1", game.Grid[4, 0]);
            Assert.AreEqual("1", game.Grid[4, 1]);
            Assert.AreEqual("0", game.Grid[4, 2]);
            Assert.AreEqual("1", game.Grid[4, 3]);
            Assert.AreEqual("1", game.Grid[4, 5]);
            Assert.AreEqual("1", game.Grid[4, 6]);
            Assert.AreEqual("1", game.Grid[4, 7]);

            Assert.AreEqual("1", game.Grid[5, 1]);
            Assert.AreEqual("0", game.Grid[5, 2]);
            Assert.AreEqual("1", game.Grid[5, 3]);
            Assert.AreEqual("1", game.Grid[5, 4]);
            Assert.AreEqual("1", game.Grid[5, 5]);
            Assert.AreEqual("0", game.Grid[5, 6]);
            Assert.AreEqual("0", game.Grid[5, 7]);

            Assert.AreEqual("2", game.Grid[6, 0]);
            Assert.AreEqual("2", game.Grid[6, 1]);
            Assert.AreEqual("1", game.Grid[6, 2]);
            Assert.AreEqual("0", game.Grid[6, 3]);
            Assert.AreEqual("1", game.Grid[6, 4]);
            Assert.AreEqual("1", game.Grid[6, 5]);
            Assert.AreEqual("1", game.Grid[6, 6]);
            Assert.AreEqual("0", game.Grid[6, 7]);

            Assert.AreEqual("1", game.Grid[7, 0]);
            Assert.AreEqual("1", game.Grid[7, 2]);
            Assert.AreEqual("0", game.Grid[7, 3]);
            Assert.AreEqual("1", game.Grid[7, 4]);
            Assert.AreEqual("1", game.Grid[7, 6]);
            Assert.AreEqual("0", game.Grid[7, 7]);
        }
    }
}
