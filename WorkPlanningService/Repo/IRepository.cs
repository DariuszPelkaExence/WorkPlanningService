﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teamway.WorkPlanningService.Model;

namespace Teamway.WorkPlanningService.Repo
{
    public interface IRepository
    {
        bool WorkerHasSameOrPreviousOrNextShift(int workerId, DateTime day, ShiftType type);

        AddShiftStatus AddShift(Shift shift);

        IList<Shift> GetShiftsPerWorker(int workerId);

        Shift GetShift(int shiftId);

        Worker GetWorker(int workerId);

        RemoveShiftStatus RemoveShift(int shiftId);

        AddWorkerStatus AddWorker(Worker worker);

        RemoveWorkerStatus RemoveWorker(int workerId);

        AssignShiftToWorkerEnum AssignShiftToWorker(int shiftId, int workerId);
    }
}
