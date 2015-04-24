using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Tasks
{
    public class MaintenanceTask
    {
       
        public DateTime TimeStamp {get; set;}
        public TaskEnum TaskType { get;  set; }
        public decimal Rate { get; set; }
        public decimal EstimatedHours { get;  set; }
        public decimal ActualHours { get; set; }

        public MaintenanceTask(TaskEnum taskType)
        {
            this.TaskType = taskType;
        }

        public MaintenanceTask()
        {

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
    }
}
