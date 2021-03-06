﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Entities
{
    public class Aplicacion : IEntityBase
    {
        public Aplicacion()
        {
            Incidencias = new List<Incidencia>();
        }

        public int ID { get; set; }
        public string Nombre { get; set; }
        public int TecnicoId { get; set; }
        public virtual Tecnico Tecnico { get; set; }
        public string Contacto { get; set; }
        public virtual ICollection<Incidencia> Incidencias { get; set; }

    }
}
