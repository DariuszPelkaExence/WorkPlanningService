using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Extensions.Logging;
using Teamway.WorkPlanningService.Model;
using Teamway.WorkPlanningService.Repository;

namespace Teamway.WorkPlanningService.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly ILogger<ShiftController> _logger;

        private readonly IRepository _repository;

        public ShiftController(ILogger<ShiftController> logger)
        {
            _logger = logger;
        }

        [System.Web.Http.HttpGet]
        public IActionResult Get(int shiftId)
        {
            var shift = _repository.GetShift(shiftId);
            if (shift != null)
            {
                return Ok(shift);
            }
            else
            {
                return NotFound();
            }
        }

        [System.Web.Http.HttpGet]
        public IActionResult GetShiftPerWorker(int workerId)
        {
            var shifst = _repository.GetShiftPerWorker(workerId);
            return Ok(shifst);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Add(Shift shift)
        {
            var worker = _repository.GetWorker(shift.WorkerId);

            if (worker != null)
            {
                var overlappingShiftsExist = _repository.GetShiftsForWorker(shift.WorkerId, shift.Starts, shift.Ends);

                if (!overlappingShiftsExist)
                {
                    var operationStatus = _repository.AddShift(shift);

                    if (operationStatus == AddShiftStatus.Ok)
                    {
                        return Ok();
                    }
                    else
                    {
                        var error = new HttpResponseMessage(HttpStatusCode.BadRequest)
                        {
                            Content = new StringContent("Overlapping shift exists", System.Text.Encoding.UTF8,
                                "text/plain"),
                            StatusCode = HttpStatusCode.NotFound
                        };
                        throw new HttpResponseException(error);
                    }
                }
            }

            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Worker doesn't exist", System.Text.Encoding.UTF8,
                    "text/plain"),
                StatusCode = HttpStatusCode.NotFound
            };
            throw new HttpResponseException(response);

        }

        [System.Web.Http.HttpDelete]
        public IActionResult Remove(int workerId)
        {
            var operationStatus = _repository.RemoveWorker(workerId);

            if (operationStatus == RemoveWorkerStatus.Ok)
            {
                return Ok();
            }
            else
            {
                if (operationStatus == RemoveWorkerStatus.WorkerDoesNotExist)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Worker doesn't exist", System.Text.Encoding.UTF8,
                            "text/plain"),
                        StatusCode = HttpStatusCode.NotFound
                    };
                    throw new HttpResponseException(response);
                }
                else
                {
                    var error = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Worker record could not be removed", System.Text.Encoding.UTF8,
                            "text/plain"),
                        StatusCode = HttpStatusCode.NotFound
                    };
                    throw new HttpResponseException(error);
                }
            }
        }

    }
}
