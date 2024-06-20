using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllAsync()
        {
            var books =await  _manager.BookService.GetAllBooksAsync(false);
            return Ok(books);
        }

        [HttpGet("GetOneBook")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var book = await _manager.BookService.GetOneBookByIdAsync(id, false);
            return Ok(book);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> PostAsync(BookDtoForInsertion bookDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            if (bookDto != null)
            {
                await _manager.BookService.CreateOneBookAsync(bookDto);
                return StatusCode(201, bookDto);
            }
            return BadRequest();

        }


        [HttpPut("PutWithId")]
        public async Task<IActionResult> PutAsync(int id, BookDtoForUpdate bookDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            if (bookDto != null)
            {
                await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);
                return Ok(bookDto);
            }
            return NotFound();


        }

        [HttpDelete("DeleteWithId")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _manager.BookService.DeleteOneBookAsync(id, false);
            return NoContent();
        }
    }
}
