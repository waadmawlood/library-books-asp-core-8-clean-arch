using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoryController(ICategoryRepository repository) : BaseApiController
{
    /// <summary>
    /// Create a new category
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory(Category category)
    {
        if (!await repository.AddAsync(category)) return BadRequest("Failed to create category");

        return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
    }

    /// <summary>
    /// Get all categories
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories(string? sort)
    {
        return Ok(await repository.GetAsync(sort));
    }

    /// <summary>
    /// Get a category by id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(Guid id)
    {
        var category = await repository.GetByIdAsync(id);

        if (category == null) return NotFound();

        return category;
    }

    /// <summary>
    /// Update a category
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(Guid id, Category category)
    {
        if (id != category.Id) return BadRequest();

        if (!await repository.UpdateAsync(category)) return BadRequest("Failed to update category");

        return NoContent();
    }

    /// <summary>
    /// Delete a category
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        if (!await repository.DeleteAsync(id)) return BadRequest("Failed to delete category");

        return NoContent();
    }
}
