using AutoMaintLib.Cars.Model;
using AutoMaintLib.Cars.Types;
using AutoMaintLib.Maintenance.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Guides.ApplicableTasks
{
    public interface IApplicableMaintenanceTasksFactory
    {
        MaintenanceTaskCollection CreateApplicableMaintenanceTasksCollection();        
    }
}
