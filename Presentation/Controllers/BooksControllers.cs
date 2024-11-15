using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
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
        public async Task<IActionResult> GetAllAsync([FromQuery]BookParameters bookParameters) //FromQuery ile queryden alindigini bildirdik
        {
            var books =await  _manager.BookService.GetAllBooksAsync(bookParameters,false);
            return Ok(books);
        }

        [HttpGet("GetOneBook")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var book = await _manager.BookService.GetOneBookByIdAsync(id, false);
            return Ok(book);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Post")]
        public async Task<IActionResult> PostAsync(BookDtoForInsertion bookDto)
        {
            var book=await _manager.BookService.CreateOneBookAsync(bookDto);
            return StatusCode(201, book);
        }

        
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("PutWithId")]
        public async Task<IActionResult> PutAsync(int id, BookDtoForUpdate bookDto)
        {

            await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);
            
            return Ok(bookDto);
        }

        [HttpDelete("DeleteWithId")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _manager.BookService.DeleteOneBookAsync(id, false);
            return NoContent();
        }
    }
}
