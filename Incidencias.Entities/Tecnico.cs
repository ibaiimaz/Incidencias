using System.Collections.Generic;

namespace Incidencias.Entities
{
    public class Tecnico : IEntityBase
    {
        public Tecnico()
        {
            Incidencias = new List<Incidencia>();
        }

        public int ID { get; set; }
        public string Iniciales { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Incidencia> Incidencias { get; set; }
    }
}