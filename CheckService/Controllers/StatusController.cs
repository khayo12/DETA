using CheckService.BL;
using CheckService.Models;
using System;
using System.Web.Http;

namespace CheckService.Controllers
{
    public class StatusController : ApiController
    {
        readonly Status status = new Status();
        // GET: api/Status
        public string Get(string serviceName)
        {
            if(string.IsNullOrEmpty(serviceName))
            {
                throw new Exception("The service name cannot be empty.");
            }
            return status.ServiceStatus(serviceName);
        }

        // POST: api/Status
        public string Post(StatusRequest statusRequest)
        {
            return status.UpdateStatus(statusRequest);
        }
    }
}
