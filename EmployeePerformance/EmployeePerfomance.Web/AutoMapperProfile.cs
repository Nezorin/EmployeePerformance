using AutoMapper;
using EmployeePerfomance.DataAccessLayer.Entities;
using EmployeePerfomance.Web.Models;

namespace EmployeePerfomance.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterUserViewModel, User>(); 
            CreateMap<AddDepartmentViewModel, Department>(); 
            CreateMap<EditUserViewModel, User>();
            CreateMap<User, EditUserViewModel>();
        }
    }
}
