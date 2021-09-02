using AdaptItAcademy.BusinessLogic;
using AdaptItAcademy.BusinessLogic.Models;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.DataAccess.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdaptItAcademy.WebAPI.Controllers
{
    public class TrainingAPIController : ApiController
    {
        private BusinessLogic.TrainingBL trainingBL = new AdaptItAcademy.BusinessLogic.TrainingBL();
        private BusinessLogic.CourseBL courseBL = new AdaptItAcademy.BusinessLogic.CourseBL();

        private IGenericRepository<Training> repository = null;
        
        public TrainingAPIController()
        {
            this.repository = new GenericRepository<Training>();
        }

        public TrainingAPIController(IGenericRepository<Training> repo)
        {
            this.repository = repo;
        }

        [HttpGet]
        public List<Training> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet]
        public Training GetById(int trainingID)
        {
            return repository.GetById(trainingID);
        }

        [HttpPost]
        public string Create(Training model)
        {            
            try
            {
                //Validate all input fields
                var inputValidation = trainingBL.CheckValidInputs(model);
                if (inputValidation != "")
                {
                    return inputValidation;
                }

                // Check if the dates are valid inputs
                var trainingDatesResult = trainingBL.ValidateStartEndDates(model.StartDate, model.EndDate);
                if (trainingDatesResult != string.Empty)
                {
                    return trainingDatesResult;
                }

                // Check if the closing date is valid input
                var closingDatesResult = trainingBL.ValidateClosingDates(model.RegClosingDate, model.StartDate);
                if (closingDatesResult != string.Empty)
                {
                    return closingDatesResult;
                }

                // Checks if the Course training is paid for and assigns amount if True
                bool isCourseTrainingFree = courseBL.IsCoursePaidFor(model.CourseID);
                if (isCourseTrainingFree)
                {
                    model.TrainingCost = GlobalVariables.amountPaidFor;
                }
                else
                {
                    model.TrainingCost = Math.Round((decimal)model.TrainingCost, 2);
                }

                // Save
                repository.Insert(model);
                repository.Save();
            }
            catch (Exception ex)
            {
                return "An error occured while saving, please check and try again ";
            }

            return string.Empty;
        }

        [HttpPut]
        public string Update(Training model)
        {
            try
            {
                //Validate all input fields
                var inputValidation = trainingBL.CheckValidInputs(model);
                if (inputValidation != "")
                {
                    return inputValidation;
                }

                // Check if the dates are valid inputs
                var trainingDatesResult = trainingBL.ValidateStartEndDates(model.StartDate, model.EndDate);
                if (trainingDatesResult != string.Empty)
                {
                    return trainingDatesResult;
                }

                // Check if the closing date is valid input
                var closingDatesResult = trainingBL.ValidateClosingDates(model.RegClosingDate, model.StartDate);
                if (closingDatesResult != string.Empty)
                {
                    return closingDatesResult;
                }

                // Checks if the Course training is paid for and assigns amount if True
                bool isCourseTrainingFree = courseBL.IsCoursePaidFor(model.CourseID);
                model.TrainingCost = isCourseTrainingFree ? GlobalVariables.amountPaidFor : model.TrainingCost;
               
                // Now Update
                repository.Update(model);
                repository.Save();
            }
            catch (Exception ex)
            {
                return "An error occured while updating, please check and try again ";
            }

            return string.Empty;
        }

        [HttpDelete]
        public string Delete(int trainingID)
        {
            try
            {
                repository.Delete(trainingID);
                repository.Save();
            }
            catch (Exception)
            {
                return "An error occured while deleting,, please try again ";
            }
            return string.Empty;
        }
    }
}
