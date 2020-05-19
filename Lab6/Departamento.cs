using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    public class Departamento : Area

    {

        public Departamento(Persona inCharge) : base(inCharge)
        {
            this.Name = "Departamento";
            this.InCharge = inCharge;
        }

    }
}
