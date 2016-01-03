using AutoMapper;
using Incidencias.Web.Infrastructure.Core;
using Incidencias.Data.Infrastructure;
using Incidencias.Data.Repositories;
using Incidencias.Entities;
using Incidencias.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Incidencias.Web.Infrastructure.Extensions;

namespace Incidencias.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/tecnicos")]
    public class TecnicosController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Tecnico> _tecnicosRepository;

        public TecnicosController(IEntityBaseRepository<Tecnico> tecnicosRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
        : base(_errorsRepository, _unitOfWork)
        {
            _tecnicosRepository = tecnicosRepository;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var tecnicos = _tecnicosRepository.GetAll().ToList();

                IEnumerable<TecnicoViewModel> tecnicoVM = Mapper.Map<IEnumerable<Tecnico>, IEnumerable<TecnicoViewModel>>(tecnicos);

                response = request.CreateResponse<IEnumerable<TecnicoViewModel>>(HttpStatusCode.OK, tecnicoVM);

                return response;
            });
        }
    }
}