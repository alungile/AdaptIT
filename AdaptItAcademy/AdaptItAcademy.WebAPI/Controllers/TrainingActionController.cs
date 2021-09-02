using AdaptItAcademy.BusinessLogic.Models;
using AdaptItAcademy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdaptItAcademy.WebAPI.Controllers
{
    public class TrainingActionController : Controller
    {
        protected AdaptItAcademy.BusinessLogic.CourseBL logic = new AdaptItAcademy.BusinessLogic.CourseBL();
        protected TrainingAPIController apiConnect = new TrainingAPIController();
        protected EFServices efService = new EFServices();

        public ActionResult Index()
        {
            var model = new TrainingModel();
            model.TrainingList = apiConnect.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new TrainingModel();
            model.CoursesList = efService.GetAllActiveCourses();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            model.RegClosingDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TrainingModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CoursesList = efService.GetAllActiveCourses();
                return View(model);
            }
            try
            {
                var training = new Training();
                training.Venue = model.Venue;
                training.CourseID = model.CourseID;
                training.NumberOfSits = model.NumberOfSits;
                training.StartDate = model.StartDate;
                training.EndDate = model.EndDate;
                training.RegClosingDate = model.RegClosingDate;
                training.TrainingCost = model.TrainingCost;
                var result = apiConnect.Create(training);
                if (result != string.Empty)
                {
                    model.CoursesList = efService.GetAllActiveCourses();
                    model.ErrorMessage = result;
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                model.CoursesList = efService.GetAllActiveCourses();
                model.ErrorMessage = "An error while occured while saving your record: " + ex.Message;
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var details = apiConnect.GetById(id);
            var model = new TrainingModel();
            model.ID = details.ID;
            model.Venue = details.Venue;
            model.CourseID = details.CourseID;
            model.NumberOfSits = details.NumberOfSits;
            model.StartDate = details.StartDate;
            model.EndDate = details.EndDate;
            model.TrainingCost = details.TrainingCost;
            model.RegClosingDate = details.RegClosingDate;
            model.CoursesList = efService.GetAllActiveCourses();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TrainingModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CoursesList = efService.GetAllActiveCourses();
                return View(model);
            }
            try
            {
                var training = new Training();
                training.ID = model.ID;
                training.Venue = model.Venue;
                training.CourseID = model.CourseID;
                training.NumberOfSits = model.NumberOfSits;
                training.StartDate = model.StartDate;
                training.EndDate = model.EndDate;
                training.RegClosingDate = model.RegClosingDate;
                training.TrainingCost = model.TrainingCost;

                var result = apiConnect.Update(training);
                if (result != string.Empty)
                {
                    model.ErrorMessage = result;
                    model.CoursesList = efService.GetAllActiveCourses();
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                model.CoursesList = efService.GetAllActiveCourses();
                model.ErrorMessage = "An error while occured while saving your record, please try again later";
                return View(model);
            }
        }
                
        public ActionResult Delete(int id)
        {
            try
            {
                var result = apiConnect.Delete(id);
                if (result != "")
                {
                    ViewBag.ErrorMessage = result;
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occured while deleting, Details : " + ex.Message;
                return View();
            }
        }
    }
}
