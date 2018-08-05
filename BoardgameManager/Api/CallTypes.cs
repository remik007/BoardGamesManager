using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardgameManager.Api
{
    public enum CallTypes
    {
        [Display(Name = "Web Service call")]
        WebService = 1,

        [Display(Name = "Website call")]
        Website = 2
    }
}