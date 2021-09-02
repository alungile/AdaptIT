using AdaptItAcademy.DataAccess;
using AdaptItAcademy.DataAccess.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdaptItAcademy.WebAPI.Controllers
{
    public class DietaryRequirementsAPIController : ApiController
    {
        private IGenericRepository<DietaryRequirement> repository = null;

        public DietaryRequirementsAPIController()
        {
            this.repository = new GenericRepository<DietaryRequirement>();
        }

        public DietaryRequirementsAPIController(IGenericRepository<DietaryRequirement> repo)
        {
            this.repository = repo;
        }

        [HttpGet]
        public List<DietaryRequirement> GetAll()
        {
            var result = repository.GetAll();

            return repository.GetAll();
        }

        public string Create(DietaryRequirement model)
        {
            try
            {

                // Save
                repository.Insert(model);
                repository.Save();
            }
            catch (Exception)
            {
                return "An error occured while saving, please check and try again ";
            }

            return string.Empty;
        }
    }
}
