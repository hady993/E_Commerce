using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
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
        public async Task<IActionResult> add(CategoryDTO categoryDTO)
        {
            try
            {
                var category = new Category()
                {
                    Name = categoryDTO.Name,
                    Description = categoryDTO.Description
                };
                await work.CategoryRepository.AddAsync(category);
                
                return Ok(new { message = "New item has been added" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> update(UpdateCategoryDTO updateCategoryDTO)
        {
            try
            {
                var category = new Category()
                {
                    Name = updateCategoryDTO.Name,
                    Description = updateCategoryDTO.Description,
                    Id = updateCategoryDTO.id
                };
                await work.CategoryRepository.UpdateAsync(category);

                return Ok(new { message = "New item has been updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                await work.CategoryRepository.DeleteAsync(id);

                return Ok(new { message = "New item has been deleted" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
