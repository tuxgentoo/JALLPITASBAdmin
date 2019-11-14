using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JALLPITASBAdmin.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {

        }
        public ApplicationRole(string roleName) : base(roleName)
        {

        }
        public ApplicationRole(string roleName, string descripcion, DateTime fechaCreacion) : base(roleName)
        {
            this.Descripcion = descripcion;
            this.FechaCreacion = fechaCreacion;
        }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
