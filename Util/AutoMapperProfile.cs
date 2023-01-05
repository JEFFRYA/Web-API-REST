using AutoMapper;
using WebAPI_CRUD.DTOs;
using WebAPI_CRUD.Models;
using System.Globalization;

namespace WebAPI_CRUD.Util
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            #region Department

            CreateMap<TDepartment, DepartmentDTO>().ReverseMap();

            #endregion

            #region Employee

            CreateMap<TEmployee, EmployeeDTO>()
                .ForMember(
                    destino => destino.NameDepartment,
                    item => item.MapFrom(origen => origen.IdFDepartmentNavigation.Name)
                );

            CreateMap<EmployeeDTO, TEmployee>()
                .ForMember(
                    destino => destino.IdFDepartmentNavigation,
                    item => item.Ignore()
                );

            #endregion

        }
    }
}
