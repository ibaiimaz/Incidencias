namespace Incidencias.Data.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IncidenciasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IncidenciasContext context)
        {
            // create Tecnicos
            context.TecnicoSet.AddOrUpdate(m => m.Iniciales, GenerarTecnicos());

            //  create Aplicaciones
            context.AplicacionSet.AddOrUpdate(g => g.Nombre, GenerarAplicaciones());
           
            //// create Incidencias
            context.IncidenciaSet.AddOrUpdate(GenerarIncidencias());

            // create roles
            context.RoleSet.AddOrUpdate(r => r.Name, GenerateRoles());

            // username: chsakell, password: Incidencias
            context.UserSet.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    Email="ibaiimaz@gmail.com",
                    Username="ibaiimaz",
                    HashedPassword ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                }
            });

            // // create user-admin for chsakell
            context.UserRoleSet.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    RoleId = 1,
                    UserId = 1
                }
            });
        }
                
        private Tecnico[] GenerarTecnicos()
        {
            Tecnico[] movies = new Tecnico[] {
                new Tecnico()
                {
                    ID = 1,
                    Iniciales ="JDD",
                    Nombre ="John Doe"
                },
                new Tecnico()
                {
                    ID = 2,
                    Iniciales ="CAA",
                    Nombre ="Carley Anderson"
                },
                new Tecnico()
                {
                    ID = 3,
                    Iniciales ="DKK",
                    Nombre ="Darby Kihn"
                }
            };

            return movies;
        }

        private Aplicacion[] GenerarAplicaciones()
        {
            Aplicacion[] genres = new Aplicacion[] {
                new Aplicacion() { ID = 1, Nombre = "Compras", TecnicoId = 3, Contacto = "Contacto 1" },
                new Aplicacion() { ID = 2, Nombre = "Ventas", TecnicoId = 3, Contacto = "Contacto 2" },
                new Aplicacion() { ID = 3, Nombre = "RRHH", TecnicoId = 3, Contacto = "Contacto 3" }
            };

            return genres;
        }

        private Incidencia[] GenerarIncidencias()
        {
            Incidencia[] incidencias = new Incidencia[] {
                    new Incidencia()
                    {
                        AplicacionId = 7,
                        Titulo = "Error generación pedido",
                        Descripcion = "Al ir a crear un pedido a dado un error",
                        Contacto = "John Smith",
                        Estado = Estados.PdteGestionar,
                        FechaAlta = DateTime.Now,
                        Prioridad = Prioridades.Media,
                        TecnicoId = 1,
                        FechaCierre = DateTime.Now
                    }
            };

            return incidencias;
        }

        private Role[] GenerateRoles()
        {
            Role[] _roles = new Role[]{
                new Role()
                {
                    Name="Admin"
                }
            };

            return _roles;
        }
    }
}
