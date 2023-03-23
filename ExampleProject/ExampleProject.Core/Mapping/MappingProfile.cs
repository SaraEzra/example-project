using AutoMapper;
using ExampleProject.Core.Models;
using ExampleProject.Core.Resources;

namespace ExampleProject.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeResource>().ReverseMap();
        }

    }
}
