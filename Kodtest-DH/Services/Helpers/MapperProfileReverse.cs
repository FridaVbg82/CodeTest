using AutoMapper;
using Kodtest_DH.Models;
using Kodtest_DH.Repository;

namespace Kodtest_DH.Services;

public class MapperProfileReverse : Profile
{
    public MapperProfileReverse()
    {
        CreateMap<PersonViewModel, Person>();
    }
}