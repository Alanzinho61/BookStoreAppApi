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
            try
            {
                var books = _manager.BookService.GetAllBooks(false);
                return Ok(books);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        [HttpGet("GetOneBook")]
        public IActionResult Get(int id)
        {
            var book = _manager.BookService.GetOneBookById(id, false);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("Post")]
        public IActionResult Post(Book b)
        {
            try
            {
                if (b != null)
                {
                    _manager.BookService.CreateOneBook(b);
                    return StatusCode(201, b);
                }
                return BadRequest();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        [HttpPut("PutWithId")]
        public IActionResult Put(int id, Book b)
        {
            try
            {
                if (b != null)
                {
                    _manager.BookService.UpdateOneBook(id, b, true);
                    return Ok(b);
                }
                return NotFound();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        [HttpDelete("DeleteWithId")]
        public IActionResult Delete(int id)
        {

            var delete = _manager.BookService.GetOneBookById(id, false);
            try
            {
                _manager.BookService.DeleteOneBook(id, false);
                return Ok();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
