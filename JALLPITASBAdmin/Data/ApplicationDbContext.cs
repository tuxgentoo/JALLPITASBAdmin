using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JALLPITASBAdmin.Models;
using System.Linq;

namespace JALLPITASBAdmin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<JALLPITASBAdmin.Models.Carpeta> Carpetas { get; set; }
        public DbSet<JALLPITASBAdmin.Models.Departamento> Departamentos { get; set; }
        public DbSet<JALLPITASBAdmin.Models.Provincia> Provincias { get; set; }
        public DbSet<JALLPITASBAdmin.Models.Municipio> Municipios { get; set; }        
    }
}
