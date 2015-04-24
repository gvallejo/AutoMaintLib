﻿using AutoMaintLib.Cars.Model;
using AutoMaintLib.Maintenance.Guides.ApplicableTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Guides
{
    public class DieselMaintenanceGuide : MaintenanceGuide
    {
        private IApplicableMaintenanceTasksFactory m_ApplicableMaintenanceTasksFactory = null;

        public DieselMaintenanceGuide(IApplicableMaintenanceTasksFactory applicableMaintenanceTasksFactory)            
        {
            this.CarModel = new CarModel();
            this.CarModel.CarType = Cars.Types.CarTypeEnum.Diesel;
            this.m_ApplicableMaintenanceTasksFactory = applicableMaintenanceTasksFactory;
        }

        public override void AddApplicableTasks()
        {
            this.MaintenanceTasks = this.m_ApplicableMaintenanceTasksFactory.CreateApplicableMaintenanceTasksCollection();
        }
    }
}
