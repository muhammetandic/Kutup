using Kutup.Core.Application.Interfaces.Services;
using Kutup.Core.Domain.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kutup.WebApi.Controllers
{
    public class AuthorsController : ODataController
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var authors = _authorService.GetAsQueryable();
            return Ok(authors);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            var author = _authorService.GetByIdAsQueryable(key);
            if (author is null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author author)
        {
            author.Id = (await _authorService.Create(author)).Id;
            return Created(author);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Author author)
        {
            await _authorService.Update(author);
            return Updated(author);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            await _authorService.Delete(key);
            return Ok();
        }
    }
}
