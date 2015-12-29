using FluentValidation;
using Incidencias.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incidencias.Web.Infrastructure.Validators
{
    public class IncidenciaViewModelValidator : AbstractValidator<IncidenciaViewModel>
    {
        public IncidenciaViewModelValidator()
        {
            RuleFor(incidencia => incidencia.Titulo).NotEmpty().Length(1, 100)
                .WithMessage("Introduce Título");

            RuleFor(incidencia => incidencia.Descripcion).NotEmpty().Length(1, 2000)
                .WithMessage("Introduce Descripción");

            RuleFor(incidencia => incidencia.AplicacionId).GreaterThan(0)
                .WithMessage("Selecciona Aplicación");

            RuleFor(incidencia => incidencia.Comentario).Length(1, 2000)
                .WithMessage("Comentario demasiado largo");

            RuleFor(incidencia => incidencia.Contacto).NotEmpty().Length(1,100)
                .WithMessage("Introduce Contacto");

            RuleFor(incidencia => incidencia.FechaAlta).NotEmpty()
                .WithMessage("Introduce Fecha Alta");

            RuleFor(incidencia => incidencia.Estado).NotEmpty()
                .WithMessage("Selecciona Estado");

            RuleFor(incidencia => incidencia.TecnicoId).GreaterThan(0)
                .WithMessage("Selecciona Técnico");

            RuleFor(incidencia => incidencia.Prioridad).NotEmpty()
                .WithMessage("Selecciona Prioridad");
        }
    }
}