using Incidencias.Data.Configurations;
using Incidencias.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Data
{
    public class IncidenciasContext : DbContext
    {
        public IncidenciasContext()
           : base("Incidencias")
       {
            Database.SetInitializer<IncidenciasContext>(null);
        }

        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Aplicacion> AplicacionSet { get; set; }
        public IDbSet<Incidencia> IncidenciaSet { get; set; }
        public IDbSet<Tecnico> TecnicoSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new AplicacionConfiguration());
            modelBuilder.Configurations.Add(new IncidenciaConfiguration());
            modelBuilder.Configurations.Add(new TecnicoConfiguration());
        }
    }
}
