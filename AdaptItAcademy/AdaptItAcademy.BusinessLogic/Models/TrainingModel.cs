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
    public class TrainingModel
    {
        public int ID { get; set; }

        [DisplayName("Venue")]
        [Required(ErrorMessage = "Required"), MaxLength(20)]
        public string Venue { get; set; }

        [DisplayName("Course")]
        [Required(ErrorMessage = "Required")]
        public int CourseID { get; set; }

        [DisplayName("Capacity")]
        [Required(ErrorMessage = "Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int NumberOfSits { get; set; }

        [DisplayName("Start Date")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [DisplayName("Training Cost")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal? TrainingCost { get; set; }

        [DisplayName("Closing Date")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegClosingDate { get; set; }

        public List<Training> TrainingList { get; set; }
        public List<Course> CoursesList { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
