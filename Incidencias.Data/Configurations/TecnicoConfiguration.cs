using Incidencias.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Data.Configurations
{
    public class TecnicoConfiguration : EntityBaseConfiguration<Tecnico>
    {
        public TecnicoConfiguration()
        {
            Property(g => g.Iniciales).IsRequired().HasMaxLength(4);
            Property(g => g.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}
