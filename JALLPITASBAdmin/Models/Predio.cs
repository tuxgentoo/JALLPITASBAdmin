using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JALLPITASBAdmin.Models
{
    public class Predio
    {
        [Key]
        public int PredioId { get; set; }
        public double CodPre { get; set; }
        public string Nombre { get; set; }
        public double Superficie { get; set; }
    }
}
