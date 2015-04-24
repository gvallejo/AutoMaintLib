using AutoMaintLib.Cars.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Guides
{
    public abstract class MaintenanceGuideFactory
    {
        public MaintenanceGuide GetMaintenanceGuide(CarTypeEnum carType)
        {
            MaintenanceGuide maintenanceGuide = CreateMaintenanceGuide(carType);
            maintenanceGuide.AddApplicableTasks();

            return maintenanceGuide;
        }

        protected abstract MaintenanceGuide CreateMaintenanceGuide(CarTypeEnum carType);
       
    }
}
