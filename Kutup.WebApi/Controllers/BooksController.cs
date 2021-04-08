using Kutup.Core.Application.Interfaces.Services;
using Kutup.Core.Domain.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kutup.WebApi.Controllers
{
    public class BooksController : ODataController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [EnableQuery(HandleNullPropagation = HandleNullPropagationOption.False)]
        public IActionResult Get()
        {
            var books = _bookService.GetAsQueryable();
            return Ok(books);
        }

        [EnableQuery(HandleNullPropagation = HandleNullPropagationOption.False)]
        public IActionResult Get(int key)
        {
            var book = _bookService.GetByIdAsQueryable(key);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            book.Id = (await _bookService.Create(book)).Id;
            return Created(book);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Book book)
        {
            await _bookService.Update(book);
            return Updated(book);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            await _bookService.Delete(key);
            return Ok();
        }
    }
}
