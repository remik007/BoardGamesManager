using BoardgameManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardgameManager.ViewModels.BoardgamesController
{
    public class CreateBoardgameViewModel : BasicBoardgameViewModel
    {
        
        public SelectList AvailableBoardGameTypes { get; set; }
    }
}