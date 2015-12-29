using AutoMapper;
using Incidencias.Entities;
using Incidencias.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incidencias.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base("DomainToViewModelMappings")
        { }

        //public override string ProfileName
        //{
        //    get { return "DomainToViewModelMappings"; }
        //}

        protected override void Configure()
        {
            Mapper.CreateMap<Incidencia, IncidenciaViewModel>()
                .ForMember(vm => vm.Aplicacion, map => map.MapFrom(m => m.Aplicacion.Nombre))
                .ForMember(vm => vm.AplicacionId, map => map.MapFrom(m => m.Aplicacion.ID))
                .ForMember(vm => vm.Estado, map => map.MapFrom(m => m.Estado.ToString()))
                .ForMember(vm => vm.Tecnico, map => map.MapFrom(m => m.Tecnico.Nombre))
                .ForMember(vm => vm.TecnicoId, map => map.MapFrom(m => m.Tecnico.ID))
                .ForMember(vm => vm.Prioridad, map => map.MapFrom(m => m.Prioridad.ToString()));

            Mapper.CreateMap<Aplicacion, AplicacionViewModel>()
                .ForMember(vm => vm.NumeroIncidencias, map => map.MapFrom(g => g.Incidencias.Count()));

            Mapper.CreateMap<Tecnico, TecnicoViewModel>()
                .ForMember(vm => vm.NumeroIncidencias, map => map.MapFrom(g => g.Incidencias.Count()));
        }
    }
}