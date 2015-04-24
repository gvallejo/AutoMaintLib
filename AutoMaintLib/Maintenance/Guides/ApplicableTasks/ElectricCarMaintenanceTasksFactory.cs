using AutoMaintLib.Maintenance.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Guides.ApplicableTasks
{
    class ElectricCarMaintenanceTasksFactory : IApplicableMaintenanceTasksFactory
    {
        public MaintenanceTaskCollection CreateApplicableMaintenanceTasksCollection()
        {
            MaintenanceTaskCollection applicableTasks = new MaintenanceTaskCollection();
            applicableTasks.Add(new MaintenanceTask(TaskEnum.EVBatteryChange));
            applicableTasks.Add(new MaintenanceTask(TaskEnum.TireRotation));
            applicableTasks.Add(new MaintenanceTask(TaskEnum.WheelAlignment));

            return applicableTasks;
        }
    }
}
