using AutoMapper;
using Kodtest_DH.Models;
using Kodtest_DH.Repository;
using Microsoft.EntityFrameworkCore;

namespace Kodtest_DH.Services;

public class PersonService : IPersonService
{
    private CodetestDbContext _context;
    private IMapper _mapper;

    public PersonService(CodetestDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateNewPerson(PersonViewModel personViewModel)
    {
        var person = new Person
        {
            Name = personViewModel.Name,
            PhoneNumber = personViewModel.PhoneNumber
        };
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PersonViewModel>> GetPersons()
    {
        var list = await _context.Persons.ToListAsync();
        List<PersonViewModel> mapped = _mapper.Map<List<PersonViewModel>>(list);
        return mapped;
    }
}