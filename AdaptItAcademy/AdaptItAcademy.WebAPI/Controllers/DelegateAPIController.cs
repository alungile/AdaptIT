using AdaptItAcademy.DataAccess.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdaptItAcademy.DataAccess;

namespace AdaptItAcademy.WebAPI.Controllers
{
    public class DelegateAPIController : ApiController
    {
        private BusinessLogic.DelegateBL delegateBL = new AdaptItAcademy.BusinessLogic.DelegateBL();
        private BusinessLogic.TrainingBL trainingBL = new AdaptItAcademy.BusinessLogic.TrainingBL();
        private IGenericRepository<DataAccess.Delegate> repository = null;

        public DelegateAPIController()
        {
            this.repository = new GenericRepository<DataAccess.Delegate>();
        }

        public DelegateAPIController(IGenericRepository<DataAccess.Delegate> repo)
        {
            this.repository = repo;
        }

        [HttpGet]
        public List<DataAccess.Delegate> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet]
        public DataAccess.Delegate GetById(int delegateID)
        {
            return repository.GetById(delegateID);
        }

        [HttpPost]
        public string Create(DataAccess.Delegate model)
        {
            try
            {
                //Validate all input fields
                var result = delegateBL.CheckValidInputs(model);
                if (result != string.Empty)
                {
                    return result;
                }
                // Check if the Training Venue for this course is not full
                if (model.CourseID != null)
                {
                   var isFull = trainingBL.IsVenueFull((int)model.CourseID);
                    if (isFull)
                    {
                        return "Training venue for this course is full.";
                    }
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
        public string Update(DataAccess.Delegate model)
        {
            try
            {
                var result = delegateBL.CheckValidInputs(model);
                if (result != string.Empty)
                {
                    return result;
                }

                // Update Delegate
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
        public string Delete(int delegateID)
        {
            try
            {
                repository.Delete(delegateID);
                repository.Save();
            }
            catch (Exception)
            {
                return "An error occured while deleting, please try again ";
            }
            return string.Empty;
        }
    }
}
