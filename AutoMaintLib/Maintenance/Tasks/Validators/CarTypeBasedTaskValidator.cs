using AutoMaintLib.Cars.Types;
using AutoMaintLib.Maintenance.Guides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Tasks.Validators
{
    public class CarTypeBasedTaskValidator: IMaintenanceTaskValidator
    {
        private MaintenanceGuide m_MaintenanceGuide = null;
        private MaintenanceTask m_TaskToValidate = null;
        private CarTypeEnum m_CarType;
        private CarTypeBasedMaintenanceGuideFactory m_MaintenanceGuideFactory = null;

        public CarTypeBasedTaskValidator(CarTypeEnum carType)
        {
            this.m_MaintenanceGuideFactory = new CarTypeBasedMaintenanceGuideFactory();
            this.CarType = carType;                                
        }

        public CarTypeEnum CarType
        {
            get { return this.m_CarType; }
            set 
            { 
                this.m_CarType = value;
                this.m_MaintenanceGuide = this.m_MaintenanceGuideFactory.GetMaintenanceGuide(value);
            }
        }

        public MaintenanceTask TaskToValidate
        {
            get { return this.m_TaskToValidate; }
            set { this.m_TaskToValidate = value; }
        }

        public void Validate()
        {
            if(this.m_MaintenanceGuide != null)
            {
                if (this.m_MaintenanceGuide.MaintenanceTasks.FindByTaskType(this.TaskToValidate.TaskType) == null)
                    throw new InvalidOperationException (string.Format("Maintenance task {0} cannot be performed on a {1} car.", this.TaskToValidate.ToString(), this.m_MaintenanceGuide.CarModel.CarType.ToString()));
            }
        }
    }
}
