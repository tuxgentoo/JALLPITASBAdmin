using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JALLPITASBAdmin.Models
{
    public class PlanillaRegistro
    {
        public int PlanillaRegistroId { get; set; }
        public string Nombre { get; set; }
        public int Ci { get; set; }
        public int Celular { get; set; }
        public int TipoPersona { get; set; }
        public int Departamento { get; set; }
        public string TemaConsulta { get; set; }
        public DateTime Fecha { get; set; }
    }
}
