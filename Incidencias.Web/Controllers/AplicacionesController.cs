using AutoMapper;
using Incidencias.Data.Infrastructure;
using Incidencias.Data.Repositories;
using Incidencias.Entities;
using Incidencias.Web.Infrastructure.Core;
using Incidencias.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Incidencias.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/aplicaciones")]
    public class AplicacionesController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Aplicacion> _aplicacionesRepository;

        public AplicacionesController(IEntityBaseRepository<Aplicacion> aplicacionesRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
        : base(_errorsRepository, _unitOfWork)
    {
            _aplicacionesRepository = aplicacionesRepository;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var aplicaciones = _aplicacionesRepository.GetAll().ToList();

                IEnumerable<AplicacionViewModel> aplicacionVM = Mapper.Map<IEnumerable<Aplicacion>, IEnumerable<AplicacionViewModel>>(aplicaciones);

                response = request.CreateResponse<IEnumerable<AplicacionViewModel>>(HttpStatusCode.OK, aplicacionVM);

                return response;
            });
        }
    }
}