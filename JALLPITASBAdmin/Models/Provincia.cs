using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ICollection<Carpeta> Carpetas { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
    }
}
