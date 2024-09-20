using Admin.Commons.Dto;
using Admin.Data.Entities;
using AutoMapper;

namespace WebApi.Core.Automapper
{
    public class AdminProfile: Profile
    {
        public AdminProfile() 
        {
            base.CreateMap<TblEmployee, EmployeeDTO>().ReverseMap();
            base.CreateMap<EmployeeDTO, TblEmployee>()
                .ForMember(e => e.Identificacion, x => x.MapFrom(a => a.Identificacion))
                .ForMember(e => e.Posicion, x => x.MapFrom(a => a.Posicion))
                .ForMember(e => e.Descripcion, x => x.MapFrom(a => a.Descripcion))
                .ForMember(e => e.Estado, x => x.MapFrom(a => a.Estado));
        }       

    }
}
