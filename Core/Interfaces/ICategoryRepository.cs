using Core.Entities;

namespace Core.Interfaces;

public interface ICategoryRepository
{
    Task<IReadOnlyList<Category>> GetAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task<bool> AddAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteAsync(Guid id);
    bool Exists(Guid id);
    Task<bool> SaveChangesAsync();
}
