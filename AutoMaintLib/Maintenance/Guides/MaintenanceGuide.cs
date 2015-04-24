using AutoMaintLib.Cars;
using AutoMaintLib.Cars.Model;
using AutoMaintLib.Core;
using AutoMaintLib.Maintenance.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Guides
{
    public abstract class MaintenanceGuide
    {        
        public CarModel CarModel { get; protected set; }
        public MaintenanceTaskCollection MaintenanceTasks { get; protected set; }

       
        public abstract void AddApplicableTasks();
       
       
    }
}
