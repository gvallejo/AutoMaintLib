using AutoMaintLib.Cars;
using AutoMaintLib.Cars.Model;
using AutoMaintLib.Cars.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Core
{
    public class Car
    {

        private CarModel m_CarModel;      
        private decimal m_Odometer;

        //public Car()
        //{

        //}
        public Car(ref CarModel carModel, string vinNumber)
        {
            this.m_CarModel = carModel;
            this.VIN = vinNumber;
        }


        public string VIN { get; private set; } 

        public CarModel Model
        {
            get { return this.m_CarModel; }
            set { this.m_CarModel = value; }
        }              

        public decimal Odometer
        {
            get { return this.m_Odometer; }
            set { this.m_Odometer = value; }
        }

    }
}
