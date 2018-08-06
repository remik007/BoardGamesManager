using BoardgameManager.Controllers;
using BoardgameManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BoardgameManager.Tests.Controllers
{
    [TestClass]
    public class BoardgameControllerTest
    {
        private BoardgameDBEntities db = new BoardgameDBEntities();

        [TestMethod]
        public void Test_Index_Return_View()
        {
            var controller = new BoardgamesController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Details_Return_View()
        {
            var controller = new BoardgamesController();
            var game = db.Boardgames.FirstOrDefault();
            var result = controller.Details(game.Id) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Test_Edit_Return_View()
        {
            var controller = new BoardgamesController();
            var game = db.Boardgames.FirstOrDefault();
            var result = controller.Edit(game.Id) as ViewResult;
            Assert.IsNotNull(result);

        }
    }
}
