using AgriTag.Data;
using AgriTag.Data.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgriTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceTypeController : ControllerBase
    {
        private IProduceTypeRepository _produceTypeRepository = null;

        public ProduceTypeController(IProduceTypeRepository produceTypeRepository)
        {
            _produceTypeRepository = produceTypeRepository;
        }
        // GET: api/<ProduceTypeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProduceTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProduceTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProduceTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProduceTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
