using Incidencias.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Data.Configurations
{
    public class AplicacionConfiguration : EntityBaseConfiguration<Aplicacion>
    {
        public AplicacionConfiguration()
        {
            Property(g => g.Nombre).IsRequired().HasMaxLength(50);
            Property(m => m.TecnicoId).IsRequired();
            Property(m => m.Contacto).IsRequired().HasMaxLength(100);
        }
    }
}
