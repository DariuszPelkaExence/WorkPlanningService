using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teamway.WorkPlanningService.Model;

namespace Teamway.WorkPlanningService.Repository
{
    public interface IRepository
    {
        bool GetShiftsForWorker(int workerId, DateTime from, DateTime to);

        AddShiftStatus AddShift(Shift shift);

        IList<Shift> GetShiftPerWorker(int workerId);

        Shift GetShift(int shiftId);

        Worker GetWorker(int workerId);

        RemoveShiftStatus RemoveShift(int shiftId);

        AddWorkerStatus AddWorker(Worker worker);

        RemoveWorkerStatus RemoveWorker(int workerId);

        AssignShiftToWorkerEnum AssignShiftToWorker(int shiftId, int workerId);
    }
}
