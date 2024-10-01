using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class CategoryRepository(StoreContext context) : ICategoryRepository
{
    public async Task<IReadOnlyList<Category>> GetAsync(string? sort)
    {
        var query = context.Categories.AsQueryable();

        if (!string.IsNullOrWhiteSpace(sort))
        {
            query = sort switch
            {
                "name" => query.OrderBy(c => c.Name),
                "nameDesc" => query.OrderByDescending(c => c.Name),
                "createdAt" => query.OrderBy(c => c.CreatedAt),
                "createdAtDesc" => query.OrderByDescending(c => c.CreatedAt),
                _ => query
            };
        }

        return await query.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task<bool> AddAsync(Category category)
    {
        await context.Categories.AddAsync(category);
        return await SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        context.Entry(category).State = EntityState.Modified;
        return await SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await GetByIdAsync(id);
        if (category == null)
        {
            return false;
        }
        context.Categories.Remove(category);
        return await SaveChangesAsync();
    }

    public bool Exists(Guid id)
    {
        return context.Categories.Any(e => e.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
