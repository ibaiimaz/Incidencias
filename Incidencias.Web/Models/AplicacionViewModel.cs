﻿using Incidencias.Web.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Incidencias.Web.Models
{
    public class AplicacionViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int NumeroIncidencias { get; set; }
        public int TecnicoId { get; set; }
        public string Tecnico { get; set; }
        public string Contacto { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new AplicacionViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}