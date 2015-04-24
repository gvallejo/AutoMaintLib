using AutoMaintLib.Maintenance.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Guides.ApplicableTasks
{
    public class FuelEngineMaintenanceTasksFactory : IApplicableMaintenanceTasksFactory
    {
        public MaintenanceTaskCollection CreateApplicableMaintenanceTasksCollection()
        {
            MaintenanceTaskCollection applicableTasks = new MaintenanceTaskCollection();
            applicableTasks.Add(new MaintenanceTask(TaskEnum.FuelLinesInspection));
            applicableTasks.Add(new MaintenanceTask(TaskEnum.OilChange));
            applicableTasks.Add(new MaintenanceTask(TaskEnum.TireRotation));
            applicableTasks.Add(new MaintenanceTask(TaskEnum.WheelAlignment));

            return applicableTasks;
        }
    }
}
