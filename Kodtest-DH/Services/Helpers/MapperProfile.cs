using AutoMapper;
using Kodtest_DH.Models;
using Kodtest_DH.Repository;

namespace Kodtest_DH.Services;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Person, PersonViewModel>();
    }
}