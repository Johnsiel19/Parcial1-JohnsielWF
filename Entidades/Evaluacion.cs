using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Evaluacion
    {
        [Key]

        public int EvaluacionId { get; set; }

        public string Estudiante { get; set; }
        public decimal Promedio { get; set; }
        public DateTime Fecha { get; set; }
        public List<EvaluacionDetalle> Detalle { get; set; }

        public Evaluacion()
        {
            EvaluacionId = 0;
            Estudiante = string.Empty;
            Promedio = 0;
            Fecha = DateTime.Now;
            Detalle = new List<EvaluacionDetalle>();


        }
    }
}
