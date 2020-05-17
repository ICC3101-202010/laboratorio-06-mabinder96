using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    public class Seccion : Division

    {
        public Seccion(string name, Persona inCharge)
        {
            this.Name = "Seccion";
            this.InCharge = inCharge;
        }
    }
}
