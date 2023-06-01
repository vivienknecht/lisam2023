using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static List<Person> people = new List<Person>()
        {
            new Person() { ID = Guid.NewGuid(), Name = "Gica", DateOfBirth = DateTime.Now },
            new Person() { ID = Guid.NewGuid(), Name = "Aurel", DateOfBirth = DateTime.Now },
            new Person() { ID = Guid.NewGuid(), Name = "Maria", DateOfBirth = DateTime.Now },
        };

        // GET: api/<PeopleController>
        [HttpGet]
        public Person[] Get()
        {
            return people.ToArray();
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public Person Get(Guid id)
        {
            
            return people.FirstOrDefault(x => x.ID == id);
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            people.Add(person);
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Person person)
        {
           var  personn = people.FirstOrDefault(x => x.ID == id);
            if (personn != null)
            {
                personn.Name = person.Name;
                personn.DateOfBirth = person.DateOfBirth;
            }
           
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var person = people.FirstOrDefault(x => x.ID == id);

            if(person != null)
            {
                people.Remove(person);
            }
        }
    }
}
