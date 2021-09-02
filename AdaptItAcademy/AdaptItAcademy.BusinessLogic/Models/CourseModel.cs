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
    public class CourseModel
    {
        public int ID { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Required"), MaxLength(20)]
        public string CourseName { get; set; }

        [DisplayName("Code")]
        [Required(ErrorMessage = "Required"), MaxLength(10)]
        public string CourseCode { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Required"), MaxLength(200)]
        public string CourseDescr { get; set; }

        [DisplayName("Paid For")]
        public bool IsCoursePaidFor { get; set; }

        [DisplayName("Active")]
        public bool IsCourseActive { get; set; }

        public List<Course> CourseList { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
