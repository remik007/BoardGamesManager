﻿using BoardgameManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardgameManager.ViewModels.BoardgamesController
{
    public class BasicBoardgameViewModel : IAudit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name = "Board Game Name")]
        public string Name { get; set; }
        [Display(Name = "Minimal Age")]
        [Range(0,18)]
        [StringLength(2)]
        public string MinAge { get; set; }
        public Nullable<int> BoardGameType_Id { get; set; }
        [Display(Name = "Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        [Display(Name = "Board Game Type")]
        public BoardGameType BoardGameType { get; set; }

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
    }
}