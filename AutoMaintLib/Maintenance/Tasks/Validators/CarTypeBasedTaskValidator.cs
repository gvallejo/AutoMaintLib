using AutoMaintLib.Cars.Model;
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
        private MaintenanceGuideFactory m_MaintenanceGuideFactory = null;

        public CarTypeBasedTaskValidator(CarModel carModel)
        {
            this.m_MaintenanceGuideFactory = new CarTypeBasedMaintenanceGuideFactory();            
            SetMaintenanceGuide(carModel);
            carModel.OnCarTypeChanged += carModel_OnCarTypeChanged;                                           
        }

        void carModel_OnCarTypeChanged(object sender, CarTypeEnum newCarType)
        {
            CarModel carModel = (CarModel)sender;
            SetMaintenanceGuide(carModel);
        }

        private void SetMaintenanceGuide(CarModel carModel)
        {
            this.m_MaintenanceGuide = this.m_MaintenanceGuideFactory.GetMaintenanceGuide(carModel);
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
