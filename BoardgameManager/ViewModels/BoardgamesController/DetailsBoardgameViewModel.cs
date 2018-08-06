﻿using BoardgameManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardgameManager.ViewModels.BoardgamesController
{
    public class DetailsBoardgameViewModel : BasicBoardgameViewModel
    {
       
        public IList<BoardgameCall> BoardgameCalls { get; set; }
    }
}