using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JALLPITASBAdmin.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        //public ICollection<Carpeta> Carpetas { get; set; }
        //public ICollection<Provincia> Provincias { get; set; }
    }
}
