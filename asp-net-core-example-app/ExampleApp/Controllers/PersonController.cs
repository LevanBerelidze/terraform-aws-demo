using ExampleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApp.Controllers
{
    [ApiController]
    public class PersonController : Controller
    {
        private readonly AppDbContext dbContext;

        public PersonController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("api/persons")]
        public List<Person> GetAllPersons()
        {
            return dbContext.Persons.ToList();
        }

        [HttpGet("api/persons/{id:int}", Name = "GetPerson")]
        public IActionResult GetPerson(int id)
        {
            Person person = dbContext.Persons.FirstOrDefault(p => p.Id == id);
            if (person is null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost("api/persons")]
        public IActionResult CreatePerson(Person person)
        {
            dbContext.Add(person);
            dbContext.SaveChanges();
            return CreatedAtAction("GetPerson", new { id = person.Id }, null);
        }
    }
}
