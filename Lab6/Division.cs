using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    public class Division
    {
        List<Persona> personas = new List<Persona>();
        string name;
        Persona inCharge;
        public string Name { get => name; set => name = value; }
        public Persona InCharge { get => inCharge; set => inCharge = value; }
        public List<Persona> Personas { get => personas; set => personas = value; }
    }
}
