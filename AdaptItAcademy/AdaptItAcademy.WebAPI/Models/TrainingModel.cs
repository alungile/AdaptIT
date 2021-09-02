using AdaptItAcademy.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdaptItAcademy.WebAPI.Models
{
    public class TrainingModel
    {
        public int ID { get; set; }
        public string Venue { get; set; }
        public int CourseID { get; set; }
        public int NumberOfSits { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal? TrainingCost { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegClosingDate { get; set; }
        public List<Training> TrainingList { get; set; }
    }
}