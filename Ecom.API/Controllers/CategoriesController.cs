using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Ecom.API.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work) : base(work)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> get()
        {
            try
            {
                var category = await work.CategoryRepository.GetAllAsync();
                if (category is null)
                    return BadRequest();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var category = await work.CategoryRepository.GetByIdAsync(id);
                if (category is null)
                    return BadRequest();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> add(CategoryDTO category)
        {
            try
            {
                var category = await work.CategoryRepository.GetByIdAsync(id);
                if (category is null)
                    return BadRequest();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
