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
    public class MaintenanceLogEntry: IDisposable
    {
        private IMaintenanceTaskValidator m_taskValidator = null;
        private bool disposed = false;

        public Car CarInfo { get; private set; }
        public MaintenanceTaskCollection MaintenanceTasks { get; private set; }

        public MaintenanceLogEntry(Car carInfo):this(carInfo, null)
        {
           
        }

        public MaintenanceLogEntry(Car carInfo, IMaintenanceTaskValidator taskValidator)
        {
            this.CarInfo = carInfo;
           

            if (taskValidator == null)
                this.m_taskValidator = new CarTypeBasedTaskValidator(carInfo.Model);
            else
                this.m_taskValidator = taskValidator;
            
            this.MaintenanceTasks = new MaintenanceTaskCollection(this.m_taskValidator);
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
                            if (this.m_taskValidator != null)
                            {
                                //Unsubscribe from event
                                if (this.m_taskValidator is IDisposable)
                                    (this.m_taskValidator as IDisposable).Dispose();
                            }
                        }
                        catch (Exception ex)
                        { //Log exception
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
