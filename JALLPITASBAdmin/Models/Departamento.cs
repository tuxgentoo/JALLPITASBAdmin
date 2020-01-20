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
        public virtual ICollection<Carpeta> Carpetas { get; set; }
        public virtual ICollection<Provincia> Provincias { get; set; }
        public virtual ICollection<RegistroVisita> RegistroVisitas { get; set; }
    }
}
