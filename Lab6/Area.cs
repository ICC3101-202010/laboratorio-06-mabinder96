using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    public class Area : Division

    {
        public Area(string name, Persona inCharge) 
        {
            this.Name = "Area";
            this.InCharge = inCharge;
        }
    }
}
