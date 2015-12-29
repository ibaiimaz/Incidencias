using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Incidencias.Web.Models
{
    public class IncidenciaViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int AplicacionId { get; set; }
        public string Aplicacion { get; set; }
        public string Comentario { get; set; }
        public string Contacto { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCierre { get; set; }
        public int TecnicoId { get; set; }
        public string Tecnico { get; set; }
        public string Prioridad { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}