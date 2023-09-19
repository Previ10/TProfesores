using Proyecto_Comision_B;
using System;
using System.Collections.Generic;
using System.IO;

namespace proyectoprogramacion
{
    internal class Program
    {
        static List<Profesor> profesores = new List<Profesor>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("-------------------------------MENÚ DE OPCIONES-------------------------------");
                Console.WriteLine("1: Agregar profesor");
                Console.WriteLine("2: Buscar profesor");
                Console.WriteLine("3: Actualizar profesor");
                Console.WriteLine("4: Eliminar profesor");
                Console.WriteLine("5: Mostrar lista de profesores");
                Console.WriteLine("6: Calcular Sueldo Neto");
                Console.WriteLine("7: Guardar profesores en un archivo de texto");
                Console.WriteLine("8: Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarProfesor();
                            break;

                            ;

                        case 2:
                            BuscarProfesor();
                            break;

                        case 3:
                            ActualizarProfesor();
                            break;

                        case 4:
                            EliminarProfesor();
                            break;

                        case 5:
                            MostrarListaProfesores();
                            break;

                        case 6:
                            CalcularSueldoNeto();
                            break;

                        case 7:
                            CrearArchivoDeProfesores();
                            break;

                        case 8:
                            Console.WriteLine("Finalizando sistema...");
                            break;

                        default:
                            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                Console.WriteLine();
            }
            while (opcion != 9);
        }

        static void AgregarProfesor()
        {
            Console.WriteLine("Ingrese los datos del profesor:");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("DNI: ");
            string dni = Console.ReadLine();

            Console.Write("CUIL: ");
            string cuil = Console.ReadLine();

            Console.Write("Cargo: ");
            string cargo = Console.ReadLine();

            Console.Write("Legajo: ");
            int legajo = int.Parse(Console.ReadLine());

            Console.Write("Obra Social: ");
            string obraSocial = Console.ReadLine();

            Console.Write("Sueldo Bruto: ");
            float sueldoBruto = float.Parse(Console.ReadLine());

            Console.Write("ART: ");
            string art = Console.ReadLine();

            Console.Write("Antigüedad : ");
            int antiguedad = int.Parse(Console.ReadLine());

            Console.Write("ID : ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Materia: ");
            string materia = Console.ReadLine();

            profesores.Add(new Profesor(cargo, legajo, art, obraSocial, sueldoBruto, materia, antiguedad, id, nombre, apellido, dni, cuil));

            Console.WriteLine("Profesor agregado exitosamente.");
        }

