//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public string RoleNumber { get; set; }
        public string Role1 { get; set; }
        public string RoleDescription { get; set; }
        public int StudentID { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
