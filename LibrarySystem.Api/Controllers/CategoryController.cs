using AutoMapper;
using LibrarySystem.Api.Dtos.Category;
using LibrarySystem.Api.Helper;
using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = await _unitOfWork.CategoryRepository.GetAllAsync();
                var result = _mapper.Map<List<CategoryDto>>(query);
                return Ok(new ResponseApi<IReadOnlyList<CategoryDto>>(200, result));
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
                var result = await _unitOfWork.CategoryRepository.GetById(id);

                return Ok(new ResponseApi<Category>(200, result));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddCategoryDto addCategory)
        {
            try
            {
                if (addCategory != null)
                {
                    var result = _mapper.Map<Category>(addCategory);
                    await _unitOfWork.CategoryRepository.AddAsync(result);
                    return Ok(new ResponseApi<Category>(201, result));
                }
                else
                {
                    return BadRequest((new ResponseApi<Category>(400, new Category())));
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto updateCategory)
        {
            try
            {
                if (updateCategory != null)
                {
                    var existingCategory = await _unitOfWork.CategoryRepository.GetById(id);
                    if (existingCategory == null) return NotFound($"the category with Id= {id} not found");
                    // var result = _mapper.Map<Book>(updateBook);
                    _mapper.Map(updateCategory, existingCategory);
                    await _unitOfWork.CategoryRepository.UpdateAsync(existingCategory);
                    return Ok(new ResponseApi<Category>(200, existingCategory, "category updated successfully"));
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
                await _unitOfWork.CategoryRepository.DeleteAsync(id);
                return Ok(new ResponseApi<Category>(200, new Category(), "category Deleted successfully"));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }


}
