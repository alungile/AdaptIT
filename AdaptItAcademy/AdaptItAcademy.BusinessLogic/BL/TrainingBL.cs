using AdaptItAcademy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic
{
    public class TrainingBL
    {
        protected GenericClasses.Validation validate = new GenericClasses.Validation();
        protected EFServices efService = new EFServices();

        public string ValidateStartEndDates(DateTime startDate, DateTime endDate)
        {
            string returnMsg = string.Empty;
            try
            {
                // Check if endDate is NOT before startDate
                if (startDate > endDate)
                { 
                    returnMsg = "Start Date cannot be after the End Date";
                }
                else if(DateTime.Now > endDate)
                { 
                    // Check if endDate is NOT before today/Today
                    returnMsg = "End Date should be in the future";
                }
            }
            catch (Exception)
            {
                returnMsg = "Please input valid Start Date and End Date";
            }
            return returnMsg;
        }

        public string ValidateClosingDates(DateTime regDate, DateTime startDate)
        {
            string returnMsg = string.Empty;
            try
            {
                // Check if closingDate is NOT before now
                if (regDate <= DateTime.Now)
                { 
                    returnMsg = "Registration closing date cannot be before today";
                }
                else if (regDate > startDate)
                {
                    returnMsg = "Registration closing date cannot be after Start date";
                }
            }
            catch (Exception)
            {
                returnMsg = "Please input valid closing date";
            }
            return returnMsg;
        }

        public bool IsVenueFull(int courseID)
        {
            try
            {

                int numberOfRegistered = efService.GetDelegatesByCourseID(courseID).Count();
                int capacity = efService.GetVenueCapacity(courseID); 

                if (numberOfRegistered >= capacity)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }

        public int GetNumberOfAvailableSits(int courseID)
        {
            try
            {
                int numberOfRegistered = efService.GetDelegatesByCourseID(courseID).Count();
                int Capacity = efService.GetVenueCapacity(courseID);

                return Capacity - numberOfRegistered;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string CheckValidInputs(DataAccess.Training model)
        {
            string returnMessage = string.Empty;

            //Validate all fields and return error message
            returnMessage += validate.IsStringInvalid(model.Venue, 20, "Venue");
            returnMessage += validate.ValidateInt(model.NumberOfSits.ToString(), "Capacity");
            returnMessage += validate.ValidateDecimal(model.TrainingCost.ToString(), "Training Cost");
            returnMessage += validate.ValidateDateTime(model.StartDate.ToString(), "StartDate");
            returnMessage += validate.ValidateDateTime(model.EndDate.ToString(), "EndDate");
            returnMessage += validate.ValidateDateTime(model.RegClosingDate.ToString(), "RegClosingDate");

            return returnMessage;
        }

    }
}
