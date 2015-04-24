using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMaintLib.Maintenance.Tracking;
using AutoMaintLib.Core;
using AutoMaintLib.Cars.Model;
using AutoMaintLib.Maintenance.Tasks;

namespace AutoMaintLibUnitTests.Maintenance
{
    [TestClass]
    public class MaintenanceLogEntryTests
    {
        private MaintenanceLogEntry m_MaintenanceLogEntry = null;
        private Car m_Vehicle = null;
        private CarModel m_CarModel = null;

        public MaintenanceLogEntryTests()
        {
              this.m_CarModel = new CarModel();
              this.m_CarModel.Make = new Manufacturer("Volkswagen");
              this.m_CarModel.Model = new Model("Jetta", this.m_CarModel.Make);
              this.m_CarModel.Year = 2005;
              this.m_CarModel.Trim = new Trim("GLS 4dr Sedan (2.0L 4cyl 4A)");

              this.m_Vehicle = new Car(ref this.m_CarModel, "JM1CW2CL5C0117704");
              this.m_Vehicle.Odometer = 45000m;

              this.m_Vehicle.Model.CarType = AutoMaintLib.Cars.Types.CarTypeEnum.Gasoline;
              this.m_MaintenanceLogEntry = new MaintenanceLogEntry(this.m_Vehicle);
        }

         //Use TestInitialize to run code before running each test 
         [TestInitialize()]
         public void MyTestInitialize() 
         {
                     
            
         }
        

        // Use TestCleanup to run code after each test has run
         [TestCleanup()]
         public void MyTestCleanup() 
         {
             this.m_MaintenanceLogEntry.MaintenanceTasks.Clear();
         }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]        
        public void Add_WhenMaintenanceTask_NotApplicableTo_Gasoline_Car_ShouldThrowInvalidOperation()
        {
            this.m_Vehicle.Model.CarType = AutoMaintLib.Cars.Types.CarTypeEnum.Gasoline;
           
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.EVBatteryChange));
            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_WhenMaintenanceTask_NotApplicableTo_Diesel_Car_ShouldThrowInvalidOperation()
        {
            this.m_Vehicle.Model.CarType = AutoMaintLib.Cars.Types.CarTypeEnum.Diesel;

           
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.EVBatteryChange));

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_When_OilChange_NotApplicableTo_Electric_Car_ShouldThrowInvalidOperation()
        {
            this.m_Vehicle.Model.CarType = AutoMaintLib.Cars.Types.CarTypeEnum.Electric;

           
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.OilChange));

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_When_FuelLinesInspection_NotApplicableTo_Electric_Car_ShouldThrowInvalidOperation()
        {
            this.m_Vehicle.Model.CarType = AutoMaintLib.Cars.Types.CarTypeEnum.Electric;

            
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.FuelLinesInspection));

        }


        [TestMethod]                
        public void Edit_When_MaintTask_NotApplicableTo_CarType_ShouldThrowInvalidOperation()
        {            
            
            this.m_Vehicle.Model.CarType = AutoMaintLib.Cars.Types.CarTypeEnum.Diesel;

            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.FuelLinesInspection));
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.OilChange));
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.TireRotation));
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.WheelAlignment));
            try
            {
                this.m_MaintenanceLogEntry.MaintenanceTasks[2].ActualHours = 10;
                this.m_MaintenanceLogEntry.MaintenanceTasks[2].TimeStamp = DateTime.Now;
                this.m_MaintenanceLogEntry.MaintenanceTasks[2].TaskType = TaskEnum.EVBatteryChange;

                this.m_MaintenanceLogEntry.MaintenanceTasks.Validate();
               
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, AutoMaintLib.Cars.Types.CarTypeEnum.Diesel.ToString());
                return;
            }

            Assert.Fail("No exception thrown");
        }


        [TestMethod]        
        public void When_ChangingCarType_AndTasksNotApplicableTo_ElectricCar_ShouldThrowInvalidOperation()
        {
            this.m_Vehicle.Model.CarType = AutoMaintLib.Cars.Types.CarTypeEnum.Diesel;

           
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.FuelLinesInspection));
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.OilChange));
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.TireRotation));
            this.m_MaintenanceLogEntry.MaintenanceTasks.Add(new MaintenanceTask(TaskEnum.WheelAlignment));

            
            try
            {
                this.m_Vehicle.Model.CarType = AutoMaintLib.Cars.Types.CarTypeEnum.Electric;
                this.m_MaintenanceLogEntry.MaintenanceTasks.Validate();
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, AutoMaintLib.Cars.Types.CarTypeEnum.Electric.ToString());
                return;
            }

            Assert.Fail("No exception thrown");
        }

        
        
    }
}
