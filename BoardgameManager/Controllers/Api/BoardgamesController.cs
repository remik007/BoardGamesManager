using BoardgameManager.Api;
using BoardgameManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace BoardgameManager.Controllers.Api
{
    public class BoardgamesController : ApiController
    {
        private BoardgameDBEntities db = new BoardgameDBEntities();
        // GET /api/boardgames
        [Route("api/boardgames/{amount}/")]
        public IEnumerable<Boardgame> GetBoardgames(int amount)
        {
            var boardgames = db.Boardgames.Take(amount).ToList();
            var datetime = DateTime.Now;
            foreach(var item in boardgames)
            {
                UpdateBoardgameCall(item.Id, DateTime.Now);
                db.SaveChanges();
            }
            return boardgames;
        }
        // GET /api/boardgame
        [Route("api/boardgame/{id}/")]
        public Boardgame GetBoardgameDetails(int id)
        {
            var boardgame = db.Boardgames.Where(x => x.Id == id).FirstOrDefault();
            if(boardgame == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            UpdateBoardgameCall(boardgame.Id, DateTime.Now);
            db.SaveChanges();
            return boardgame;
        }

        private void UpdateBoardgameCall(int id, DateTime datetime)
        {
            BoardgameCall boardgameCall = new BoardgameCall();
            boardgameCall.Boardgame_Id = id;
            boardgameCall.CallDate = datetime;
            boardgameCall.CallType = Convert.ToInt32(CallTypes.WebService);
            db.BoardgameCalls.Add(boardgameCall);
            db.SaveChanges();
        }
    }
}
