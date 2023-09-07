using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Comision_B
{
    internal class Empleado : Persona, Isueldo
    {

        public void Sueldo()
        {
            
        }
        private String cargo;
        private int legajo;
        private String art;
        private String obraSocial;
        private float sueldoBruto;

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }
        public string Art
        {
            get { return art; }
            set { art = value; }
        }
        public string ObraSocial
        {
            get { return obraSocial; }
            set { obraSocial = value; }
        }
        public float SueldoBruto
        {
            get { return sueldoBruto; }
            set { sueldoBruto = value; }
        }

        public Empleado(string cargo, int legajo, string art, string obraSocial, float sueldoBruto, int id, string nombre, string apellido, string dni, string cuil) 
            :base ( id,  nombre,  apellido,  dni,  cuil)
        {
            this.cargo = cargo;
            this.legajo = legajo;
            this.art = art;
            this.obraSocial = obraSocial;
            this.sueldoBruto = sueldoBruto;


        }


    }
    




}
