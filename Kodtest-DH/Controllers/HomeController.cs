using Kodtest_DH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Kodtest_DH.Services;

namespace Kodtest_DH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPersonService _personService;

        public HomeController(ILogger<HomeController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> PersonalList()
        {
            IEnumerable<PersonViewModel> personsToView = await _personService.GetPersons();
            return PartialView(personsToView);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(phoneNumber))
            {
                var personToAdd = new PersonViewModel(name, phoneNumber);
                await _personService.CreateNewPerson(personToAdd);
            }

            var personsToView = await _personService.GetPersons();
            
            return PartialView("PersonalList", personsToView);
        }
    }
}
