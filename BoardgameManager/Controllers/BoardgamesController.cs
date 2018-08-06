using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoardgameManager.Models;
using BoardgameManager.ViewModels.BoardgamesController;
using AutoMapper;
using BoardgameManager.Api;

namespace BoardgameManager.Controllers
{
    public class BoardgamesController : Controller
    {
        private BoardgameDBEntities db = new BoardgameDBEntities();


        /// <summary>
        ///     Gets boardgame list results in form of JSON.
        /// </summary>
        /// <returns>JSON result.</returns>
        [HttpPost]
        public ActionResult GetResults()
        {
            var Result = (from game in db.Boardgames select new { Id = game.Id, Name = game.Name, MinAge = game.MinAge, Type = game.BoardGameType.Name });
            return Json(new { data = Result }, JsonRequestBehavior.AllowGet);
        }

        // GET: Boardgames
        public ActionResult Index()
        {
            var boardgames = db.Boardgames.Include(b => b.BoardGameType);
            return View(boardgames.ToList());
        }

        // GET: Boardgames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boardgame boardgame = db.Boardgames.Find(id);

            if (boardgame == null)
            {
                return HttpNotFound();
            }

            UpdateBoardgameCall(boardgame.Id);
            DetailsBoardgameViewModel viewmodel = GetDetailsBoardgameViewModel(boardgame);
            return View(viewmodel);
        }

        private void UpdateBoardgameCall(int id)
        {
            BoardgameCall boardgameCall = new BoardgameCall();
            boardgameCall.Boardgame_Id = id;
            boardgameCall.CallDate = DateTime.Now;
            boardgameCall.CallType = Convert.ToInt32(CallTypes.Website);
            db.BoardgameCalls.Add(boardgameCall);
            db.SaveChanges();
        }

        private DetailsBoardgameViewModel GetDetailsBoardgameViewModel(Boardgame boardgame)
        {
            DetailsBoardgameViewModel viewModel = new DetailsBoardgameViewModel();
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Boardgame, DetailsBoardgameViewModel>());
            IMapper mapper = config.CreateMapper();
            viewModel = mapper.Map(boardgame, viewModel);
            return viewModel;
        }

        // GET: Boardgames/Create
        public ActionResult Create()
        {
            CreateBoardgameViewModel createBoardgameViewModel = new CreateBoardgameViewModel();
            UpdateCreateBoardgameViewModel(createBoardgameViewModel);
            return View(createBoardgameViewModel);
        }

        private void UpdateCreateBoardgameViewModel(CreateBoardgameViewModel createBoardgameViewModel)
        {
            //Load Board Game Types
            var boardGameTypes = db.BoardGameTypes.ToList()
               .Select(x => new SelectListItem { Text = x.Name, Value = (x.Id).ToString() })
               .OrderBy(x => x.Text);
            createBoardgameViewModel.AvailableBoardGameTypes = new SelectList(boardGameTypes, nameof(SelectListItem.Value), nameof(SelectListItem.Text));
            
        }
        // POST: Boardgames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBoardgameViewModel createBoardgameViewModel)
        {
            if (ModelState.IsValid)
            {
                AddBoardgame(createBoardgameViewModel);
                return RedirectToAction("Index", "Home");
            }
            UpdateCreateBoardgameViewModel(createBoardgameViewModel);
            return View(createBoardgameViewModel);
        }

        private void AddBoardgame(CreateBoardgameViewModel viewModel)
        {
            Boardgame boardgame = new Boardgame();
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<CreateBoardgameViewModel, Boardgame>());
            IMapper mapper = config.CreateMapper();
            boardgame = mapper.Map<Boardgame>(viewModel);
            boardgame.CreatedBy = HttpContext.User.Identity.Name;
            boardgame.CreatedDate = DateTime.Now;
            db.Boardgames.Add(boardgame);
            db.SaveChanges();
        }

        // GET: Boardgames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boardgame boardgame = db.Boardgames.Find(id);
            if (boardgame == null)
            {
                return HttpNotFound();
            }
            EditBoardgameViewModel editBoardgameViewModel = GetEditBoardgameViewModel(boardgame);
            UpdateEditBoardgameViewModel(editBoardgameViewModel);
            return View(editBoardgameViewModel);
        }

        private EditBoardgameViewModel GetEditBoardgameViewModel(Boardgame boardgame)
        {
            EditBoardgameViewModel viewModel = new EditBoardgameViewModel();
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Boardgame, EditBoardgameViewModel>());
            IMapper mapper = config.CreateMapper();
            viewModel = mapper.Map(boardgame, viewModel);
            return viewModel;
        }

        private void UpdateEditBoardgameViewModel(EditBoardgameViewModel editBoardgameViewModel)
        {
            //Load Board Game Types
            var boardGameTypes = db.BoardGameTypes.ToList()
               .Select(x => new SelectListItem { Text = x.Name, Value = (x.Id).ToString() })
               .OrderBy(x => x.Text);
            editBoardgameViewModel.AvailableBoardGameTypes = new SelectList(boardGameTypes, nameof(SelectListItem.Value), nameof(SelectListItem.Text));

        }

        // POST: Boardgames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBoardgameViewModel editBoardgameViewModel)
        {
            if (ModelState.IsValid)
            {
                EditBoardgame(editBoardgameViewModel);
                return RedirectToAction("Index", "Home");
            }
            UpdateEditBoardgameViewModel(editBoardgameViewModel);
            return View(editBoardgameViewModel);
        }

        private void EditBoardgame(EditBoardgameViewModel editBoardgameViewModel)
        {
            Boardgame boardgame = new Boardgame();
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<EditBoardgameViewModel, Boardgame>());
            IMapper mapper = config.CreateMapper();
            boardgame = mapper.Map<Boardgame>(editBoardgameViewModel);
            boardgame.ModifiedBy = HttpContext.User.Identity.Name;
            boardgame.ModifiedDate = DateTime.Now;
            db.Entry(boardgame).State = EntityState.Modified;
            db.SaveChanges();
        }

        // GET: Boardgames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boardgame boardgame = db.Boardgames.Find(id);
            if (boardgame == null)
            {
                return HttpNotFound();
            }
            return View(boardgame);
        }

        // POST: Boardgames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boardgame boardgame = db.Boardgames.Find(id);
            db.Boardgames.Remove(boardgame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpDelete]
        public ActionResult DynamicDelete(int? id)
        {
            if (id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            Boardgame boardgame = db.Boardgames.Find(id);
            if (boardgame == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            db.Boardgames.Remove(boardgame);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
