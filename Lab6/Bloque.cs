using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    public class Bloque : Division

    {

        public Bloque(string name, Persona inCharge, List<Persona> personas)
        {
            this.Name = "Bloque";
            this.InCharge = inCharge;
            this.Personas= personas;
        }

    }
}
