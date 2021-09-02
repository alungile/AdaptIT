using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess
{
    public class SQLServices
    {
        public void SaveDelegateCourse(int DelegateID, int CourseID)
        {
            var sqlCon = AdaptItAcademy.DataAccess.SQLConnectionManager.CreateCon();
            SqlCommand sqlCmd = null;
            try
            {
                DataTable dtData = new DataTable();
                sqlCmd = new SqlCommand("spInsertDelegateCourse", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DelegateID", DelegateID);
                sqlCmd.Parameters.AddWithValue("@CourseID", CourseID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // Logging here
            }
            finally
            {
                sqlCmd.Dispose();
                AdaptItAcademy.DataAccess.SQLConnectionManager.CloseConn(sqlCon);
            }
        }

        public void DeleteDelegateCourseByDelegateID(int DelegateID)
        {
            var sqlCon = AdaptItAcademy.DataAccess.SQLConnectionManager.CreateCon();
            SqlCommand sqlCmd = null;
            try
            {
                DataTable dtData = new DataTable();
                sqlCmd = new SqlCommand("spDeleteDelegateCourseByDelegateID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DelegateID", DelegateID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // Logging here
            }
            finally
            {
                sqlCmd.Dispose();
                AdaptItAcademy.DataAccess.SQLConnectionManager.CloseConn(sqlCon);
            }
        }

        public void DeleteDelegateCourseByCourseID(int CourseID)
        {
            var sqlCon = AdaptItAcademy.DataAccess.SQLConnectionManager.CreateCon();
            SqlCommand sqlCmd = null;
            try
            {
                DataTable dtData = new DataTable();
                sqlCmd = new SqlCommand("spDeleteDelegateCourseByCourseID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CourseID", CourseID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //ErrorLogging here
            }
            finally
            {
                sqlCmd.Dispose();
                AdaptItAcademy.DataAccess.SQLConnectionManager.CloseConn(sqlCon);
            }
        }

        public void UpdateDelegateCourse(int delegateID, int courseID)
        {
            var sqlCon = AdaptItAcademy.DataAccess.SQLConnectionManager.CreateCon();
            SqlCommand sqlCmd = null;
            try
            {
                var sql = @"UPDATE DelegateCourse
                            SET CourseID = @CourseID
                            WHERE DelegateID = @DelegateID";
                DataTable dtData = new DataTable();
                sqlCmd = new SqlCommand(sql, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@DelegateID", delegateID);
                sqlCmd.Parameters.AddWithValue("@CourseID", courseID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //Error Logging here
            }
            finally
            {
                sqlCmd.Dispose();
                AdaptItAcademy.DataAccess.SQLConnectionManager.CloseConn(sqlCon);
            }
        }
    }
}
