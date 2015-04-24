using AutoMaintLib.Cars.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Cars.Model
{
    public class Model
    {
        public Manufacturer Make {get; private set;}
        public string Name { get; private set; }
        public List<int> YearList { get; private set; }

        public Model()
        {            
            this.YearList = new List<int>();
        }

        public Model(string name):this()
        {
            this.Name = name;
        }

        public Model(string name, Manufacturer make):this(name)           
        {
            this.Make = make;
        }
       
    }
}
