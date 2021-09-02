using AdaptItAcademy.BusinessLogic.Models;
using AdaptItAcademy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdaptItAcademy.WebAPI.Controllers
{
    public class DelegateActionController : Controller
    {
        protected DelegateAPIController apiConnect = new DelegateAPIController();
        protected DietaryRequirementsAPIController DietaryApiConnect = new DietaryRequirementsAPIController();
        protected EFServices efService = new EFServices();

        public ActionResult Index()
        {
            var model = new DelegateModel();
            model.DelegateList = apiConnect.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new DelegateModel();
            model.DietaryList = DietaryApiConnect.GetAll();
            model.CoursesList = efService.GetAllActiveCourses();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DelegateModel model)
        {
            if (!ModelState.IsValid)
            {
                model.DietaryList = DietaryApiConnect.GetAll();
                model.CoursesList = efService.GetAllActiveCourses();
                return View(model);
            }
            try
            {
                var delgate = new DataAccess.Delegate();
                delgate.FirstName = model.FirstName;
                delgate.LastName = model.LastName;
                delgate.Telephone = model.Telephone;
                delgate.Email = model.Email;
                delgate.DietaryID = model.DietaryID;
                delgate.CourseID = model.CourseID;
                delgate.CompanyName = model.CompanyName;
                delgate.PostalAddress1 = model.PostalAddress1;
                delgate.PostalAddress2 = model.PostalAddress2;
                delgate.PostalAddress3 = model.PostalAddress3;
                delgate.PostalCity = model.PostalCity;
                delgate.PostalCode = model.PostalCode;
                delgate.PhysicalAddress1 = model.PhysicalAddress1;
                delgate.PhysicalAddress2 = model.PhysicalAddress2;
                delgate.PhysicalAddress3 = model.PhysicalAddress3;
                delgate.PhysicalCity = model.PhysicalCity;
                delgate.PhysicalCode = model.PhysicalCode;

                var result = apiConnect.Create(delgate);
                if (result != string.Empty)
                {
                    model.CoursesList = efService.GetAllActiveCourses();
                    model.DietaryList = DietaryApiConnect.GetAll();
                    model.ErrorMessage = result;
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                model.DietaryList = DietaryApiConnect.GetAll();
                model.CoursesList = efService.GetAllActiveCourses();
                model.ErrorMessage = "An error while occured while saving your record: " + ex.Message;
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var delegateDetails = apiConnect.GetById(id);
            var model = new DelegateModel();
            model.ID = delegateDetails.ID;
            model.CourseID = delegateDetails.CourseID;
            model.FirstName = delegateDetails.FirstName;
            model.LastName = delegateDetails.LastName;
            model.Telephone = delegateDetails.Telephone;
            model.Email = delegateDetails.Email;
            model.DietaryID = delegateDetails.DietaryID;
            model.CompanyName = delegateDetails.CompanyName;
            model.PostalAddress1 = delegateDetails.PostalAddress1;
            model.PostalAddress2 = delegateDetails.PostalAddress2;
            model.PostalAddress3 = delegateDetails.PostalAddress3;
            model.PostalCity = delegateDetails.PostalCity;
            model.PostalCode = delegateDetails.PostalCode;
            model.PhysicalAddress1 = delegateDetails.PhysicalAddress1;
            model.PhysicalAddress2 = delegateDetails.PhysicalAddress2;
            model.PhysicalAddress3 = delegateDetails.PhysicalAddress3;
            model.PhysicalCity = delegateDetails.PhysicalCity;
            model.PhysicalCode = delegateDetails.PhysicalCode;
            model.DietaryList = DietaryApiConnect.GetAll();
            model.CoursesList = efService.GetAllActiveCourses();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DelegateModel model)
        {
            if (!ModelState.IsValid)
            {
                model.DietaryList = DietaryApiConnect.GetAll();
                model.CoursesList = efService.GetAllActiveCourses();
                return View(model);
            }
            try
            {
                var delgate = new DataAccess.Delegate();
                delgate.ID = model.ID;
                delgate.FirstName = model.FirstName;
                delgate.LastName = model.LastName;
                delgate.Telephone = model.Telephone;
                delgate.Email = model.Email;
                delgate.DietaryID = model.DietaryID;
                delgate.CompanyName = model.CompanyName;
                delgate.CourseID = model.CourseID;
                delgate.PostalAddress1 = model.PostalAddress1;
                delgate.PostalAddress2 = model.PostalAddress2;
                delgate.PostalAddress3 = model.PostalAddress3;
                delgate.PostalCity = model.PostalCity;
                delgate.PostalCode = model.PostalCode;
                delgate.PhysicalAddress1 = model.PhysicalAddress1;
                delgate.PhysicalAddress2 = model.PhysicalAddress2;
                delgate.PhysicalAddress3 = model.PhysicalAddress3;
                delgate.PhysicalCity = model.PhysicalCity;
                delgate.PhysicalCode = model.PhysicalCode;

                var result = apiConnect.Update(delgate);
                if (result != string.Empty)
                {
                    model.ErrorMessage = result;
                    model.DietaryList = DietaryApiConnect.GetAll();
                    model.CoursesList = efService.GetAllActiveCourses();
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                model.DietaryList = DietaryApiConnect.GetAll();
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
