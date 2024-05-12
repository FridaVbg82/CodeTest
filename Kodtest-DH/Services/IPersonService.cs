using Kodtest_DH.Models;

namespace Kodtest_DH.Services
{
    public interface IPersonService
    {
        public Task CreateNewPerson(PersonViewModel personViewModel);
        public Task<List<PersonViewModel>> GetPersons();
    }
}