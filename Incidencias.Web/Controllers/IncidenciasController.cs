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
    [RoutePrefix("api/incidencias")]
    public class IncidenciasController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Incidencia> _incidenciasRepository;

        public IncidenciasController(IEntityBaseRepository<Incidencia> indicenciasRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
        : base(_errorsRepository, _unitOfWork)
    {
            _incidenciasRepository = indicenciasRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var incidencias = _incidenciasRepository.GetAll().OrderByDescending(m => m.FechaAlta).Take(6).ToList();

                IEnumerable<IncidenciaViewModel> incidenciaVM = Mapper.Map<IEnumerable<Incidencia>, IEnumerable<IncidenciaViewModel>>(incidencias);

                response = request.CreateResponse<IEnumerable<IncidenciaViewModel>>(HttpStatusCode.OK, incidenciaVM);

                return response;
            });
        }
    }
}