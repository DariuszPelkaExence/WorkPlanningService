﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Teamway.WorkPlanningService.Repository
{
    public enum RemoveShiftStatus
    {
        Ok = 0,
        RecordDoesNotExist = 1    
    }
}
