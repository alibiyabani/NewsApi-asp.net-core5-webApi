using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Core.Services.Interfaces;
using NewsApi.DataLayer.Models;
using System.Net;
using System.Threading.Tasks;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        private ISourceService _sourceService;

        public SourceController(ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        [HttpGet]
        public IActionResult GetSource()
        {
            var result = new ObjectResult(_sourceService.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            Request.HttpContext.Response.Headers.Add("X-Provider", "Ma-developer");
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSource([FromRoute] int id)
        {
            if (await _sourceService.IsExist(id))
            {
                var source = await _sourceService.Find(id);
                return Ok(source);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSource([FromBody] Source source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await _sourceService.Add(source);
                return Ok(source);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSource([FromBody] Source source,[FromRoute] int id)
        {
            await _sourceService.Update(source);
            return Ok(source);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            await _sourceService.Remove(id);
            return Ok(id);
        }
    }
}
