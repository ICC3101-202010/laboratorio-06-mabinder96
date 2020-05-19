using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    public class Seccion : Departamento

    {

        public Seccion(Persona inCharge) : base(inCharge)
        {
            this.Name = "Seccion";
            this.InCharge = inCharge;
        }

    }
}
