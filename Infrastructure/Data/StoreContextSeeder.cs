using System.Text.Json;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContextSeeder
{
    public static async Task SeedAsync(StoreContext context)
    {
        await context.Database.MigrateAsync();

        if (!context.Categories.Any())
        {
            var categoriesData = JsonSerializer.Deserialize<List<Category>>(await File.ReadAllTextAsync("../Infrastructure/Data/Seeders/categories.json"));
            if (categoriesData != null)
            {
                context.Categories.AddRange(categoriesData);
                await context.SaveChangesAsync();
            }
        }
    }
}
