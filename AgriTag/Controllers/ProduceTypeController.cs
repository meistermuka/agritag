using AgriTag.Common.Helpers;
using AgriTag.Data;
using AgriTag.Data.DAL;
using AgriTag.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Serilog.Debugging;
using System.Data;
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

        // PATCH api/<ProduceTypeController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(string id, [FromBody] JsonPatchDocument<ProduceType> patchDocument)
        {
            try
            {
                if (!ControllerHelpers.ContainsValidProduceTypeJsonPatchPath(patchDocument))
                {
                    _logger.LogError("PATCH contains invalid path to update");
                    return new BadRequestObjectResult(HttpStatusCode.BadRequest);
                }
                var documentToPatch = _produceTypeRepository.GetProduceTypeByID(id);
                if (documentToPatch == null)
                {
                    _logger.LogError("Unable to find document to PATCH");
                    return new NotFoundObjectResult(HttpStatusCode.NotFound);
                }
                patchDocument.ApplyTo(documentToPatch);
                _produceTypeRepository.Save();
                return new OkObjectResult(documentToPatch);
                
            }
            catch (Exception ex)
            {
                return _GenericErrorProcessor(ex.Message, ex);
            }
        }

        // DELETE api/<ProduceTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var produceTypeToDelete = _produceTypeRepository.GetProduceTypeByID(id);
                if (produceTypeToDelete == null)
                {
                    _logger.LogError("Unable to find produceType to DELETE");
                    return new NotFoundObjectResult(HttpStatusCode.NotFound);
                }
                _produceTypeRepository.DeleteProduceTypeByID(id);
                _produceTypeRepository.Save();
                return new OkObjectResult(produceTypeToDelete);
            }
            catch (Exception ex)
            {
                return _GenericErrorProcessor(ex.Message, ex);
            }
        }
    }
}
