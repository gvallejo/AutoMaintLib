using AutoMaintLib.Core;
using AutoMaintLib.Maintenance.Tasks;
using AutoMaintLib.Maintenance.Tasks.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Tracking
{
    public class MaintenanceLogEntry
    {
        private IMaintenanceTaskValidator m_taskValidator = null;

        public Car CarInfo { get; private set; }
        public MaintenanceTaskCollection MaintenanceTasks { get; private set; }

        public MaintenanceLogEntry(Car carInfo):this(carInfo, null)
        {
           
        }

        public MaintenanceLogEntry(Car carInfo, IMaintenanceTaskValidator taskValidator)
        {
            this.CarInfo = carInfo;
            carInfo.Model.OnCarTypeChanged += Model_OnCarTypeChanged;

            if (taskValidator == null)
                this.m_taskValidator = new CarTypeBasedTaskValidator(carInfo.Model.CarType);
            else
                this.m_taskValidator = taskValidator;
            
            this.MaintenanceTasks = new MaintenanceTaskCollection(this.m_taskValidator);
        }

        void Model_OnCarTypeChanged(object sender, Cars.Types.CarTypeEnum newCarType)
        {
            if (this.m_taskValidator is CarTypeBasedTaskValidator)
                (this.m_taskValidator as CarTypeBasedTaskValidator).CarType = newCarType;
            
            //this.MaintenanceTasks.Validate();
        }

        

        
    }
}
