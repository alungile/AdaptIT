//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdaptItAcademy.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Delegate
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int DietaryID { get; set; }
        public string CompanyName { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalAddress3 { get; set; }
        public string PostalCity { get; set; }
        public string PostalCode { get; set; }
        public string PhysicalAddress1 { get; set; }
        public string PhysicalAddress2 { get; set; }
        public string PhysicalAddress3 { get; set; }
        public string PhysicalCity { get; set; }
        public string PhysicalCode { get; set; }
        public Nullable<int> CourseID { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual DietaryRequirement DietaryRequirement { get; set; }
    }
}