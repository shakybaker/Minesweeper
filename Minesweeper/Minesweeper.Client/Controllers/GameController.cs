using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper.Client.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            var game = new Game();
            game.PlaceBombsOnGrid();
            game.GenerateProximityNumbersOnGrid();

            return View("Index", game);
        }
	}
}