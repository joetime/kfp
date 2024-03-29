//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KfpWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pick
    {
        public int id { get; set; }
        public int week { get; set; }
        public string userId { get; set; }
        public string pick5TeamId { get; set; }
        public string pick3TeamId { get; set; }
        public string pick2TeamId { get; set; }
        public System.DateTime dateCreated { get; set; }
        public string userCreatedId { get; set; }
        public bool deleted { get; set; }
    
        public virtual Team Pick2Team { get; set; }
        public virtual Team Pick3Team { get; set; }
        public virtual Team Pick5Team { get; set; }
        public virtual User UserCreated { get; set; }
        public virtual User User { get; set; }
    }
}
