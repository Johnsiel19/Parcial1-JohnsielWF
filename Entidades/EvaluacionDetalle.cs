using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class EvaluacionDetalle
    {
        [Key]
        public int Id { get; set; }
        public int EvaluacionId { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdidos { get; set; }

        public EvaluacionDetalle()
        {
            Id = 0;
            Categoria = string.Empty;
            Valor = 0;
            Logrado = 0;
            Perdidos = 0;
        }
        public EvaluacionDetalle(int id, int  evaluacion,string categoria, decimal valor, decimal logrado, decimal perdidos)
        {
            Id = id;
            EvaluacionId = evaluacion;
            Categoria = categoria;
            Valor = valor;
            Logrado = logrado;
            Perdidos = perdidos;
        }
    }
}
