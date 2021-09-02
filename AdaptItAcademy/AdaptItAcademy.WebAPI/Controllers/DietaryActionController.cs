using AdaptItAcademy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdaptItAcademy.WebAPI.Controllers
{
    public class DietaryActionController : Controller
    {
        protected DietaryRequirementsAPIController apiConnect = new DietaryRequirementsAPIController();
        // GET: DietaryAction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DietaryRequirement model)
        {
            try
            {
                var result = apiConnect.Create(model);
                if (result != string.Empty)
                {
                    ViewBag.ErrorMessage = result;
                    return View();
                }

                return RedirectToAction("Create","DelegateAction");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error while occured while saving your record: " + ex.Message;
                return View();
            }
        }

        // GET: DietaryAction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DietaryAction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DietaryAction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DietaryAction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
