using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JALLPITASBAdmin.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Ci { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        //public string Celular { get; set; }
        public string Cargo { get; set; }
        public string Profesion { get; set; }
        public Boolean Activo { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", Nombres, Apellidos);
            }
        }
    }
}