        static void CrearArchivoDeProfesores()
        {
            Console.Write("Ingrese la ruta donde desea guardar el archivo (por ejemplo, C:\\carpeta\\): ");
            string directorio = Console.ReadLine();

            Console.Write("Ingrese el nombre del archivo: ");
            string nombreArchivo = Console.ReadLine();

            string archivoPath = Path.Combine(directorio, nombreArchivo);

            try
            {
                using (StreamWriter writer = new StreamWriter(archivoPath))
                {
                    foreach (var profesor in profesores)
                    {
                        writer.WriteLine($"Nombre: {profesor.Nombre}");
                        writer.WriteLine($"Apellido: {profesor.Apellido}");
                        writer.WriteLine($"DNI: {profesor.DNI}");
                        writer.WriteLine($"CUIL: {profesor.Cuil}");
                        writer.WriteLine($"Cargo: {profesor.Cargo}");
                        writer.WriteLine($"Legajo: {profesor.Legajo}");
                        writer.WriteLine($"Obra Social: {profesor.ObraSocial}");
                        writer.WriteLine($"Sueldo Bruto: {profesor.SueldoBruto}");
                        writer.WriteLine($"ART: {profesor.Art}");
                        writer.WriteLine($"Antigüedad: {profesor.Antiguedad}");
                        writer.WriteLine($"Materia: {profesor.Materia}");
                        writer.WriteLine("---------------");
                    }
                    Console.WriteLine($"Datos de profesores guardados exitosamente en {archivoPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los datos de profesores: {ex.Message}");
            }
        }

        static void BuscarProfesor()
        {
            Console.Write("Ingrese el DNI del profesor a buscar: ");
            string dniBuscado = Console.ReadLine();

            bool profesorEncontrado = false;

            Console.WriteLine("Profesores encontrados:");

            foreach (var profesor in profesores)
            {
                if (profesor.DNI.Equals(dniBuscado))
                {
                    Console.WriteLine($"Nombre: {profesor.Nombre}");
                    Console.WriteLine($"Apellido: {profesor.Apellido}");
                    Console.WriteLine($"DNI: {profesor.DNI}");
                    Console.WriteLine($"CUIL: {profesor.Cuil}");
                    Console.WriteLine($"Cargo: {profesor.Cargo}");
                    Console.WriteLine($"Legajo: {profesor.Legajo}");
                    Console.WriteLine($"Obra Social: {profesor.ObraSocial}");
                    Console.WriteLine($"Sueldo Bruto: {profesor.SueldoBruto}");
                    Console.WriteLine($"ART: {profesor.Art}");
                    Console.WriteLine($"Antigüedad: {profesor.Antiguedad}");
                    Console.WriteLine($"Materia: {profesor.Materia}");
                    Console.WriteLine("---------------");
                    profesorEncontrado = true;
                }
            }

            if (!profesorEncontrado)
            {
                Console.WriteLine("No se encontró ningún profesor con ese DNI.");
            }
        }

        static void ActualizarProfesor()
        {
            Console.Write("Ingrese el DNI del profesor a actualizar: ");
            string dniActualizar = Console.ReadLine();

            Profesor profesorActualizar = profesores.Find(profesor => profesor.DNI.Equals(dniActualizar));

            if (profesorActualizar != null)
            {
                Console.WriteLine("Profesor encontrado. Proporcione los nuevos datos:");

                Console.Write("Nombre: ");
                profesorActualizar.Nombre = Console.ReadLine();

                Console.Write("Apellido: ");
                profesorActualizar.Apellido = Console.ReadLine();

                Console.Write("CUIL: ");
                profesorActualizar.Cuil = Console.ReadLine();

                Console.Write("Cargo: ");
                profesorActualizar.Cargo = Console.ReadLine();

                Console.Write("Legajo: ");
                profesorActualizar.Legajo = int.Parse(Console.ReadLine());

                Console.Write("Obra Social: ");
                profesorActualizar.ObraSocial = Console.ReadLine();

                Console.Write("Sueldo Bruto: ");
                profesorActualizar.SueldoBruto = float.Parse(Console.ReadLine());

                Console.Write("ART: ");
                profesorActualizar.Art = Console.ReadLine();

                Console.Write("Antigüedad (en meses): ");
                profesorActualizar.Antiguedad = int.Parse(Console.ReadLine());

                Console.Write("Materia: ");
                profesorActualizar.Materia = Console.ReadLine();

                Console.WriteLine("Profesor actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró ningún profesor con ese DNI.");
            }
        }

        static void EliminarProfesor()
        {
            Console.Write("Ingrese el DNI del profesor a eliminar: ");
            string dniEliminar = Console.ReadLine();

            Profesor profesorEliminar = profesores.Find(profesor => profesor.DNI.Equals(dniEliminar));

            if (profesorEliminar != null)
            {
                profesores.Remove(profesorEliminar);
                Console.WriteLine("Profesor eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró ningún profesor con ese DNI.");
            }
        }

        static void MostrarListaProfesores()
        {
            Console.WriteLine("Lista de Profesores:");

            foreach (var profesor in profesores)
            {
                Console.WriteLine($"Nombre: {profesor.Nombre}");
                Console.WriteLine($"Apellido: {profesor.Apellido}");
                Console.WriteLine($"DNI: {profesor.DNI}");
                Console.WriteLine($"CUIL: {profesor.Cuil}");
                Console.WriteLine($"Cargo: {profesor.Cargo}");
                Console.WriteLine($"Legajo: {profesor.Legajo}");
                Console.WriteLine($"Obra Social: {profesor.ObraSocial}");
                Console.WriteLine($"Sueldo Bruto: {profesor.SueldoBruto}");
                Console.WriteLine($"ART: {profesor.Art}");
                Console.WriteLine($"Antigüedad: {profesor.Antiguedad}");
                Console.WriteLine($"Materia: {profesor.Materia}");
                Console.WriteLine("---------------");
            }
        }

        static void CalcularSueldoNeto()
        {
            Console.Write("Ingrese el DNI del profesor para calcular el Sueldo Neto: ");
            string dniCalcular = Console.ReadLine();

            Profesor profesorCalcular = profesores.Find(profesor => profesor.DNI.Equals(dniCalcular));

            if (profesorCalcular != null)
            {
                float sueldoNeto = profesorCalcular.CalcularSueldoNeto();
                Console.WriteLine($"El Sueldo Neto del profesor es: {sueldoNeto:C}");
            }
            else
            {
                Console.WriteLine("No se encontró ningún profesor con ese DNI.");
            }
        }

        
    }
}