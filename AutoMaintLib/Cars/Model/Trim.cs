using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Cars.Model
{
    public class Trim
    {
        public string Name { get; set; }
        
        public Trim()
        {

        }

        public Trim(string name)
        {
            this.Name = name;
        }
    }
}
