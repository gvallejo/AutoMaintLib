using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Cars.Model
{
    public class Manufacturer
    {
        public string Name {get;set;}
        public string WebPage { get; set; }
        public List<Model> Models { get; private set; }

        public Manufacturer()
        {
            this.Models = new List<Model>();
        }

        public Manufacturer(string name):this()
        {
            this.Name = name;
        }
    }
}
