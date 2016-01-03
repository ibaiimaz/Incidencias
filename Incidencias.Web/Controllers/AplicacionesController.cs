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
        [HttpGet]
        [Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
        public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Aplicacion> aplicaciones = null;
                int totalAplicaciones = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    filter = filter.Trim().ToLower();

                    aplicaciones = _aplicacionesRepository.GetAll()
                        .OrderBy(c => c.ID)
                        .Where(c => c.Nombre.ToLower().Contains(filter))
                        .ToList();
                }
                else
                {
                    aplicaciones = _aplicacionesRepository.GetAll().ToList();
                }

                totalAplicaciones = aplicaciones.Count();
                aplicaciones = aplicaciones.Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                IEnumerable<AplicacionViewModel> aplicacionVM = Mapper.Map<IEnumerable<Aplicacion>, IEnumerable<AplicacionViewModel>>(aplicaciones);

                PaginationSet<AplicacionViewModel> pagedSet = new PaginationSet<AplicacionViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalAplicaciones,
                    TotalPages = (int)Math.Ceiling((decimal)totalAplicaciones / currentPageSize),
                    Items = aplicacionVM
                };

                response = request.CreateResponse<PaginationSet<AplicacionViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
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

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(HttpRequestMessage request, AplicacionViewModel aplicacion)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    Aplicacion newAplicacion = new Aplicacion();
                    newAplicacion.UpdateAplicacion(aplicacion);
                    _aplicacionesRepository.Add(newAplicacion);

                    _unitOfWork.Commit();

                    // Update view model
                    aplicacion = Mapper.Map<Aplicacion, AplicacionViewModel>(newAplicacion);
                    response = request.CreateResponse<AplicacionViewModel>(HttpStatusCode.Created, aplicacion);
                }

                return response;
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, AplicacionViewModel aplicacion)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    Aplicacion _aplicacion = _aplicacionesRepository.GetSingle(aplicacion.ID);
                    _aplicacion.UpdateAplicacion(aplicacion);

                    _unitOfWork.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
    }
}