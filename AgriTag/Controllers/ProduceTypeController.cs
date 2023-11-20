using AgriTag.Data;
using AgriTag.Data.DAL;
using AgriTag.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog.Debugging;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgriTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceTypeController : ControllerBase
    {
        private IProduceTypeRepository _produceTypeRepository;
        private readonly ILogger<ProduceTypeController> _logger;

        private IActionResult _GenericErrorProcessor(string errorMessage, Exception ex)
        {
            _logger.LogError("{errorMessage}: {exception}", errorMessage, ex);
            return new ContentResult
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Content = errorMessage,
                ContentType = "text/plain"
            };
        }

        public ProduceTypeController(IProduceTypeRepository produceTypeRepository, ILogger<ProduceTypeController> logger)
        {
            _produceTypeRepository = produceTypeRepository;
            _logger = logger;
        }
        // GET: api/<ProduceTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new OkObjectResult(_produceTypeRepository.GetProduceTypes());
            }
            catch (Exception ex)
            {
                return _GenericErrorProcessor(ex.Message, ex);
            }
        }

        // GET api/<ProduceTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                ProduceType theReturn = _produceTypeRepository.GetProduceTypeByID(id);
                if (theReturn == null)
                {
                    return new NotFoundObjectResult(HttpStatusCode.NotFound);
                }
                return new OkObjectResult(theReturn);
            }
            catch (Exception ex)
            {
                return _GenericErrorProcessor(ex.Message, ex);
            }
            
        }

        // POST api/<ProduceTypeController>
        [HttpPost]
        public IActionResult Post([FromBody] ProduceType produceType)
        {
            try
            {
                _produceTypeRepository.InsertProduceType(produceType);
                _produceTypeRepository.Save();

                return new OkObjectResult(produceType);
            }
            catch(Exception ex)
            {
                return _GenericErrorProcessor(ex.Message, ex);
            }
        }

        // PUT api/<ProduceTypeController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value)
        {
        }

        // DELETE api/<ProduceTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
