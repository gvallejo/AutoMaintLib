using AutoMaintLib.Core.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Tasks
{
    public class MaintenanceTask : IValidatable<MaintenanceTask>, IEditableObject, ICloneable
    {
       
        public DateTime TimeStamp {get; set;}
        public TaskEnum TaskType { get;  set; }
        public decimal Rate { get; set; }
        public decimal EstimatedHours { get;  set; }
        public decimal ActualHours { get; set; }

        private MaintenanceTask m_backupData = null;
        private bool m_HasChanges = false;

        public MaintenanceTask(TaskEnum taskType)
        {
            this.TaskType = taskType;
        }

        public MaintenanceTask()
        {
            
        }

        public MaintenanceTask(MaintenanceTask maintenanceTask)
        {
            this.TimeStamp = maintenanceTask.TimeStamp;
            this.TaskType = maintenanceTask.TaskType;
            this.ActualHours = maintenanceTask.ActualHours;
            this.EstimatedHours = maintenanceTask.EstimatedHours;
            this.Rate = maintenanceTask.Rate;            
        }
        

        public override string ToString()
        {
            return this.TaskType.ToString();
        } 

       

        public virtual decimal GetTaskCost()
        {
            return CalculateCost(this.Rate, this.ActualHours);
        }

        public virtual decimal EstimateCost()
        {
            return CalculateCost(this.Rate, this.EstimatedHours);
        }

        private decimal CalculateCost(decimal rate, decimal hours)
        {
            return CalculateLaborCost(rate, hours) + CalculateMaterialCost();
        }

        private decimal CalculateLaborCost(decimal rate, decimal hours)
        {
            return rate * hours;
        }

        private decimal CalculateMaterialCost()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// This Predicates finds a MaintenanceTask by TaskType 
        /// </summary>
        /// <param name="coilCode"></param>
        /// <param name="pipeNum"></param>
        /// <param name="AB"></param>
        /// <returns></returns>
        public static Func<MaintenanceTask, bool> ByTaskType(TaskEnum taskType)
        {
            return delegate(MaintenanceTask maintenanceTask)
            {
                bool result = false;

                try
                {
                    //LogSession.EnterMethod("Range.ByLengthInRange");
                    /*--------- Your code goes here-------*/                    

                    if ((maintenanceTask.TaskType == taskType))
                        result = true;

                    return result;
                    /*------------------------------------*/
                }
                catch (Exception ex)
                {
                    //LogSession.LogException(ex);
                    throw ex;
                }
                finally
                {
                    //LogSession.LeaveMethod("Range.ByLengthInRange");
                }

            };
        }

        public bool IsValid(IValidator<MaintenanceTask> validator, out IEnumerable<string> errors)
        {
            bool result = true;
            errors = null;

            if (validator != null)
            {
                errors = validator.Errors(this);
                result = validator.Validate(this);
            }
            
            return result;
        }


        public bool HasChanges
        {
            get { return this.m_HasChanges; }
            private set { this.m_HasChanges = value; }
        } 

        public void BeginEdit()
        {            
            if (!this.HasChanges)
            {
                this.m_backupData = BackupData();
                this.HasChanges = true;                
            }            
        }

        public void CancelEdit()
        {            
            if (this.HasChanges)
            {
                RestoreData(this.m_backupData);                
                this.HasChanges = false;               
            }          
        }       

        public void EndEdit()
        {                        
            if (this.HasChanges)
            {
                this.m_backupData = new MaintenanceTask();
                this.HasChanges = false;                
            }            
        }

        //public void EndEdit(IValidator<MaintenanceTask> validator)
        //{

        //}

        private MaintenanceTask BackupData()
        {
            return (MaintenanceTask)this.Clone();
        }

        private void RestoreData(MaintenanceTask maintenanceTask)
        {
            this.TimeStamp = maintenanceTask.TimeStamp;
            this.TaskType = maintenanceTask.TaskType;
            this.ActualHours = maintenanceTask.ActualHours;
            this.EstimatedHours = maintenanceTask.EstimatedHours;
            this.Rate = maintenanceTask.Rate;
        }

        public object Clone()
        {
            return new MaintenanceTask(this);
        }
    }
}
