using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    public class Bloque : Seccion

    {
        public Bloque(Persona inCharge, List<Persona> personas) : base(inCharge)
        {
            this.Name = "Bloque";
            this.InCharge = inCharge;
            this.Personas = personas;
        }
    }
}
