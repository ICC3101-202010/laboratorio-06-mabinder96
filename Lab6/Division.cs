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
        List<Departamento> departamentos = new List<Departamento>();
        List<Seccion> secciones = new List<Seccion>();
        List<Bloque> bloques = new List<Bloque>();


        public string Name { get => name; set => name = value; }
        public Persona InCharge { get => inCharge; set => inCharge = value; }
        public List<Persona> Personas { get => personas; set => personas = value; }
        public List<Departamento> Departamentos { get => departamentos; set => departamentos = value; }
        public List<Seccion> Secciones { get => secciones; set => secciones = value; }
        public List<Bloque> Bloques { get => bloques; set => bloques = value; }



    }
}
