//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LINQ_LandenStedenTalen_MySql
{
    using System;
    using System.Collections.Generic;
    
    public partial class lst_Taal
    {
        public lst_Taal()
        {
            this.lst_Landen = new HashSet<lst_Land>();
        }
    
        public string TaalCode { get; set; }
        public string Naam { get; set; }
    
        public virtual ICollection<lst_Land> lst_Landen { get; set; }
    }
}
