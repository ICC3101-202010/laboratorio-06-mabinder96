using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    public class Empresa
    {
        List<Division> divisiones = new List<Division>();
        string name;
        int rut;

        public Empresa(string name, int rut)
        {
            this.name = name;
            this.rut = rut;
        }
        

        public string Name { get => name; set => name = value; }
        public int Rut { get => rut; set => rut = value; }
        public List<Division> Divisiones { get => divisiones; set => divisiones = value; }
    }
}
