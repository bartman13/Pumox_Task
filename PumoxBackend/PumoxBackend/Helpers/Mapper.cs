using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PumoxBackend.DataTransferObject;
using PumoxBackend.Models;

namespace BackEnd.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeTransfer, Employee>()
                .ReverseMap();
            CreateMap<CompanyTransfer,Company>()
                   .ForMember(dest => dest.Employees, act => act.MapFrom(src => src.Employees))
                   .ReverseMap();
           

        }
    }
}