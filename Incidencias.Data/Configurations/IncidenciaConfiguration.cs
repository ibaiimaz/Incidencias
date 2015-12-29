using Incidencias.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Data.Configurations
{
    public class IncidenciaConfiguration : EntityBaseConfiguration<Incidencia>
    {
        public IncidenciaConfiguration()
        {
            Property(m => m.Titulo).IsRequired().HasMaxLength(100);
            Property(m => m.Descripcion).IsRequired().HasMaxLength(2000);
            Property(m => m.AplicacionId).IsRequired();
            Property(m => m.Comentario).HasMaxLength(2000);
            Property(m => m.Contacto).IsRequired().HasMaxLength(100);
            Property(m => m.FechaAlta).IsRequired();
            Property(m => m.Estado).IsRequired();
            Property(m => m.TecnicoId).IsRequired();
            Property(m => m.Prioridad).IsRequired();
            Property(r => r.FechaCierre).IsOptional();
        }
    }
}
