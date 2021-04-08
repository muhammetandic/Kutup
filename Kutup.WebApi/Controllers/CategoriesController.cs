using Kutup.Core.Application.Interfaces.Services;
using Kutup.Core.Domain.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kutup.WebApi.Controllers
{
    public class CategoriesController : ODataController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAsQueryable();
            return Ok(categories);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            var category = _categoryService.GetByIdAsQueryable(key);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            category.Id = (await _categoryService.Create(category)).Id;
            return Created(category);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Category category)
        {
            await _categoryService.Update(category);
            return Updated(category);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            await _categoryService.Delete(key);
            return Ok();
        }


    }
}
