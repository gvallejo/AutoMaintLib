using AutoMaintLib.Cars.Model;
using AutoMaintLib.Cars.Types;
using AutoMaintLib.Maintenance.Guides.ApplicableTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Guides
{
    public class CarTypeBasedMaintenanceGuideFactory : MaintenanceGuideFactory
    {

       
        protected override MaintenanceGuide CreateMaintenanceGuide(CarModel carModel)
        {
            MaintenanceGuide maintenanceGuide = null;
            IApplicableMaintenanceTasksFactory applicableMaintenanceTasksFactory = null;            

            switch (carModel.CarType)
            {
                case CarTypeEnum.Gasoline:
                    applicableMaintenanceTasksFactory = new FuelEngineMaintenanceTasksFactory();
                    maintenanceGuide = new GasMaintenanceGuide(applicableMaintenanceTasksFactory);
                    break;
                case CarTypeEnum.Diesel:
                    applicableMaintenanceTasksFactory = new FuelEngineMaintenanceTasksFactory();
                    maintenanceGuide = new DieselMaintenanceGuide(applicableMaintenanceTasksFactory);
                    break;
                case CarTypeEnum.Electric:
                    applicableMaintenanceTasksFactory = new ElectricCarMaintenanceTasksFactory();
                    maintenanceGuide = new ElectricMaintenanceGuide(applicableMaintenanceTasksFactory);
                    break;
                case CarTypeEnum.Hybrid:
                    break;
                default:
                    break;
            }

            return maintenanceGuide;
        }
    }
}
