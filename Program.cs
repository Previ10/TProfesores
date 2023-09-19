using Proyecto_Comision_B;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Program
{
    static List<Profesor> profesores = new List<Profesor>();
    static string archivoPath = "profesores.txt";
    bool ingresoCorrecto = false;
    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Programa profesores. Seleccione la opción:");
            Console.WriteLine("1. Agregar Profesor(es)");
            Console.WriteLine("2. Mostrar Lista Profesores");
            Console.WriteLine("3. Buscar Profesores por Nombre o DNI");
            Console.WriteLine("4. Actualizar Listado Profesores");
            Console.WriteLine("5. Eliminar Profesor");
            Console.WriteLine("6. Operaciones de Archivo");
            Console.WriteLine("7. Salir");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AgregarProfesor();
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
                    MenuArchivos();
                    break;

                case "7":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static void AgregarProfesor()     
    {

      

        
            Console.Write("¿Cuántos profesores desea agregar? (Ingrese 1 para agregar uno, o más para agregar varios): ");
        if (int.TryParse(Console.ReadLine(), out int cantidad))
        {
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write("Por favor ingrese el ID completo del profesor: ");
                string idStr = Console.ReadLine();

                int id;
                if (!int.TryParse(idStr, out id))
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
                profesores.Add(nuevoProfesor);
                GuardarProfesoresEnArchivo();
                Console.WriteLine("Profesor cargado exitosamente.");
            }
        }
        else
        {
            Console.WriteLine("Cantidad no válida. No se han creado profesores.");
        }
    }
       
    static void MostrarProfesores()
    {
        if (profesores.Count == 0)
        {
            Console.WriteLine("No hay profesores registrados.");
        }
        else
        {
            Console.WriteLine("Lista de Profesores:");
            foreach (var profesor in profesores)
            {
                Console.WriteLine($"ID: {profesor.Id}, Nombre: {profesor.Nombre}, Apellido: {profesor.Apellido}, DNI: {profesor.DNI}, Legajo: {profesor.Legajo}");
            }
        }
    }

    static void BuscarProfesor()
    {
        Console.Write("Ingrese el dato para buscar al profesor (nombre o DNI): ");
        string datoBuscado = Console.ReadLine().ToLower();

        List<Profesor> profesoresEncontrados = profesores.Where(profesor => profesor.Nombre.ToLower().Contains(datoBuscado) || profesor.DNI.Contains(datoBuscado)).ToList();

        if (profesoresEncontrados.Count > 0)
        {
            Console.WriteLine("Profesores encontrados:");
            foreach (var profesor in profesoresEncontrados)
            {
                Console.WriteLine($"ID: {profesor.Id}, Nombre: {profesor.Nombre}, Apellido: {profesor.Apellido}, DNI: {profesor.DNI}, Legajo: {profesor.Legajo}");
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

        Profesor profesorActualizar = profesores.FirstOrDefault(profesor => profesor.DNI == dniActualizar);

        if (profesorActualizar != null)
        {
            Console.WriteLine("Profesor encontrado. Proporcione los nuevos datos:");

            Console.Write("Nuevo nombre: ");
            profesorActualizar.Nombre = Console.ReadLine();

            Console.Write("Nuevo apellido: ");
            profesorActualizar.Apellido = Console.ReadLine();

            Console.Write("Nuevo cargo: ");
            profesorActualizar.Cargo = Console.ReadLine();

            Console.Write("Nuevo legajo: ");
            if (int.TryParse(Console.ReadLine(), out int legajo))
            {
                profesorActualizar.Legajo = legajo;
            }
            else
            {
                Console.WriteLine("Legajo no válido. No se ha actualizado el profesor.");
            }

            Console.Write("Nueva obra social: ");
            profesorActualizar.ObraSocial = Console.ReadLine();

            Console.Write("Nuevo sueldo bruto: ");
            if (float.TryParse(Console.ReadLine(), out float sueldoBruto))
            {
                profesorActualizar.SueldoBruto = sueldoBruto;
            }
            else
            {
                Console.WriteLine("Sueldo bruto no válido. No se ha actualizado el profesor.");
            }

            Console.Write("Nuevo ART: ");
            profesorActualizar.ART = Console.ReadLine();

            Console.Write("Nueva antigüedad: ");
            if (int.TryParse(Console.ReadLine(), out int antiguedad))
            {
                profesorActualizar.Antiguedad = antiguedad;
            }
            else
            {
                Console.WriteLine("Antigüedad no válida. No se ha actualizado el profesor.");
            }

            Console.Write("Nueva materia: ");
            profesorActualizar.Materia = Console.ReadLine();

            GuardarProfesoresEnArchivo();
            Console.WriteLine("Profesor actualizado exitosamente.");
        }
        else
        {
            Console.WriteLine("Profesor no encontrado.");
        }
    }

    static void EliminarProfesor()
    {
        Console.Write("Ingrese el DNI del profesor que desea eliminar: ");
        string dniEliminar = Console.ReadLine();

        Profesor profesorEliminar = profesores.FirstOrDefault(profesor => profesor.DNI == dniEliminar);

        if (profesorEliminar != null)
        {
            profesores.Remove(profesorEliminar);
            GuardarProfesoresEnArchivo();
            Console.WriteLine("Profesor eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Profesor no encontrado.");
        }
    }

    static void MenuArchivos()
    {
        bool menuArchivos = true;
        while (menuArchivos)
        {
            Console.WriteLine("Menu de Archivos:");
            Console.WriteLine("1. Crear archivo de Profesores");
            Console.WriteLine("2. Leer archivo de Profesores");
            Console.WriteLine("3. Modificar archivo de Profesores");
            Console.WriteLine("4. Borrar archivo de Profesores");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Opción: ");

            string opcionArchivo = Console.ReadLine();

            switch (opcionArchivo)
            {
                case "1":
                    CrearArchivo();
                    break;

                case "2":
                    LeerArchivo();
                    break;

                case "3":
                    ModificarArchivo();
                    break;

                case "4":
                    BorrarArchivo();
                    break;

                case "5":
                    menuArchivos = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static void CrearArchivo()
    {
        Console.Write("Ingrese la ruta donde desea guardar el archivo (por ejemplo, C:\\carpeta\\): ");
        string directorio = Console.ReadLine();

        Console.Write("Ingrese el nombre del archivo: ");
        string nombreArchivo = Console.ReadLine();

        archivoPath = Path.Combine(directorio, nombreArchivo);


        try
        {
            using (StreamWriter writer = new StreamWriter(archivoPath))
            {
                foreach (var profesor in profesores)
                {
                    writer.WriteLine($"ID: {profesor.Id}");
                    writer.WriteLine($"Nombre: {profesor.Nombre}");
                    writer.WriteLine($"Apellido: {profesor.Apellido}");
                    writer.WriteLine($"DNI: {profesor.DNI}");
                    writer.WriteLine($"CUIL: {profesor.Cuil}");
                    writer.WriteLine($"Cargo: {profesor.Cargo}");
                    writer.WriteLine($"Legajo: {profesor.Legajo}");
                    writer.WriteLine($"Obra Social: {profesor.ObraSocial}");
                    writer.WriteLine($"Sueldo Bruto: {profesor.SueldoBruto}");
                    writer.WriteLine($"ART: {profesor.ART}");
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


    static void LeerArchivo()
    {
        Console.Write("Ingrese la ruta del archivo de profesores: ");
        archivoPath = Console.ReadLine();

        if (File.Exists(archivoPath))
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivoPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo de profesores: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("El archivo no existe.");
        }
    }

    static void ModificarArchivo()
    {
        Console.Write("Ingrese la ruta del archivo de profesores a modificar (por ejemplo, profesores.txt): ");
        string archivoAModificar = Console.ReadLine();

        if (File.Exists(archivoAModificar))
        {
            try
            {
                List<Profesor> profesoresTemp = new List<Profesor>();
                using (StreamReader reader = new StreamReader(archivoAModificar))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("ID: "))
                        {
                            int id;
                            if (int.TryParse(line.Replace("ID: ", ""), out id))
                            {
                                string nombre = "";
                                string apellido = "";
                                string dni = "";
                                string cuil = "";
                                string cargo = "";
                                int legajo = 0;
                                string obraSocial = "";
                                float sueldoBruto = 0.0f;
                                string art = "";
                                int antiguedad = 0;
                                string materia = "";

                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (line.StartsWith("Nombre: "))
                                    {
                                        nombre = line.Replace("Nombre: ", "");
                                    }
                                    else if (line.StartsWith("Apellido: "))
                                    {
                                        apellido = line.Replace("Apellido: ", "");
                                    }
                                    else if (line.StartsWith("DNI: "))
                                    {
                                        dni = line.Replace("DNI: ", "");
                                    }
                                    else if (line.StartsWith("CUIL: "))
                                    {
                                        cuil = line.Replace("CUIL: ", "");
                                    }
                                    else if (line.StartsWith("Cargo: "))
                                    {
                                        cargo = line.Replace("Cargo: ", "");
                                    }
                                    else if (line.StartsWith("Legajo: "))
                                    {
                                        if (int.TryParse(line.Replace("Legajo: ", ""), out legajo))
                                        {
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error al leer el Legajo del profesor.");
                                        }
                                    }
                                    else if (line.StartsWith("Obra Social: "))
                                    {
                                        obraSocial = line.Replace("Obra Social: ", "");
                                    }
                                    else if (line.StartsWith("Sueldo Bruto: "))
                                    {
                                        if (float.TryParse(line.Replace("Sueldo Bruto: ", ""), out sueldoBruto))
                                        {
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error al leer el Sueldo Bruto del profesor.");
                                        }
                                    }
                                    else if (line.StartsWith("ART: "))
                                    {
                                        art = line.Replace("ART: ", "");
                                    }
                                    else if (line.StartsWith("Antigüedad: "))
                                    {
                                        if (int.TryParse(line.Replace("Antigüedad: ", ""), out antiguedad))
                                        {
                                           
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error al leer la Antigüedad del profesor.");
                                        }
                                    }
                                    else if (line.StartsWith("Materia: "))
                                    {
                                        materia = line.Replace("Materia: ", "");
                                    }
                                    
                                    else if (line == "---------------")
                                    {
                                       
                                        Profesor nuevoProfesor = new Profesor(cargo, legajo, art, obraSocial, sueldoBruto, materia, antiguedad, id, nombre, apellido, dni, cuil);
                                        profesoresTemp.Add(nuevoProfesor);
                                        break; 
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error al leer el ID del profesor.");
                            }
                        }
                    }
                }


                Console.Write("Ingrese la ruta donde desea guardar el archivo modificado (por ejemplo, C:\\carpeta\\): ");
                string directorioNuevo = Console.ReadLine();

                Console.Write("Ingrese el nombre del archivo modificado: ");
                string nombreArchivoNuevo = Console.ReadLine();

                string archivoNuevoPath = Path.Combine(directorioNuevo, nombreArchivoNuevo);

                using (StreamWriter writer = new StreamWriter(archivoNuevoPath))
                {
                    foreach (var profesor in profesoresTemp)
                    {
                        writer.WriteLine($"ID: {profesor.Id}");
                        writer.WriteLine($"Nombre: {profesor.Nombre}");
                        writer.WriteLine($"Apellido: {profesor.Apellido}");
                        writer.WriteLine($"DNI: {profesor.DNI}");
                        writer.WriteLine($"CUIL: {profesor.Cuil}");
                        writer.WriteLine($"Cargo: {profesor.Cargo}");
                        writer.WriteLine($"Legajo: {profesor.Legajo}");
                        writer.WriteLine($"Obra Social: {profesor.ObraSocial}");
                        writer.WriteLine($"Sueldo Bruto: {profesor.SueldoBruto}");
                        writer.WriteLine($"ART: {profesor.ART}");
                        writer.WriteLine($"Antigüedad: {profesor.Antiguedad}");
                        writer.WriteLine($"Materia: {profesor.Materia}");
                        writer.WriteLine("---------------");
                    }
                    Console.WriteLine($"Archivo de profesores modificado exitosamente: {archivoNuevoPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar el archivo de profesores: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("El archivo no existe.");
        }
    }

    static void BorrarArchivo()
    {
        Console.Write("Ingrese la ruta del archivo de profesores a borrar (por ejemplo, profesores.txt): ");
        string archivoABorrar = Console.ReadLine();

        if (File.Exists(archivoABorrar))
        {
            try
            {
                File.Delete(archivoABorrar);
                Console.WriteLine($"Archivo de profesores borrado exitosamente: {archivoABorrar}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el archivo de profesores: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("El archivo no existe.");
        }
    }

    static void GuardarProfesoresEnArchivo()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(archivoPath))
            {
                foreach (var profesor in profesores)
                {
                    writer.WriteLine($"ID: {profesor.Id}");
                    writer.WriteLine($"Nombre: {profesor.Nombre}");
                    writer.WriteLine($"Apellido: {profesor.Apellido}");
                    writer.WriteLine($"DNI: {profesor.DNI}");
                    writer.WriteLine($"CUIL: {profesor.Cuil}");
                    writer.WriteLine($"Cargo: {profesor.Cargo}");
                    writer.WriteLine($"Legajo: {profesor.Legajo}");
                    writer.WriteLine($"Obra Social: {profesor.ObraSocial}");
                    writer.WriteLine($"Sueldo Bruto: {profesor.SueldoBruto}");
                    writer.WriteLine($"ART: {profesor.ART}");
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
}

