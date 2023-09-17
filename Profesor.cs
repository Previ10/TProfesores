using Proyecto_Comision_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



internal class Profesor : Empleado
{
    public string Materia { get; set; }
    public int Antiguedad { get; set; }
    public string ART { get; set; }

    public Profesor(string cargo, int legajo, string art, string obraSocial, float sueldoBruto, string materia, int antiguedad, int id, string nombre, string apellido, string dni, string cuil)
        : base(cargo, legajo, art, obraSocial, sueldoBruto, id, nombre, apellido ,dni,cuil)
    {
        Materia = materia;
        Antiguedad = antiguedad;
    }

    public void Evaluar()
    {
    }

    public void Calificar()
    {
        
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
