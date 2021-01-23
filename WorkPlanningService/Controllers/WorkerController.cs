using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Teamway.WorkPlanningService.Model;
using Teamway.WorkPlanningService.Repo;

namespace Teamway.WorkPlanningService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly ILogger<WorkerController> _logger;
        private readonly IRepository _repository;

        public WorkerController(ILogger<WorkerController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public HttpStatusCode Add(Worker worker)
        {
            var operationStatus = _repository.AddWorker(worker);

            if (operationStatus == AddWorkerStatus.Ok)
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }

        [HttpDelete]
        public HttpStatusCode Remove(int workerId)
        {
            var operationStatus = _repository.RemoveWorker(workerId);

            if (operationStatus == RemoveWorkerStatus.Ok)
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
