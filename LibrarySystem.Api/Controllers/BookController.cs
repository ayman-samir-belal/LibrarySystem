using AutoMapper;
using LibrarySystem.Api.Dtos.Book;
using LibrarySystem.Api.Helper;
using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = await _unitOfWork.BookRepository.GetAllAsync();
                var result = _mapper.Map<List<BookDto>>(query);
                return Ok(new ResponseApi<IReadOnlyList<BookDto>>(200, result));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetById/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.BookRepository.GetById(id);

                return Ok(new ResponseApi<Book>(200, result));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddBookDto addBook)
        {
            try
            {
                if (addBook != null)
                {
                    var result = _mapper.Map<Book>(addBook);
                    await _unitOfWork.BookRepository.AddAsync(result);
                    return Ok(new ResponseApi<Book>(201, result));
                }
                else
                {

                    return BadRequest((new ResponseApi<Book>(400, new Book())));
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookDto updateBook)
        {
            try
            {
                if (updateBook != null)
                {
                    var existingBook = await _unitOfWork.BookRepository.GetById(id);
                    if (existingBook == null) return NotFound($"the book with Id= {id} not found");
                    // var result = _mapper.Map<Book>(updateBook);
                    _mapper.Map(updateBook, existingBook);
                    await _unitOfWork.BookRepository.UpdateAsync(existingBook);
                    return Ok(new ResponseApi<Book>(200, existingBook, "Book updated successfully"));
                }
                else
                {

                    return BadRequest((new ResponseApi<Book>(400, new Book())));
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _unitOfWork.BookRepository.DeleteAsync(id);
                return Ok(new ResponseApi<Book>(200, new Book(), "Book Deleted successfully"));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
