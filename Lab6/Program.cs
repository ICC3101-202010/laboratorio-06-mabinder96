using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;
using System.Net.NetworkInformation;

namespace Lab6
{
    class Program
    {
        static private void SaveEmpresa(List<Empresa> empresas)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, empresas);
            stream.Close();
        }
        static private List<Empresa> LoadEmpresa()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Empresa> empresas = (List<Empresa>)formatter.Deserialize(stream);
            stream.Close();
            return empresas;
        }
        static void Main(string[] args)
        {
            List<Empresa> empresas = new List<Empresa>();
            Persona personal;
            Persona persona;
            Departamento departamento;
            Empresa newempresa;
            Area area;
            Seccion seccion;
            List<Persona> personales;
            Bloque bloque;
            string name;
            string lastname;
            int rut;
            string position;

            string switcher = "0";
            string stopper = "3";


            while (switcher != stopper)
            {
                Console.WriteLine("-----------------------------------------Bienvenidos-----------------------------------------");
                Console.WriteLine("Si desea:\n\t(1) Utilizar un archivo para cargar la información de la empresa\n\t(2) No utilizar un archivo para cargar la información de la empresa\n\t(3) Salir del programa\n");
                switcher = Console.ReadLine();
                Console.Clear();
                switch (switcher)
                {               
                    case "1":
                        string archivoempresa = @"\empresa.bin";
                        string pathu = Directory.GetCurrentDirectory() + archivoempresa;
                        try
                        {
                            empresas = LoadEmpresa();
                            int ne = 1;
                            foreach (Empresa e in empresas)
                            {
                                Console.WriteLine($"-----------------------------------------EMPRESA {ne}-----------------------------------------");
                                Console.WriteLine($"Nombre empresa: {e.Name}\nRut empresa: {e.Rut}\n\n\n");
                                int nb = 1;
                                foreach (Division d in e.Divisiones)
                                {
                                    if (d.Name == "Bloque")
                                    {
                                        int nem = 1;
                                        Console.WriteLine($"Nombre división: {d.Name} {nb}\nNombre encargado: {d.InCharge.Name} {d.InCharge.Lastname}\n");
                                        foreach (Persona p in d.Personas)
                                        {
                                            Console.WriteLine($"Nombre empleado {nem}: {p.Name}\nApellido empleado: {p.Lastname}\nRut empleado: {p.Rut}\nCargo empleado: {p.Position}\n");
                                            nem++;
                                        }
                                        Console.WriteLine("");
                                        Console.WriteLine("");


                                        nb++;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nombre división: {d.Name}\nNombre encargado: {d.InCharge.Name} {d.InCharge.Lastname}\n");
                                        Console.WriteLine("");
                                        Console.WriteLine("");


                                    }
                                }
                                Console.ReadKey();
                                Console.Clear();
                                ne++;
                            }

                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("------------------------------------No se ha encontrado el archivo de la empresa------------------------------------ ");
                            Console.WriteLine("Ingrese el nombre de la empresa:");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut de la empresa (Sin puntos ni guiones):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            newempresa = new Empresa(name, rut);
                            Thread.Sleep(1000);
                            Console.Clear();

                            Console.WriteLine("Ingrese el nombre del encargado de departamento: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del encargado de departamento: ");
                            lastname = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del encargado de departamento (Sin guiones ni puntos. Reemplace la k por un 0):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido:");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException )
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            position = "Jefe departamento";
                            persona = new Persona(name, lastname, rut, position);
                            departamento = new Departamento("Departamento", persona);
                            newempresa.Divisiones.Add(departamento);
                            Thread.Sleep(1000);
                            Console.Clear();

                            Console.WriteLine("Ingrese el nombre del encargado de área: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del encargado de área: ");
                            lastname = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del encargado de área (Sin guiones ni puntos. Reemplace la k por un 0):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido:");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            position = "Jefe área";
                            persona = new Persona(name, lastname, rut, position);
                            area = new Area("Area", persona);
                            newempresa.Divisiones.Add(area);
                            Thread.Sleep(1000);
                            Console.Clear();

                            Console.WriteLine("Ingrese el nombre del encargado de sección: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del encargado de sección: ");
                            lastname = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del encargado de sección (Sin guiones ni puntos. Reemplace la k por un 0):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido:");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            position = "Jefe sección";
                            persona = new Persona(name, lastname, rut, position);
                            seccion = new Seccion("Seccion", persona);
                            newempresa.Divisiones.Add(seccion);
                            Thread.Sleep(1000);
                            Console.Clear();

                            Console.WriteLine("Ingrese el nombre del encargado de bloque 1: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del encargado de bloque 1: ");
                            lastname = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del encargado de bloque 1 (Sin guiones ni puntos. Reemplace la k por un 0):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido:");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            position = "Jefe bloque 1";

                            persona = new Persona(name, lastname, rut, position);

                            personales = new List<Persona>();
                            Console.WriteLine("");

                            Console.WriteLine("Ingrese el nombre del personal 1:");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del personal 1:");
                            lastname = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del personal 1 (Sin guiones ni puntos. Reemplace la k por un 0):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido:");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            Console.WriteLine("Ingrese el cargo del personal 1:");
                            position = Console.ReadLine();

                            personal = new Persona(name, lastname, rut, position);
                            personales.Add(personal);
                            Console.WriteLine("");


                            Console.WriteLine("Ingrese el nombre del personal 2:");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del personal 2:");
                            lastname = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del personal 2 (Sin guiones ni puntos. Reemplace la k por un 0):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido:");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            Console.WriteLine("Ingrese el cargo del personal 2:");
                            position = Console.ReadLine();

                            personal = new Persona(name, lastname, rut, position);
                            personales.Add(personal);

                            bloque = new Bloque("Seccion", persona, personales);
                            newempresa.Divisiones.Add(bloque);
                            Thread.Sleep(1000);
                            Console.Clear();

                            Console.WriteLine("Ingrese el nombre del encargado de bloque 2: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del encargado de bloque 2: ");
                            lastname = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del encargado de bloque 2 (Sin guiones ni puntos. Reemplace la k por un 0):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido:");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            position = "Jefe bloque 2";

                            persona = new Persona(name, lastname, rut, position);
                            Console.WriteLine("");


                            personales = new List<Persona>();

                            Console.WriteLine("Ingrese el nombre del personal 1:");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del personal 1:");
                            lastname = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del personal 1 (Sin guiones ni puntos. Reemplace la k por un 0):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido:");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            Console.WriteLine("Ingrese el cargo del personal 1:");
                            position = Console.ReadLine();

                            personal = new Persona(name, lastname, rut, position);
                            personales.Add(personal);
                            Console.WriteLine("");

                            Console.WriteLine("Ingrese el nombre del personal 2:");
                            name = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido del personal 2:");
                            lastname = Console.ReadLine();
                            Console.WriteLine("Ingrese el rut del personal 2 (Sin guiones ni puntos. Reemplace la k por un 0):");
                            rut = -1;
                            while (rut == -1)
                            {
                                try
                                {
                                    rut = int.Parse(Console.ReadLine());
                                    if (rut < 1)
                                    {
                                        Console.WriteLine("Ingrese un rut válido:");
                                        rut = -1;
                                    }


                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                                }
                            }
                            Console.WriteLine("Ingrese el cargo del personal 2:");
                            position = Console.ReadLine();

                            personal = new Persona(name, lastname, rut, position);
                            personales.Add(personal);

                            bloque = new Bloque("Seccion", persona, personales);
                            newempresa.Divisiones.Add(bloque);

                            empresas.Add(newempresa);
                            SaveEmpresa(empresas);
                            empresas = new List<Empresa>();
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        
                        break;

                    case "2":
                        Console.WriteLine("Ingrese el nombre de la empresa:");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut de la empresa (Sin puntos ni guiones):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        newempresa = new Empresa(name, rut);
                        Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Ingrese el nombre del encargado de departamento: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del encargado de departamento: ");
                        lastname = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut del encargado de departamento (Sin guiones ni puntos. Reemplace la k por un 0):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido:");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        position = "Jefe departamento";
                        persona = new Persona(name, lastname, rut, position);
                        departamento = new Departamento("Departamento", persona);
                        newempresa.Divisiones.Add(departamento);
                        Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Ingrese el nombre del encargado de área: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del encargado de área: ");
                        lastname = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut del encargado de área (Sin guiones ni puntos. Reemplace la k por un 0):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido:");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        position = "Jefe área";
                        persona = new Persona(name, lastname, rut, position);
                        area = new Area("Area", persona);
                        newempresa.Divisiones.Add(area);
                        Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Ingrese el nombre del encargado de sección: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del encargado de sección: ");
                        lastname = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut del encargado de sección (Sin guiones ni puntos. Reemplace la k por un 0):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido:");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        position = "Jefe sección";
                        persona = new Persona(name, lastname, rut, position);
                        seccion = new Seccion("Seccion", persona);
                        newempresa.Divisiones.Add(seccion);
                        Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Ingrese el nombre del encargado de bloque 1: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del encargado de bloque 1: ");
                        lastname = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut del encargado de bloque 1 (Sin guiones ni puntos. Reemplace la k por un 0):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido:");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        position = "Jefe bloque 1";

                        persona = new Persona(name, lastname, rut, position);

                        personales = new List<Persona>();
                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el nombre del personal 1:");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del personal 1:");
                        lastname = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut del personal 1 (Sin guiones ni puntos. Reemplace la k por un 0):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido:");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        Console.WriteLine("Ingrese el cargo del personal 1:");
                        position = Console.ReadLine();

                        personal = new Persona(name, lastname, rut, position);
                        personales.Add(personal);
                        Console.WriteLine("");


                        Console.WriteLine("Ingrese el nombre del personal 2:");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del personal 2:");
                        lastname = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut del personal 2 (Sin guiones ni puntos. Reemplace la k por un 0):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido:");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        Console.WriteLine("Ingrese el cargo del personal 2:");
                        position = Console.ReadLine();

                        personal = new Persona(name, lastname, rut, position);
                        personales.Add(personal);

                        bloque = new Bloque("Seccion", persona, personales);
                        newempresa.Divisiones.Add(bloque);
                        Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Ingrese el nombre del encargado de bloque 2: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del encargado de bloque 2: ");
                        lastname = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut del encargado de bloque 2 (Sin guiones ni puntos. Reemplace la k por un 0):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido:");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        position = "Jefe bloque 2";

                        persona = new Persona(name, lastname, rut, position);
                        Console.WriteLine("");


                        personales = new List<Persona>();

                        Console.WriteLine("Ingrese el nombre del personal 1:");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del personal 1:");
                        lastname = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut del personal 1 (Sin guiones ni puntos. Reemplace la k por un 0):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido:");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        Console.WriteLine("Ingrese el cargo del personal 1:");
                        position = Console.ReadLine();

                        personal = new Persona(name, lastname, rut, position);
                        personales.Add(personal);
                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el nombre del personal 2:");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del personal 2:");
                        lastname = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut del personal 2 (Sin guiones ni puntos. Reemplace la k por un 0):");
                        rut = -1;
                        while (rut == -1)
                        {
                            try
                            {
                                rut = int.Parse(Console.ReadLine());
                                if (rut < 1)
                                {
                                    Console.WriteLine("Ingrese un rut válido:");
                                    rut = -1;
                                }


                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un numero como rut:");

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Formato invalido\nIngrese un rut de menos dígitos:");

                            }
                        }
                        Console.WriteLine("Ingrese el cargo del personal 2:");
                        position = Console.ReadLine();

                        personal = new Persona(name, lastname, rut, position);
                        personales.Add(personal);

                        bloque = new Bloque("Seccion", persona, personales);
                        newempresa.Divisiones.Add(bloque);

                        empresas.Add(newempresa);
                        SaveEmpresa(empresas);
                        empresas = new List<Empresa>();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;

                    case "3":
                        if (empresas.Count() != 0)
                        {
                            SaveEmpresa(empresas);
                            Thread.Sleep(1000);
                        }
                        switcher = "3";
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("Ingrese una opción valida\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }

}


            