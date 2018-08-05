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
    
    public partial class Boardgame
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Boardgame()
        {
            this.BoardgameCalls = new HashSet<BoardgameCall>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string MinAge { get; set; }
        public Nullable<int> BoardGameType_Id { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
    
        public virtual BoardGameType BoardGameType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoardgameCall> BoardgameCalls { get; set; }
    }
}
