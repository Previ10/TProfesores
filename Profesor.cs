using Proyecto_Comision_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Proyecto_Comision_B
{
    internal class Profesor : Empleado, Isueldo
    {
        public string Materia { get; set; }
        public int Antiguedad { get; set; }
        public string ART { get; set; }

        public Profesor(string cargo, int legajo, string art, string obraSocial, float sueldoBruto, string materia, int antiguedad, int id, string nombre, string apellido, string dni, string cuil)
     : base(cargo, legajo, art, obraSocial, sueldoBruto, id, nombre, apellido, dni, cuil)
        {
            Materia = materia;
            Antiguedad = antiguedad;
        }

        public new float SueldoBruto
        {
            get { return base.SueldoBruto; }
            set { base.SueldoBruto = value; }
        }
        public float CalcularSueldoNeto()
        {
            
            float obraSocial = SueldoBruto * 0.03f;
            float descuentoINSSJP = SueldoBruto * 0.03f;
            float jubilacion = SueldoBruto * 0.11f;
            float deduccionTotal = obraSocial + descuentoINSSJP + jubilacion;
            float sueldoNeto = SueldoBruto - deduccionTotal;
            return sueldoNeto;
        }

        public void Evaluar()
        {
            
        }

        public string Calificar()
        {
            return "Estoy calificando";
        }

        public string ObtenerMateria()
        {
            return Materia;
        }

        public int ObtenerAntiguedad()
        {
            return Antiguedad;
        }
    }
}
