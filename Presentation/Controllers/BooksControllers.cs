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
        public IActionResult GetAll()
        {
                var books = _manager.BookService.GetAllBooks(false);
                return Ok(books);
        }

        [HttpGet("GetOneBook")]
        public IActionResult Get(int id)
        {
            var book = _manager.BookService.GetOneBookById(id, false);
            return Ok(book);
        }

        [HttpPost("Post")]
        public IActionResult Post(BookDtoForInsertion bookDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            if (bookDto != null)
            {
                _manager.BookService.CreateOneBook(bookDto);
                return StatusCode(201, bookDto);
            }
            return BadRequest();

        }


        [HttpPut("PutWithId")]
        public IActionResult Put(int id, BookDtoForUpdate bookDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            if (bookDto != null)
            {
                _manager.BookService.UpdateOneBook(id, bookDto, false);
                return Ok(bookDto);
            }
            return NotFound();


        }

        [HttpDelete("DeleteWithId")]
        public IActionResult Delete(int id)
        {
            _manager.BookService.DeleteOneBook(id, false);
            return NoContent();
        }
    }
}
