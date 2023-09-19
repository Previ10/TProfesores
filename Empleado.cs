using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Comision_B
{
    internal class Empleado : Persona, Isueldo
    {
        private string cargo;
        private int legajo;
        private string art;
        private string obraSocial;
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
            : base(id, nombre, apellido, dni, cuil)
        {
            this.cargo = cargo;
            this.legajo = legajo;
            this.art = art;
            this.obraSocial = obraSocial;
            this.sueldoBruto = sueldoBruto;
        }

        public float CalcularSueldoNeto()
        {
            float obraSocialDescuento = sueldoBruto * 0.03f;
            float descuentoINSSJP = sueldoBruto * 0.03f;
            float jubilacion = sueldoBruto * 0.11f;
            float deduccionTotal = obraSocialDescuento + descuentoINSSJP + jubilacion;
            float sueldoNeto = sueldoBruto - deduccionTotal;
            return sueldoNeto;
        }
        public float ObtenerSueldoBruto()
        {
            return SueldoBruto;
        }
    }
}