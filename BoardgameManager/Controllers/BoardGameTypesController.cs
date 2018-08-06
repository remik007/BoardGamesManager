using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoardgameManager.Models;

namespace BoardgameManager.Controllers
{
    public class BoardGameTypesController : Controller
    {
        private BoardgameDBEntities db = new BoardgameDBEntities();

        // GET: BoardGameTypes
        public ActionResult Index()
        {
            return View();
        }

    }
}
