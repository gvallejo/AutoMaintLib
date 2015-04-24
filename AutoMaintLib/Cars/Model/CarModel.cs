using AutoMaintLib.Cars.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Cars.Model
{
    public delegate void OnCarTypeChangedEventHandler(object sender, CarTypeEnum newCarType); 
    public class CarModel
    {
        private CarTypeEnum m_CarType;

        public event OnCarTypeChangedEventHandler OnCarTypeChanged;
        public Manufacturer Make { get; set; }
        public Model Model { get; set; }
        public int Year { get; set; }
        public Trim Trim { get; set; }

        public CarTypeEnum CarType 
        {
            get { return this.m_CarType; }
            set 
            { 
                this.m_CarType = value;
                if (this.OnCarTypeChanged != null)
                    this.OnCarTypeChanged(this, value);
            } 
        }

        
    }
}
