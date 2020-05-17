using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    public class Persona
    {
        string name;
        string lastname;
        int rut;
        string position;

        public Persona(string name, string lastname, int rut, string position)
        {
            this.Name = name;
            this.Lastname = lastname;
            this.Rut = rut;
            this.Position = position;
        }

        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public int Rut { get => rut; set => rut = value; }
        public string Position { get => position; set => position = value; }
    }
}
