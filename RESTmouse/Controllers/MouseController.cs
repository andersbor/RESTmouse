using Microsoft.AspNetCore.Mvc;
using RESTmouse.Model;

namespace RESTmouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MouseController : ControllerBase
    {
        private MouseRepository repository = new MouseRepository();

        // TODO dependency injection

        // GET: api/<MouseController>
        [HttpGet]
        public IEnumerable<Mouse> Get()
        {
            return repository.GetAll();
        }

        // GET api/<MouseController>/5
        [HttpGet("{id}")]
        // TODO status codes
        public Mouse? Get(int id)
        {
            return repository.GetById(id);
        }

        // POST api/<MouseController>
        [HttpPost]
        public Mouse Post([FromBody] Mouse value)
        {
            Mouse mouse = repository.Add(value);
            return mouse;
        }

        // DELETE api/<MouseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
