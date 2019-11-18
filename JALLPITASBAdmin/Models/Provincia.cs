using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JALLPITASBAdmin.Models
{
    public class Provincia
    {
        [Key]
        public int ProvinciaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public virtual ICollection<Carpeta> Carpetas { get; set; }
        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
    }
}
