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
            var grid = new Game();

            return View("Index", grid);
        }
	}
}