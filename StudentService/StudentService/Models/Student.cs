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
    
    public partial class Student
    {
        public long AutoID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Telephone { get; set; }
        public System.DateTime DOB { get; set; }
        public string Level { get; set; }
        public string Email { get; set; }
        public bool VerifyEmail { get; set; }
        public string Password { get; set; }
        public System.Guid ActivationCode { get; set; }
    }
}
