using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NewsApi.Core.Services.Interfaces;
using NewsApi.DataLayer.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNews()
        {

            var result =  new ObjectResult(await _newsService.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            Request.HttpContext.Response.Headers.Add("X-Provider", "Ma-developer");
            return  result;
        }

        [Route("search/{term}")]
        [HttpGet]
        public async Task<IActionResult> Search([FromRoute] string term)
        {
            try
            {
                var result = await _newsService.Search(term);
                if (result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");

            }
     
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNews([FromRoute] int id)
        {

            if (await _newsService.IsExist(id))
            {
                var news = await _newsService.Find(id);
                return Ok(news);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNews([FromBody] News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await _newsService.Add(news);
            }

            return Ok(news);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditNews([FromRoute] int id, [FromBody] News news)
        {
            await _newsService.Update(news);
            return Ok(news);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveNews([FromRoute] int id)
        {
            await _newsService.Remove(id);
            return Ok();
        }
    }
}
