using AdaptItAcademy.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdaptItAcademy.WebAPI.Models
{
    public class CourseModel
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescr { get; set; }
        [DataType(DataType.Currency)]
        public bool IsCoursePaidFor { get; set; }
        public bool IsCourseActive { get; set; }
        public List<Course> CourseList { get; set; }
    }
}