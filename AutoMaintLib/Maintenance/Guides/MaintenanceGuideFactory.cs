using AutoMaintLib.Cars.Model;
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
        public MaintenanceGuide GetMaintenanceGuide(CarModel carModel)
        {
            MaintenanceGuide maintenanceGuide = CreateMaintenanceGuide(carModel);
            maintenanceGuide.AddApplicableTasks();

            return maintenanceGuide;
        }

        protected abstract MaintenanceGuide CreateMaintenanceGuide(CarModel carModel);
       
    }
}
