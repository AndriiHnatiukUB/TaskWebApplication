using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskWebApplication.Infrastructure.Abstract;
using TaskWebApplication.Models;

namespace TaskWebApplication.Controllers
{
    public class ActivityTypeController : ApiController
    {
        private IActivityTypeRepository _repository;

        public ActivityTypeController(IActivityTypeRepository repository)
        {
            _repository = repository;
        }

        // GET api/<controller>
        public IEnumerable<ActivityType> Get()
        {
            return _repository.ActivityTypes.ToList();
        }

        // GET api/<controller>/5
        public ActivityType Get(int id)
        {
            ActivityType at = _repository.GetById(id);
            return at;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}