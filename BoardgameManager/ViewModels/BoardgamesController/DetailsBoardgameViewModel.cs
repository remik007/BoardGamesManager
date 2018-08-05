using BoardgameManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardgameManager.ViewModels.BoardgamesController
{
    public class DetailsBoardgameViewModel : BasicBoardgameViewModel
    {
        [Display(Name = "Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modified Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        public IList<BoardgameCall> BoardgameCalls { get; set; }
    }
}