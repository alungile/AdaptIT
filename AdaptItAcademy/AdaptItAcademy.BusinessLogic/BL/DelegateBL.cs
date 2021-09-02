using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic
{
    public class DelegateBL
    {
        protected GenericClasses.Validation validate = new GenericClasses.Validation();
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public string CheckValidInputs(DataAccess.Delegate model)
        {
            string returnMessage = string.Empty;
            if (!IsValidEmail(model.Email))
            {
                returnMessage = "Email input is not a correct email format.\n";
            }

            //Validate all fields and return error message
            returnMessage += validate.IsStringInvalid(model.FirstName, 20, "First Name");
            returnMessage += validate.IsStringInvalid(model.LastName, 20, "Last Name");
            returnMessage += validate.IsStringInvalid(model.Telephone, 20, "Telephone");
            returnMessage += validate.IsStringInvalid(model.Email, 50, "Email");
            returnMessage += validate.IsStringInvalid(model.CompanyName, 50, "Company Name");
            returnMessage += validate.IsStringInvalid(model.PostalAddress1, 50, "Postal Address1");
            returnMessage += validate.IsStringInvalid(model.PostalAddress2, 50, "Postal Address2");
            returnMessage += validate.IsStringInvalid(model.PostalAddress3, 50, "Postal Address3");
            returnMessage += validate.IsStringInvalid(model.PostalCity, 20, "Postal City");
            returnMessage += validate.IsStringInvalid(model.PostalCode, 10, "Postal Code");
            returnMessage += validate.IsStringInvalid(model.PhysicalAddress1, 50, "Postal Address1");
            returnMessage += validate.IsStringInvalid(model.PhysicalAddress2, 50, "Physical Address2");
            returnMessage += validate.IsStringInvalid(model.PhysicalAddress3, 50, "Physical Address3");
            returnMessage += validate.IsStringInvalid(model.PhysicalCity, 20, "Physical City");
            returnMessage += validate.IsStringInvalid(model.PhysicalCode, 10, "Physical Code");

            return returnMessage;
        }
        
    }
}
