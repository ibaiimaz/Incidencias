using System;

namespace Incidencias.Entities
{
    public class Incidencia : IEntityBase
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int AplicacionId { get; set; }
        public virtual Aplicacion Aplicacion { get; set; }
        public string Comentario { get; set; }
        public string Contacto { get; set; }
        public DateTime FechaAlta { get; set; }
        public Estados Estado { get; set; }
        public DateTime FechaCierre { get; set; }
        public int ResponsableId { get; set; }
        public virtual Tecnico Responsable { get; set; }
        public Prioridades Prioridad { get; set; }
    }

    public enum Estados
    {
        PdteGestionar,
        Planificada,
        EnCurso,
        PdteValidacion,
        Cerrada
    }

    public enum Prioridades
    {
        Baja,
        Media,
        Alta,
        Critica
    }
}

    
