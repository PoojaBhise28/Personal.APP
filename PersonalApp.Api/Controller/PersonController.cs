using Microsoft.AspNetCore.Mvc;
using PersonalApp.Dto;
using PersonalApp.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalApp.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService ;

        public PersonController(IPersonService personService)
        {
            _personService = personService ;
        }


        // GET: api/<PersonController>
        [HttpGet]
        public async Task< IEnumerable<GetPerson>> Get()
        {
            return await _personService.GetPerson();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<GetPerson> Get(int id)
        {
            return await _personService.GetPersonByIdAsync(id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<GetPerson> Post([FromBody] CreatePerson persondto)
        {
            return await _personService.CreatePersonAsync(persondto);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<GetPerson> Put(int id, [FromBody] UpdatePerson persondto)
        {
            return await _personService.UpdatePersonAsync(id, persondto);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _personService.DeletePersonAsync(id);
        }
    }
}
