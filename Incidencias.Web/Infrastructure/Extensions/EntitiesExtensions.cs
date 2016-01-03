using Incidencias.Entities;
using Incidencias.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incidencias.Web.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        //public static void UpdateMovie(this Movie movie, MovieViewModel movieVm)
        //{
        //    movie.Title = movieVm.Title;
        //    movie.Description = movieVm.Description;
        //    movie.GenreId = movieVm.GenreId;
        //    movie.Director = movieVm.Director;
        //    movie.Writer = movieVm.Writer;
        //    movie.Producer = movieVm.Producer;
        //    movie.Rating = movieVm.Rating;
        //    movie.TrailerURI = movieVm.TrailerURI;
        //    movie.ReleaseDate = movieVm.ReleaseDate;
        //}

        public static void UpdateAplicacion(this Aplicacion aplicacion, AplicacionViewModel aplicacionVm)
        {
            aplicacion.Nombre = aplicacionVm.Nombre;
            aplicacion.TecnicoId = aplicacionVm.TecnicoId;
            aplicacion.Contacto = aplicacionVm.Contacto;
        }
    }
}