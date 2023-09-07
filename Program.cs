using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Comision_B
{
    internal class Program
    {
        static void Main(string[] args)
        {        
         
             List<Profesor> profes = new List<Profesor>();    
             
            while (true)
            {

                Console.WriteLine("Programa profesores. Seleccione la opcion: ");
                Console.WriteLine("Option 1: Agregar Profesores ");
                Console.WriteLine("Option 2: Mostrar Lista Profesores");
                Console.WriteLine("Option 3: Buscar Profesores");
                Console.WriteLine("Oprion 4: Actulizar Listado Profesores");
                Console.WriteLine("Oprion 5: Eliminar Profesor");
                Console.WriteLine("Oprion 6: Salir");

                string option = Console.ReadLine();

                switch (option)
                {


                    case "1": break;
                    case "2": break;
                    case "3": break;
                    case "4": break;
                    case "5": break;
                    case "6": break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;


                }


            }
        }
        static void AgregarProfe()
        {
            Console.Write("Por favor ingrese el id completo del profesor: ");
            String id = Console.ReadLine();
            
            Console.Write("Por favor ingrese el nombre  del profesor: ");
            String nombre = Console.ReadLine();

            Console.Write("Por favor ingrese el nombre  del profesor: ");
            var apellido = Console.ReadLine();

            Console.Write("Por favor ingrese el DNI del profesor: ");
            String dni = Console.ReadLine();

            Console.Write("Por favor ingrese el cuil del profesor: ");
            String cuil = Console.ReadLine();

            Console.Write("Por favor ingrese el cargo del profesor: ");
            String cargo = Console.ReadLine();

            Console.Write("Por favor ingrese el legajo del profesor: ");
            var legajo = int.Parse(Console.ReadLine());

            Console.Write("Por favor ingrese el obra scial del profesor: ");
            String obraSocial = Console.ReadLine();

            Console.Write("Por favor ingrese el sueldo bruto del profesor: ");
            var sueldoBruto = int.Parse(Console.ReadLine());


            Console.Write("Por favor ingrese el art del profesor: ");
            String art = Console.ReadLine();

            Console.Write("Por favor ingrese la antiguedad del profesor: ");
            String antiguedad = Console.ReadLine();

            Console.Write("Por favor ingrese el materia del profesor: ");
            String materia = Console.ReadLine();

            Profesor nuevoProfesor = new Profesor(cargo, legajo, art, obraSocial, sueldoBruto, id, nombre, apellido,  dni, cuil, materia, antiguedad );

            Console.WriteLine("Profesor cargado exitosamente ");

        }

      
    }
   








}
