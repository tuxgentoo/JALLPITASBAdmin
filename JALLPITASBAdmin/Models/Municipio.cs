using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JALLPITASBAdmin.Models
{
    public class Municipio
    {
        [Key]
        public int MunicipioId { get; set; }
        [Required]
        public string Nombre { get; set; }
        //public List<Carpeta> Carpetas { get; set; }
        //public int ProvinciaId { get; set; }
        //public Provincia Provincia { get; set; }
    }
}
