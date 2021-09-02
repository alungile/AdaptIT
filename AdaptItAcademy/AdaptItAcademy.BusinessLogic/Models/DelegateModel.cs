using AdaptItAcademy.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.Models
{
    public class DelegateModel
    {
        public int ID { get; set; }

        [DisplayName("Course")]
        public int? CourseID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Required"), MaxLength(20)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Required"), MaxLength(20)]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Required"), MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required"), MaxLength(20)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Diet")]
        [Required(ErrorMessage = "Required")]
        public int DietaryID { get; set; }

        [DisplayName("Company Name")]
        [Required(ErrorMessage = "Required"), MaxLength(50)]
        public string CompanyName { get; set; }

        [DisplayName("Address Line 1")]
        public string PostalAddress1 { get; set; }

        [DisplayName("Address Line 2")]
        public string PostalAddress2 { get; set; }

        [DisplayName("Address Line 3")]
        public string PostalAddress3 { get; set; }

        [DisplayName("Postal City")]
        [Required(ErrorMessage = "Required"), MaxLength(20)]
        public string PostalCity { get; set; }

        [DisplayName("Postal Code")]
        [Required(ErrorMessage = "Required"), MaxLength(20)]
        public string PostalCode { get; set; }

        [DisplayName("Address Line 1")]
        public string PhysicalAddress1 { get; set; }

        [DisplayName("Address Line 2")]
        public string PhysicalAddress2 { get; set; }

        [DisplayName("Address Line3")]
        public string PhysicalAddress3 { get; set; }

        [DisplayName("Physical City")]
        [Required(ErrorMessage = "Required"), MaxLength(20)]
        public string PhysicalCity { get; set; }

        [DisplayName("Physical Code")]
        [Required(ErrorMessage = "Required"), MaxLength(10)]
        public string PhysicalCode { get; set; }

        public List<DataAccess.Delegate> DelegateList { get; set; }
        public List<Course> CoursesList { get; set; }
        public List<DietaryRequirement> DietaryList { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
