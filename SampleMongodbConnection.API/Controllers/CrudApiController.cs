using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleMongodbConnection.API.DTO;
using SampleMongodbConnection.API.Services;

namespace SampleMongodbConnection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudApiController : ControllerBase
    {
        private readonly ICrudApiService _crudApiService;

        public CrudApiController(ICrudApiService crudApiService)
        {
            this._crudApiService = crudApiService;
        }

        // create
        [HttpPost("Create")]
        public IActionResult CreateOne(CrudRequest crudRequest)
        {
            var response = _crudApiService.CreateOne(crudRequest);
            return Ok(response);
        }

        // read
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _crudApiService.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] CrudRequest crudRequest)
        {
            var response = _crudApiService.GetById(crudRequest);
            return Ok(response);
        }

        // update
        // delete

    }
}
