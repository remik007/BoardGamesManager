//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoardgameManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BoardgameCall
    {
        public int Id { get; set; }
        public int Boardgame_Id { get; set; }
        public int CallType { get; set; }
        public Nullable<System.DateTime> CallDate { get; set; }
    
        public virtual Boardgame Boardgame { get; set; }
    }
}