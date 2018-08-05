using BoardgameManager.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BoardgameManager.Models
{
    public class BoardgameCallMetadata
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Board Game")]
        public int Boardgame_Id { get; set; }
        [Display(Name = "Call Type")]
        public int CallType { get; set; }
        [Display(Name = "Call Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}")]
        public Nullable<System.DateTime> CallDate { get; set; }
        [Display(Name = "Board Game")]
        public virtual Boardgame Boardgame { get; set; }
    }
    [MetadataType(typeof(BoardgameCallMetadata))]
    public partial class BoardgameCall
    {
        public virtual string CallDateFormatted
        {
            get
            {
                if (CallDate != null)
                {
                    return CallDate.Value.ToString("dd-MMM-yyyy hh:mm tt");
                }
                return null;
            }
        }

        public virtual string CallTypeFormatted
        {
            get
            {
                
                    var temp = Enum.Parse(typeof(CallTypes), CallType.ToString());
                    return temp.GetType()
                            .GetMember(temp.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>().Name;
                
            }
        }
    }
}