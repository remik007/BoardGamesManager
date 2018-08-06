using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameManager.Models
{
    interface IAudit
    {
        Nullable<System.DateTime> CreatedDate { get; set; }
        string CreatedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
}
