using FluentValidation;
using Incidencias.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incidencias.Web.Infrastructure.Validators
{
    public class AplicacionViewModelValidator : AbstractValidator<AplicacionViewModel>
    {
        public AplicacionViewModelValidator()
        {
            RuleFor(aplicacion => aplicacion.Nombre).NotEmpty()
                .Length(1, 50).WithMessage("La longitud dek Nombre tiene que estar ente 1 y 50");    
        }
    }
}