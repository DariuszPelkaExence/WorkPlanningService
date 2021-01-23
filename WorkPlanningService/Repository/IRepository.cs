using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teamway.WorkPlanningService.Model;

namespace Teamway.WorkPlanningService.Repository
{
    public interface IRepository
    {
        AddShiftStatus AddShift(Shift shift);

        IList<Shift> GetShiftPerWorker(int workerId);

        Shift GetShift(int shiftId);

        RemoveShiftStatus RemoveShift(int shiftId);

        AddWorkerStatus AddWorker(Worker worker);

        RemoveWorkerStatus RemoveWorker(int workerId);

        AssignShiftToWorkerEnum AssignShiftToWorker(int shiftId, int workerId);
    }
}
