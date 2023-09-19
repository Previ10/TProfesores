using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Comision_B
{
    abstract class Persona { 
    
    
        private int id;
        private string nombre;
        private string apellido;
        private string dni;
        private string cuil;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Cuil
        {
            get { return cuil; }
            set { cuil = value; }
        }


        public Persona(int id, string nombre, string apellido, string dni, string cuil)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.cuil = cuil;
        }


        public Persona()
        {

        }

      


    }
}
