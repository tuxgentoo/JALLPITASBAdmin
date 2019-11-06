using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JALLPITASBAdmin.Models;

namespace JALLPITASBAdmin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JALLPITASBAdmin.Models.Carpeta> Carpetas { get; set; }
        public DbSet<JALLPITASBAdmin.Models.Departamento> Departamentos { get; set; }
    }
}
