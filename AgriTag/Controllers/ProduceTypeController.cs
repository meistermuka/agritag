using AgriTag.Commands;
using AgriTag.Common.Helpers;
using AgriTag.Data.DAL;
using AgriTag.Dtos;
using AgriTag.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMediator _mediator;

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

        public ProduceTypeController(IProduceTypeRepository produceTypeRepository, ILogger<ProduceTypeController> logger, IMediator mediator)
        {
            _produceTypeRepository = produceTypeRepository;
            _logger = logger;
            _mediator = mediator;
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
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var query = new GetProduceTypeQuery(id);
                var produceType = await _mediator.Send(query);
                if (produceType == null)
                {
                    return new NotFoundObjectResult(HttpStatusCode.NotFound);
                }
                return new OkObjectResult(produceType);
            }
            catch (Exception ex)
            {
                return _GenericErrorProcessor("Something went wrong", ex);
            }
            
        }

        // POST api/<ProduceTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProduceTypeDto produceType)
        {
            try
            {
                var query = new AddProduceTypeQuery(produceType);
                await _mediator.Send(query);

                return new OkResult();
            }
            catch(Exception ex)
            {
                return _GenericErrorProcessor(ex.Message, ex);
            }
        }

        // PATCH api/<ProduceTypeController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ProduceType> patchDocument)
        {
            try
            {
                if (!ControllerHelpers.ContainsValidProduceTypeJsonPatchPath(patchDocument))
                {
                    _logger.LogError("PATCH contains invalid path to update");
                    return new BadRequestObjectResult(HttpStatusCode.BadRequest);
                }
                var documentToPatch = await _produceTypeRepository.GetProduceTypeByID(id);
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
