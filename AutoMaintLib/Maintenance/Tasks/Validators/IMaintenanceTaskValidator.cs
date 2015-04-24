using AutoMaintLib.Maintenance.Guides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Tasks.Validators
{
    public interface IMaintenanceTaskValidator
    {
        MaintenanceTask TaskToValidate { get; set; }

        void Validate();        
    }
}
