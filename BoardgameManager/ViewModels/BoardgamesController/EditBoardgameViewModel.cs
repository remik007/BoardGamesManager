using BoardgameManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardgameManager.ViewModels.BoardgamesController
{
    public class EditBoardgameViewModel : BasicBoardgameViewModel
    {
        
        public SelectList AvailableBoardGameTypes { get; set; }
        [Display(Name = "Board Game Calls")]
        public IList<BoardgameCall> BoardgameCalls { get; set; }
        public virtual string ReleaseDateFormatted
        {
            get
            {
                if (ReleaseDate != null)
                {
                    return ReleaseDate.Value.ToString("dd-MMM-yyyy");
                }
                return null;
            }
        }
    }
}