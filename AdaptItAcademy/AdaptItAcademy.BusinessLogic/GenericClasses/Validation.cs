using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.GenericClasses
{
    public class Validation
    {
        public string ValidateDateTime(string value, string fieldName)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    DateTime.Parse(value);
                    return null;
                }
                catch
                {
                    return fieldName + " is not a valid DateTime.<br />";
                }
            }
            else
            {
                return fieldName + " cannot be empty.<br />";
            }
        }

        public string ValidateDecimal(string value, string fieldName)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    Convert.ToDecimal(value);
                    return null;
                }
                catch (FormatException)
                {
                    return fieldName + " is not a valid decimal.<br />";
                }
            }
            else
            {
                return fieldName + " cannot be empty.<br />";
            }
        }

        public string ValidateInt(string value, string fieldName)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    Convert.ToInt32(value);
                    return null;
                }
                catch
                {
                    return fieldName + " is not a valid integer.<br />";
                }
            }
            else
            {
                return fieldName + " cannot be empty.<br />";
            }
        }

        public string IsStringInvalid(string text, int charNum, string columnName)
        {
            string result = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    if (Convert.ToInt32(text.Length) > charNum)
                    {
                        result = columnName + " length should not be above " + charNum + " characters.<br />";
                    }
                }
                else
                {
                    result = columnName + " is a required.<br />";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
