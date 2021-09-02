using AdaptItAcademy.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdaptItAcademy.WebAPI.Models
{
    public class DelegateModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [DataType(DataType.EmailAddress)]
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
        public List<DataAccess.Delegate> DelegateList { get; set; }
    }
}