using AdaptItAcademy.DataAccess;
using AdaptItAcademy.DataAccess.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic
{
    public class CourseBL
    {
        protected GenericClasses.Validation validate = new GenericClasses.Validation();
        protected EFServices efService = new EFServices();

        public bool IsCoursePaidFor(int couseId)
        {
            return efService.IsPaidFor(couseId);
        }

        public string CheckValidInputs(Course model)
        {
            string returnMessage = string.Empty;

            //Validate all fields and return error message
            returnMessage += validate.IsStringInvalid(model.CourseName, 20, "Course Name");
            returnMessage += validate.IsStringInvalid(model.CourseCode, 10, "Course Code");
            returnMessage += validate.IsStringInvalid(model.CourseDescr, 200, "Description");

            return returnMessage;
        }
    }
}
