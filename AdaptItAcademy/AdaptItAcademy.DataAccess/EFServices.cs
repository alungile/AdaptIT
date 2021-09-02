using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess
{
    public class EFServices
    {
        protected AdaptItAcademyEntities DB = new AdaptItAcademyEntities();

        #region Training
        public int GetVenueCapacity(int courseID)
        {
            try
            {
                return DB.Trainings
                         .Where(x => x.CourseID == courseID)
                         .Select(x => x.NumberOfSits).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTrainingForCourse(int courseID)
        {
            try
            {
                var result = DB.Trainings
                               .Where(x => x.CourseID == courseID)
                               .FirstOrDefault();

                if (result != null)
                {
                    DB.Trainings.Remove(result);
                    DB.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
            
        }
        #endregion

        #region Delegate
        public List<Delegate> GetDelegatesByCourseID(int courseID)
        {
            try
            {
                return DB.Delegates
                         .Where(x => x.CourseID == courseID)
                         .Select(x => x).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCourseFromDelegate(int courseID)
        {
            try
            {
                var result = DB.Delegates
                               .Where(x => x.CourseID == courseID)
                               .FirstOrDefault();

                if (result != null)
                {
                    result.CourseID = null;
                    DB.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }

        #endregion

        #region Course
        public bool IsPaidFor(int courseID)
        {
            bool isPaidFor = false;
            try
            {
                isPaidFor =  DB.Courses
                               .Where(x => x.ID == courseID)
                               .Select(x => x.IsCoursePaidFor).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return isPaidFor;
        }

        public List<Course> GetAllActiveCourses()
        {
            return DB.Courses
                     .Where(x => x.IsCourseActive).ToList();
        }
       
        #endregion
    }
}
