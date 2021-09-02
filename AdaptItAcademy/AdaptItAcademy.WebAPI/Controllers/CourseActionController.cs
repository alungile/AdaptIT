using AdaptItAcademy.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdaptItAcademy.WebAPI.Controllers
{
    public class CourseActionController : Controller
    {        
        protected CoursesAPIController apiConnect = new CoursesAPIController();

        #region View
        // GET: CourseAction 
        public ActionResult Index()
        {
            var model = new CourseModel();
            model.CourseList = apiConnect.GetCourses();
            return View(model);
        }

        public ActionResult courses()
        {
            var model = new CourseModel();
            model.CourseList = apiConnect.GetCourses();
            return View(model);
        }

        #endregion

        #region Create/Add New
        // GET: CourseAction/Create
        public ActionResult AddNew()
        {
            return View();
        }
        
        // POST: CourseAction/Create
        [HttpPost]
        public ActionResult Create(CourseModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var result = apiConnect.AddCourse(model);
                if (result != string.Empty)
                {
                    model.ErrorMessage = result;
                    return View(model);
                }
                
                return RedirectToAction("Courses");
            }
            catch(Exception)
            {
                model.ErrorMessage = "An error while occured while saving your record, please try again later";
                return View(model);
            }
        }
        #endregion

        #region Update
        // GET: CourseAction/Edit/5
        public ActionResult Edit(int id)
        {
            var course = apiConnect.GetCourse(id);
            var model = new CourseModel();
            model.ID = course.ID;
            model.CourseName = course.CourseName;
            model.CourseDescr = course.CourseDescr;
            model.CourseCode = course.CourseCode;
            model.IsCoursePaidFor = course.IsCoursePaidFor;
            model.IsCourseActive = course.IsCourseActive;
            return View(model);
        }

        // POST: CourseAction/Edit/5
        [HttpPost]
        public ActionResult Edit(CourseModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var result = apiConnect.UpdateCourse(model);
                if (result != string.Empty)
                {
                    model.ErrorMessage = result;
                    return View(model);
                }
                return RedirectToAction("courses");
            }
            catch
            {
                model.ErrorMessage = "An error while occured while saving your record, please try again later";
                return View(model);
            }
        }
        #endregion

        #region Delete
        
        public ActionResult Delete(int id)
        {
            try
            {
                var result = apiConnect.DeleteCourse(id);
                if (result != "")
                {
                    ViewBag.ErrorMessage = result;
                }

                return RedirectToAction("Courses");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "An error occured while deleting, Details : " + ex.Message;
                return View();
            }
        }
        #endregion
    }
}
