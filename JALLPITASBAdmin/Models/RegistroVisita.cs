using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JALLPITASBAdmin.Models
{
    public class RegistroVisita
    {
        public int RegistroVisitaId { get; set; }
        public string Nombre { get; set; }
        public int Ci { get; set; }
        public int Celular { get; set; }
        public string TipoPersona { get; set; }
        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }        
        public string NombreProceso { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaVisita { get; set; }
    }
}
