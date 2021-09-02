using System;
using AdaptItAcademy.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.DataAccess.GenericRepository;

namespace AdaptItAcademy.WebAPI.Controllers
{
    public class CoursesAPIController : ApiController
    {
        protected AdaptItAcademy.BusinessLogic.CourseBL courseBL = new AdaptItAcademy.BusinessLogic.CourseBL();
        protected EFServices efService = new EFServices();
        private IGenericRepository<Course> repository = null;

        public CoursesAPIController()
        {
            this.repository = new GenericRepository<Course>();
        }

        public CoursesAPIController(IGenericRepository<Course> repo)
        {
            this.repository = repo;
        }

        [HttpGet]
        public List<Course> GetCourses()
        {
            return repository.GetAll();
        }

        [HttpGet]
        public Course GetCourse(int courseID)
        {
            return repository.GetById(courseID);
        }

        [HttpPost]
        public string AddCourse(CourseModel model)
        {
            var course = new Course();
            try
            {
                course.CourseName = model.CourseName;
                course.CourseDescr = model.CourseDescr;
                course.CourseCode = model.CourseCode;
                course.IsCoursePaidFor = model.IsCoursePaidFor;
                course.IsCourseActive = model.IsCourseActive;

                //Validate input filds
                var validation = courseBL.CheckValidInputs(course);
                if (validation != "")
                {
                    return validation;
                }

                repository.Insert(course);
                repository.Save();
            }
            catch (Exception)
            {
                return "An error occured while saving, please check and try again ";
            }

            return string.Empty;
        }

        [HttpPut]
        public string UpdateCourse(CourseModel model)
        {
            var course = new Course();
            try
            {
                course.ID = model.ID;
                course.CourseName = model.CourseName;
                course.CourseDescr = model.CourseDescr;
                course.CourseCode = model.CourseCode;
                course.IsCoursePaidFor = model.IsCoursePaidFor;
                course.IsCourseActive = model.IsCourseActive;

                //Validate input filds
                var validation = courseBL.CheckValidInputs(course);
                if (validation != "")
                {
                    return validation;
                }

                repository.Update(course);
                repository.Save();
            }
            catch (Exception ex)
            {
                return "An error occured while updating, please check and try again ";
            }

            return string.Empty;
        }

        [HttpDelete]
        public string DeleteCourse(int courseId)
        {
            try
            {
                //First Delete the training linked to this course
                efService.DeleteTrainingForCourse(courseId);

                // Remove the course from the Delegate
                efService.DeleteCourseFromDelegate(courseId);

                // Then Delete the course
                repository.Delete(courseId);
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

