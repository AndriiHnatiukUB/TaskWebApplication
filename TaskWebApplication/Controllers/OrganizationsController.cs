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
    public class OrganizationsController : ApiController
    {
        private IRepository<Organization> _orgRepository;
        private IRepository<ActivityType> _activityRepository;

        public OrganizationsController(IRepository<Organization> repository, IRepository<ActivityType> activityRepository)
        {
            _orgRepository = repository;
            _activityRepository = activityRepository;
        }

        // GET api/<controller>
        public IEnumerable<OrganizationViewModel> Get()
        {            
            List<OrganizationViewModel> organizationViewModels = new List<OrganizationViewModel>();
            //var result = _orgRepository.Organizations.Select(model => new
            //{
            //    model.Id,
            //    model.Name,
            //    model.Account,
            //    Activity = model.ActivityType.Name,
            //    ActivityId = model.ActivityType.Id
            //}).ToList();

            var organizations = _orgRepository.Get;
            var activities = _activityRepository.Get;
            foreach (var organization in organizations)
            {
                var activity = activities.FirstOrDefault(a => a.Id == organization.ActivityTypeId);
                var organizationViewModel = new OrganizationViewModel
                {
                    Id = organization.Id,
                    Name = organization.Name,
                    Account = organization.Account,
                    Activity = activity.Name,
                    ActivityTypeId = activity.Id
                };
                organizationViewModels.Add(organizationViewModel);
            }

            return organizationViewModels;
        }

        // GET api/<controller>/5
        public OrganizationViewModel Get(int id)
        {
            Organization org = _orgRepository.GetById(id);
            return new OrganizationViewModel { Id = org.Id, Name = org.Name, Account = org.Account, Activity = org.ActivityType.Name, ActivityTypeId = org.ActivityType.Id };
        }

        // POST api/<controller>
        public void Post(Organization organization)
        {
            _orgRepository.Create(organization);
        }

        // PUT api/<controller>/5
        public void Put(Organization organization)
        {
            _orgRepository.Update(organization);
        }

        // DELETE api/<controller>/5
        public void Delete(Organization organization)
        {
            _orgRepository.Remove(organization);
        }
    }
}