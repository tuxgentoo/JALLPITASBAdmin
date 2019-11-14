using JALLPITASBAdmin.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JALLPITASBAdmin.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(
            ApplicationDbContext _context,
            UserManager<ApplicationUser> _userManager,
            RoleManager<ApplicationRole> _roleManager)
        {
            _context.Database.EnsureCreated();

            string role1 = "ADMINISTRADOR";
            string desc1 = "Perfil de administrador donde tendra todos los accesos al sistema";

            string role2 = "ADMINISTRATIVO";
            string desc2 = "Perfil de administrativos";

            string role3 = "TECNICO";
            string desc3 = "Perfil tecnico";

            string role4 = "JURIDICO";
            string desc4 = "Perfil juridico";

            string password = "Franky22622#";
            if (await _roleManager.FindByNameAsync(role1) == null)
            {
                await _roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await _roleManager.FindByNameAsync(role2) == null)
            {
                await _roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }
            if (await _roleManager.FindByNameAsync(role3) == null)
            {
                await _roleManager.CreateAsync(new ApplicationRole(role3, desc3, DateTime.Now));
            }
            if (await _roleManager.FindByNameAsync(role4) == null)
            {
                await _roleManager.CreateAsync(new ApplicationRole(role4, desc4, DateTime.Now));
            }
            if (await _userManager.FindByNameAsync("VISUALSOFT.S.A@GMAIL.COM") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "VISUALSOFT.S.A@GMAIL.COM",
                    Email = "VISUALSOFT.S.A@GMAIL.COM",
                    Nombres = "FRANZ WILLAN",
                    Apellidos = "MARTINEZ CHOQUE",
                    Ci = 5493245,
                    Cargo = "PROFESIONAL III SIST",
                    Profesion = "ING. DE SISTEMAS",
                    PhoneNumber = "73418121",
                    Activo = true
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(user, password);
                    await _userManager.AddToRoleAsync(user, role1);
                }

                _ = user.Id;
            }

            if (await _userManager.FindByNameAsync("ADMINISTRATIVO@HOTMAIL.COM") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "ADMINISTRATIVO@HOTMAIL.COM",
                    Email = "ADMINISTRATIVO@HOTMAIL.COM",
                    Nombres = "WILLAN",
                    Apellidos = "MARTINEZ CHOQUE",
                    Ci = 5493245,
                    Cargo = "PROFESIONAL III SIST",
                    Profesion = "ING. DE SISTEMAS",
                    PhoneNumber = "73418121",
                    Activo = true
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(user, password);
                    await _userManager.AddToRoleAsync(user, role2);
                }

                _ = user.Id;
            }

            if (await _userManager.FindByNameAsync("TECNICO@HOTMAIL.COM") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "TECNICO@HOTMAIL.COM",
                    Email = "TECNICO@HOTMAIL.COM",
                    Nombres = "WILLAN",
                    Apellidos = "MARTINEZ CHOQUE",
                    Ci = 5493245,
                    Cargo = "PROFESIONAL III SIST",
                    Profesion = "ING. DE SISTEMAS",
                    PhoneNumber = "73418121",
                    Activo = true
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(user, password);
                    await _userManager.AddToRoleAsync(user, role3);
                }

                _ = user.Id;
            }

            if (await _userManager.FindByNameAsync("JURIDICO@HOTMAIL.COM") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "JURIDICO@HOTMAIL.COM",
                    Email = "JURIDICO@HOTMAIL.COM",
                    Nombres = "WILLAN",
                    Apellidos = "MARTINEZ CHOQUE",
                    Ci = 5493245,
                    Cargo = "PROFESIONAL III SIST",
                    Profesion = "ING. DE SISTEMAS",
                    PhoneNumber = "73418121",
                    Activo = true
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(user, password);
                    await _userManager.AddToRoleAsync(user, role4);
                }

                _ = user.Id;
            }

            //Buscar si existe registros en la tabla Departamentos
            if (_context.Departamentos.Any() || _context.Provincias.Any())
            {
                return;
            }
            var departamentos = new Departamento[]
            {
                new Departamento { Nombre = "CHUQUISACA" },
                new Departamento { Nombre = "TARIJA" },
                new Departamento { Nombre = "COCHABAMBA" }
            };
            foreach (Departamento d in departamentos)
            {
                _context.Departamentos.Add(d);
            }
            _context.SaveChanges();

            var provincias = new Provincia[]
            {
                //Provinciass de CHUQUISACA
                new Provincia { Nombre = "AZURDUY", DepartamentoId = 1 },
                new Provincia { Nombre = "BELISARIO BOETO", DepartamentoId = 1 },
                new Provincia { Nombre = "HERNANDO SILES", DepartamentoId = 1 },
                new Provincia { Nombre = "LUIS CALVO", DepartamentoId = 1 },
                new Provincia { Nombre = "NOR CINTI", DepartamentoId = 1 },
                new Provincia { Nombre = "OROPEZA", DepartamentoId = 1 },
                new Provincia { Nombre = "SUD CINTI", DepartamentoId = 1 },
                new Provincia { Nombre = "TOMINA", DepartamentoId = 1 },
                new Provincia { Nombre = "YAMPARAEZ", DepartamentoId = 1 },
                new Provincia { Nombre = "ZUDAÑEZ", DepartamentoId = 1 },
                //Provinciass de TARIJA
                new Provincia { Nombre = "ANICETO ARCE", DepartamentoId = 2 },
                new Provincia { Nombre = "AVILES", DepartamentoId = 2 },
                new Provincia { Nombre = "CERCADO", DepartamentoId = 2 },
                new Provincia { Nombre = "GRAN CHACO", DepartamentoId = 2 },
                new Provincia { Nombre = "MENDEZ", DepartamentoId = 2 },
                new Provincia { Nombre = "O'CONOR", DepartamentoId = 2 }
            };
            foreach (Provincia p in provincias)
            {
                _context.Provincias.Add(p);
            }
            _context.SaveChanges();

            var municipios = new Municipio[]
            {
                //Provinciass de CHUQUISACA
                //AZURDUY 1
                new Municipio { Nombre = "VILLA AZURDUY", ProvinciaId = 1 },
                new Municipio { Nombre = "TARVITA", ProvinciaId = 1 },
                //BELISARIO BOETO 2
                new Municipio { Nombre = "VILLA SERRANO", ProvinciaId = 2 },
                //HERNANDO SILES 3
                new Municipio { Nombre = "MONTEAGUDO", ProvinciaId = 3 },
                new Municipio { Nombre = "SAN PABLO DE HUACARETA", ProvinciaId = 3 },
                //LUIS CALVO 4
                new Municipio { Nombre = "VILLA VACA GUZMAN", ProvinciaId = 4 },
                new Municipio { Nombre = "HUACAYA", ProvinciaId = 4 },
                new Municipio { Nombre = "MACHARETI", ProvinciaId = 4 },
                //NOR CINTI 5
                new Municipio { Nombre = "CAMARGO", ProvinciaId = 5 },
                new Municipio { Nombre = "INCAHUASI", ProvinciaId = 5 },
                new Municipio { Nombre = "SAN LUCAS", ProvinciaId = 5 },
                new Municipio { Nombre = "VILLA CHARCAS", ProvinciaId = 5 },
                //OROPEZA 6
                new Municipio { Nombre = "SUCRE", ProvinciaId = 6 },
                new Municipio { Nombre = "POROMA", ProvinciaId = 6 },
                new Municipio { Nombre = "YOTALA", ProvinciaId = 6 },
                //SUD CINTI 7
                new Municipio { Nombre = "VILLA ABECIA", ProvinciaId = 7 },
                new Municipio { Nombre = "CULPINA", ProvinciaId = 7 },
                new Municipio { Nombre = "LAS CARRERAS", ProvinciaId = 7 },
                //TOMINA 8
                new Municipio { Nombre = "PADILLA", ProvinciaId = 8 },
                new Municipio { Nombre = "EL VILLAR", ProvinciaId = 8 },
                new Municipio { Nombre = "SOPACHUY", ProvinciaId = 8 },
                new Municipio { Nombre = "TOMINA", ProvinciaId = 8 },
                new Municipio { Nombre = "VILLA ALCALA", ProvinciaId = 8 },
                //YAMPARAEZ 9
                new Municipio { Nombre = "TARABUCO", ProvinciaId = 9 },
                new Municipio { Nombre = "YAMPARAEZ", ProvinciaId = 9 },
                //ZUDAÑEZ 10
                new Municipio { Nombre = "VILLA ZUDAÑEZ", ProvinciaId = 10 },
                new Municipio { Nombre = "ICLA", ProvinciaId = 10 },
                new Municipio { Nombre = "PRESTO", ProvinciaId = 10 },
                new Municipio { Nombre = "VILLA MOJOCOYA", ProvinciaId = 10 },
                //Provinciass de TARIJA
                //ANICETO ARCE 11
                new Municipio { Nombre = "PADCAYYA", ProvinciaId = 11 },
                new Municipio { Nombre = "BERMEJO", ProvinciaId = 11 },
                //AVILES 12
                new Municipio { Nombre = "URIONDO", ProvinciaId = 12 },
                new Municipio { Nombre = "YUNCHARA", ProvinciaId = 12 },
                //CERCADO 13
                new Municipio { Nombre = "TARIJA", ProvinciaId = 13 },
                //GRAN CHACO 14
                new Municipio { Nombre = "YACUIBA", ProvinciaId = 14 },
                new Municipio { Nombre = "CARAPARI", ProvinciaId = 14 },
                new Municipio { Nombre = "VILLAMONTES", ProvinciaId = 14 },
                //MENDEZ 15
                new Municipio { Nombre = "SAN LORENZO", ProvinciaId = 15 },
                new Municipio { Nombre = "EL PUENTE", ProvinciaId = 15 },
                //O'CONOR 16
                new Municipio { Nombre = "ENTRE RIOS", ProvinciaId = 16 },
            };
            foreach (Municipio m in municipios)
            {
                _context.Municipios.Add(m);
            }
            _context.SaveChanges();

            //var usuarios = new ApplicationUser[]
            //{
            //    new ApplicationUser { Ci= 5493245, Nombres = "FRANZ WILLAN", Apellidos = "MARTINEZ CHOQUE" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "ALEXANDRO FAVIO", Apellidos = "AVENDAÑO QUISPE" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "ARIEL JOHNSON", Apellidos = "ROJAS RIVERA" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "BRIGIDA ANGELICA", Apellidos = "NINA TITO" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "CRISTINA", Apellidos = "CENTELLAS RAMOS" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "EDWING", Apellidos = "CORONEL VALENCIA" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "EDGAR", Apellidos = "FLORES HUASCO" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "ELIODORO GONZALO", Apellidos = "ALARCON QUISPE" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "ESTHER RUTH", Apellidos = "QUISPE MIRANDA" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "FLAVIA JAZIEL", Apellidos = "MARIACA GUTIERREZ" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "CARMEN GABRIELA", Apellidos = "TORREZ PAREDES" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "IRENE MARISOL", Apellidos = "CLAURE TORREZ" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "ISRAEL WILFREDO", Apellidos = "NACHO CHOQUE" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "IVAN ORLANDO", Apellidos = "FRIAS PINEDO" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "JANNETTE", Apellidos = "TARIFA MEJILLONES" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "JHASMANY JUAN", Apellidos = "ZAPATA GONZALES" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "JOSE LUIS", Apellidos = "QUISPE UCEDO" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "JOSE MAURICIO", Apellidos = "CASSAS GORENA" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "JUAN MARCOS", Apellidos = "RAMIREZ BELTRAN" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "JUANITO", Apellidos = "APAZA CHINO" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "KARINA LUCY", Apellidos = "GUTIERREZ ZAPANA" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "LOURDES EMILIANA", Apellidos = "LAURA QUISPE" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "LOURDES MARCELA", Apellidos = "ARGANDOÑA ALGODON" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "LOURDES ROSSMERY", Apellidos = "QUISPE APALA" },
            //    new ApplicationUser { Ci= 5493245, Nombres = "MILENA ESTHER", Apellidos = "LAZO AVERANGA" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //    //new ApplicationUser { Ci= 5493245, Nombres = "", Apellidos = "" },
            //};
            //foreach (ApplicationUser u in usuarios)
            //{
            //    _context.Users.Add(u);
            //}
            //_context.SaveChanges();

            //var ubicaciones = new Ubicacion[]
            //{
            //    new Ubicacion { Nombre = "DIRECCION GENERAL DE SANEAMIENTO Y TITULACION" },
            //    new Ubicacion { Nombre = "DIRECCION DEPARTAMENTAL" },
            //    new Ubicacion { Nombre = "SANEAMIENTO REGION VALLES" },
            //    new Ubicacion { Nombre = "UNIDAD DE FISCALIZACION AGRARIA" },
            //    new Ubicacion { Nombre = "UNIDAD DE DESPACHO" },
            //    new Ubicacion { Nombre = "UNIDAD DE JURIDICA" },
            //    new Ubicacion { Nombre = "UNIDAD DE TITULACION" },
            //    new Ubicacion { Nombre = "MINISTERIO DE LA PRESIDENCIA" },
            //    new Ubicacion { Nombre = "OTRAS INSTITUCIONES" }
            //};
            //foreach (Ubicacion ub in ubicaciones)
            //{
            //    _context.Ubicaciones.Add(ub);
            //}
            //_context.SaveChanges();

            //var estados = new Estado[]
            //{
            //    new Estado { Nombre = "TITULADO" },
            //    new Estado { Nombre = "TIERRA FISCAL" },
            //    new Estado { Nombre = "PROCESO NACIONAL" },
            //    new Estado { Nombre = "PARALIZADO NACIONAL" },
            //    new Estado { Nombre = "CONFLICTO NACIONAL" },
            //    new Estado { Nombre = "PROCESO DEPARTAMENTAL" },
            //    new Estado { Nombre = "PARALIZADO DEPARTAMENTAL" },
            //    new Estado { Nombre = "CONFLICTO DEPARTAMENTAL" },
            //    new Estado { Nombre = "AREAS URBANAS" },
            //    new Estado { Nombre = "SERVIDUMBRES DE DOMINIO PUBLICO" }
            //};
            //foreach (Estado es in estados)
            //{
            //    _context.Estados.Add(es);
            //}
            //_context.SaveChanges();

            //var estadoreportes = new EstadoReporte[]
            //{
            //    new EstadoReporte { Nombre = "TITULADO", EstadoId = 1 },
            //    new EstadoReporte { Nombre = "TIERRA FISCAL", EstadoId = 2 },
            //    new EstadoReporte { Nombre = "CONTROL DE CALIDAD Y ELABORACION DE RFS", EstadoId = 3 },
            //    new EstadoReporte { Nombre = "PARA FIRMA DE RFS", EstadoId = 3 },
            //    new EstadoReporte { Nombre = "RFS REMITIDA PARA NOTIFICACION", EstadoId = 3 },
            //    new EstadoReporte { Nombre = "RFS NOTIFICADA", EstadoId = 3 },
            //    new EstadoReporte { Nombre = "RFS PARA REMISION A LA UNIDAD DE TITULACION Y DGAT", EstadoId = 3 },
            //    new EstadoReporte { Nombre = "REMITIDA A OTRAS UNIDADES", EstadoId = 4 },
            //    new EstadoReporte { Nombre = "FALTA DE PAGO DE ADJUDICACION", EstadoId = 4 },
            //    new EstadoReporte { Nombre = "IMPUGNADO ANTE EL TRIBUNAL AGROAMBIENTAL", EstadoId = 4 },
            //    //PrEstadoReporte de TARIJA
            //    new EstadoReporte { Nombre = "FALTA DE DOCUMENTACION", EstadoId = 4 },
            //    new EstadoReporte { Nombre = "SOBREPOSICION CON AREAS URBANAS", EstadoId = 4 },
            //    new EstadoReporte { Nombre = "DEVUELTA DE OTRAS UNIDADES", EstadoId = 4 },
            //    new EstadoReporte { Nombre = "ANALISIS DE OBSERVACIONES DE TITULACION Y DISTRIBUCION DE TIERRAS", EstadoId = 4 },
            //    new EstadoReporte { Nombre = "SUPERFICIE MAYOR A 5000 HECTARIAS", EstadoId = 4 },
            //};
            //foreach (EstadoReporte er in estadoreportes)
            //{
            //    _context.EstadoReportes.Add(er);
            //}
            //_context.SaveChanges();
        }
    }
}
