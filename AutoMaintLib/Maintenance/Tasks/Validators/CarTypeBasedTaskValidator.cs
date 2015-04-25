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
    public class CarTypeBasedTaskValidator: IMaintenanceTaskValidator, IDisposable
    {
        private MaintenanceGuide m_MaintenanceGuide = null;                    
        private MaintenanceGuideFactory m_MaintenanceGuideFactory = null;

        private bool disposed = false;

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
       
        public bool Validate(MaintenanceTask item)
        {
            return Errors(item).Count() < 1;
        }

        public IEnumerable<string> Errors(MaintenanceTask item)
        {            
           
            if (this.m_MaintenanceGuide != null)
            {
                if (this.m_MaintenanceGuide.MaintenanceTasks.FindByTaskType(item.TaskType) == null)
                    yield return string.Format("Maintenance task {0} cannot be performed on a {1} car.", item.ToString(), this.m_MaintenanceGuide.CarModel.CarType.ToString());
            }            

            yield break;
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                Dispose(true);
            }
            catch { }
            GC.SuppressFinalize(this);
        }


        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {


            try
            {               
                /*--------- Your code goes here-------*/
                // Check to see if Dispose has already been called.
                if (!this.disposed)
                {
                    // If disposing equals true, dispose all managed 
                    // and unmanaged resources.
                    if (disposing)
                    {
                        // Free any managed resources in this section
                        // free managed resources   
                        try
                        {
                            if (this.m_MaintenanceGuide != null)
                            {
                                //Unsubscribe from event
                                if(this.m_MaintenanceGuide.CarModel != null)
                                    this.m_MaintenanceGuide.CarModel.OnCarTypeChanged -= this.carModel_OnCarTypeChanged;                                                               
                            }
                        }
                        catch (Exception ex) { //Log exception
                        }
                    }

                    // Call the appropriate methods to clean up 
                    // unmanaged resources here.
                    // If disposing is false, 
                    // only the following code is executed.

                }
                disposed = true;
                /*------------------------------------*/
            }
            catch (Exception ex)
            {               
                throw ex;
            }
            finally
            {
                
            }

        }

        #endregion
    }
}
