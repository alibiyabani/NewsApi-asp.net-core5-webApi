using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Core.Services.Interfaces;
using NewsApi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            var result = new ObjectResult( _categoryService.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            Request.HttpContext.Response.Headers.Add("X-Provider", "Ma-developer");
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if( await _categoryService.IsExist(id))
            {
                var category =   await _categoryService.Find(id);
                return Ok(category);
            }
            else
            {
                 return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await _categoryService.Add(category);
                return Ok(category);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory ([FromBody] Category category ,[FromRoute] int id)
        {
            await _categoryService.Update(category);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory ([FromRoute] int id)
        {
            await _categoryService.Remove(id);
            return Ok();
        }
    }
}
