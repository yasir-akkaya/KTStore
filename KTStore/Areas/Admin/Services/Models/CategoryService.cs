using KTStore.Areas.Admin.Services.Interfaces;
using KTStore.Data;
using KTStore.Models;
using Microsoft.EntityFrameworkCore;

namespace KTStore.Areas.Admin.Services.Models
{
    public class CategoryService : ICategoryService
    {
        ApplicationDbContext db;

        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddCategoryAsync(Category category)
        {
            bool result = false;
            if (category != null)
            {
                db.Categories.AddAsync(category);
                db.SaveChanges();
                result = true;
            }
            return Task.FromResult(result);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category= await db.Categories.FirstOrDefaultAsync(c=>c.Id ==id && !c.IsDeleted);
            bool result = false;
            if (category != null)
            {
                category.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var list = await db.Categories.Where(x => !x.IsDeleted).ToListAsync();
            return list;
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = db.Categories.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            return category;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var editedCategory = await db.Categories.FirstOrDefaultAsync(x => x.Id == category.Id && !x.IsDeleted);
            bool result = false;
            if (editedCategory != null)
            {
                editedCategory.Name = category.Name;
                editedCategory.Description = category.Description;
                editedCategory.Status = category.Status;
                if (!String.IsNullOrEmpty(editedCategory.Image))
                {
                    editedCategory.Image = category.Image;
                }
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
