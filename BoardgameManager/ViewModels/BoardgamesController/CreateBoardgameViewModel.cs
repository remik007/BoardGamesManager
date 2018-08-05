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
        [Display(Name = "Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        public SelectList AvailableBoardGameTypes { get; set; }
    }
}