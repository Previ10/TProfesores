using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Comision_B
{
    internal class Program
    {
        static List<Profesor> profes = new List<Profesor>(); // Lista para almacenar profesores

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Programa profesores. Seleccione la opción:");
                Console.WriteLine("1. Agregar Profesores");
                Console.WriteLine("2. Mostrar Lista Profesores");
                Console.WriteLine("3. Buscar Profesores");
                Console.WriteLine("4. Actualizar Listado Profesores");
                Console.WriteLine("5. Eliminar Profesor");
                Console.WriteLine("6. Salir");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AgregarProfe();
                        break;

                    case "2":
                        MostrarProfesores();
                        break;

                    case "3":
                        BuscarProfesor();
                        break;

                    case "4":
                        ActualizarProfesor();
                        break;

                    case "5":
                        EliminarProfesor();
                        break;

                    case "6":
                        Environment.Exit(0); // Salir del programa
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }

        static void AgregarProfe()
        {
            Console.Write("Por favor ingrese el ID completo del profesor: ");
            Console.Write("Por favor ingrese el ID completo del profesor: ");
            string idStr = Console.ReadLine();

            int id;
            if (int.TryParse(idStr, out id))
            {
                
            }
            else
            {
                Console.WriteLine("ID no válido. No se ha creado el profesor.");
                return;
            }

            Console.Write("Por favor ingrese el nombre del profesor: ");
            string nombre = Console.ReadLine();

            Console.Write("Por favor ingrese el apellido del profesor: ");
            string apellido = Console.ReadLine();

            Console.Write("Por favor ingrese el DNI del profesor: ");
            string dni = Console.ReadLine();

            Console.Write("Por favor ingrese el CUIL del profesor: ");
            string cuil = Console.ReadLine();

            Console.Write("Por favor ingrese el cargo del profesor: ");
            string cargo = Console.ReadLine();

            Console.Write("Por favor ingrese el legajo del profesor: ");
            int legajo;
            if (!int.TryParse(Console.ReadLine(), out legajo))
            {
                Console.WriteLine("Legajo no válido. No se ha creado el profesor.");
                return;
            }

            Console.Write("Por favor ingrese la obra social del profesor: ");
            string obraSocial = Console.ReadLine();

            Console.Write("Por favor ingrese el sueldo bruto del profesor: ");
            float sueldoBruto;
            if (!float.TryParse(Console.ReadLine(), out sueldoBruto))
            {
                Console.WriteLine("Sueldo bruto no válido. No se ha creado el profesor.");
                return;
            }

            Console.Write("Por favor ingrese el ART del profesor: ");
            string art = Console.ReadLine();

            Console.Write("Por favor ingrese la antigüedad del profesor: ");
            int antiguedad;
            if (!int.TryParse(Console.ReadLine(), out antiguedad))
            {
                Console.WriteLine("Antigüedad no válida. No se ha creado el profesor.");
                return;
            }

            Console.Write("Por favor ingrese la materia del profesor: ");
            string materia = Console.ReadLine();

            Profesor nuevoProfesor = new Profesor(cargo, legajo, art, obraSocial, sueldoBruto, materia, antiguedad, id, nombre, apellido, dni, cuil);
            profes.Add(nuevoProfesor);

            Console.WriteLine("Profesor cargado exitosamente.");
        }

        static void MostrarProfesores()
        {
            Console.WriteLine("Lista de Profesores:");
            foreach (var profesor in profes)
            {
                Console.WriteLine($"Nombre: {profesor.Nombre}, Apellido: {profesor.Apellido}, DNI: {profesor.DNI}, Legajo: {profesor.Legajo}");
            }
        }


        static void BuscarProfesor()
        {
            Console.Write("Ingrese el dato para buscar al profesor (nombre, apellido, DNI, cuil, materia o antigüedad): ");
            string datoBuscado = Console.ReadLine().ToLower();

            List<Profesor> profesoresEncontrados = new List<Profesor>();

            foreach (var profesor in profes)
            {
                if (profesor.Nombre.ToLower().Contains(datoBuscado) ||
                    profesor.Apellido.ToLower().Contains(datoBuscado) ||
                    profesor.DNI.ToLower().Contains(datoBuscado) ||
                    profesor.Cuil.ToLower().Contains(datoBuscado) ||
                    profesor.Materia.ToLower().Contains(datoBuscado) ||
                    profesor.Antiguedad.ToString().Contains(datoBuscado))
                {
                    profesoresEncontrados.Add(profesor);
                }
            }

            if (profesoresEncontrados.Count > 0)
            {
                Console.WriteLine("Profesores encontrados:");
                foreach (var profesor in profesoresEncontrados)
                {
                    Console.WriteLine($"Nombre: {profesor.Nombre}, Apellido: {profesor.Apellido}, DNI: {profesor.DNI}, Legajo: {profesor.Legajo}");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron profesores con ese dato.");
            }
        }

        static void ActualizarProfesor()
        {
            Console.Write("Ingrese el DNI del profesor que desea actualizar: ");
            string dniActualizar = Console.ReadLine();

            Profesor profesorActualizar = profes.FirstOrDefault(profesor => profesor.DNI == dniActualizar);

            if (profesorActualizar != null)
            {
                Console.WriteLine("Profesor encontrado. Proporcione los nuevos datos:");

                Console.Write("Nuevo nombre: ");
                profesorActualizar.Nombre = Console.ReadLine();

                Console.Write("Nuevo apellido: ");
                profesorActualizar.Apellido = Console.ReadLine();

                Console.Write("Nueva materia: ");
                profesorActualizar.Materia = Console.ReadLine();

                Console.Write("Nueva antigüedad: ");
                profesorActualizar.Antiguedad = int.Parse(Console.ReadLine());

                Console.WriteLine("Profesor actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Profesor no encontrado.");
            }
        }

        static void EliminarProfesor()
        {
            Console.Write("Ingrese el dato para buscar al profesor que desea eliminar (nombre, apellido, DNI, cuil, materia o antigüedad): ");
            string datoBuscado = Console.ReadLine().ToLower();

            List<Profesor> profesoresEncontrados = new List<Profesor>();

            foreach (var profesor in profes)
            {
                if (profesor.Nombre.ToLower().Contains(datoBuscado) ||
                    profesor.Apellido.ToLower().Contains(datoBuscado) ||
                    profesor.DNI.ToLower().Contains(datoBuscado) ||
                    profesor.Cuil.ToLower().Contains(datoBuscado) ||
                    profesor.Materia.ToLower().Contains(datoBuscado) ||
                    profesor.Antiguedad.ToString().Contains(datoBuscado))
                {
                    profesoresEncontrados.Add(profesor);
                }
            }

            if (profesoresEncontrados.Count > 0)
            {
                Console.WriteLine("Profesores encontrados:");
                for (int i = 0; i < profesoresEncontrados.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Nombre: {profesoresEncontrados[i].Nombre}, Apellido: {profesoresEncontrados[i].Apellido}, DNI: {profesoresEncontrados[i].DNI}, Legajo: {profesoresEncontrados[i].Legajo}");
                }

                Console.Write("Seleccione el número del profesor que desea eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int seleccion))
                {
                    if (seleccion >= 1 && seleccion <= profesoresEncontrados.Count)
                    {
                        Profesor profesorAEliminar = profesoresEncontrados[seleccion - 1];
                        profes.Remove(profesorAEliminar);
                        Console.WriteLine("Profesor eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Número de selección no válido.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Ingrese un número de selección válido.");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron profesores con ese dato.");
            }
        }
    }
}