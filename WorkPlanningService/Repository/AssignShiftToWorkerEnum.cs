using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teamway.WorkPlanningService.Repository
{
    public enum AssignShiftToWorkerEnum
    {
        Ok = 0,
        ShiftDoesNotExist = 1,
        WorkerDoesNotExist = 2
    }
}
