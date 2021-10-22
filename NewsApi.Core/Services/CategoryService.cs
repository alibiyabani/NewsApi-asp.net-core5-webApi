using Microsoft.EntityFrameworkCore;
using NewsApi.Core.Services.Interfaces;
using NewsApi.DataLayer.Context;
using NewsApi.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsApi.Core.Services
{
    public class CategoryService : ICategoryService
    {

        private ApiContex _contex;

        public CategoryService(ApiContex contex)
        {
            _contex = contex;
                
        }

        public async Task<Category> Add(Category category)
        {
            await _contex.Categories.AddAsync(category);
            await _contex.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Find(int id)
        {
            return await _contex.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _contex.Categories;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _contex.Categories.AnyAsync(c => c.CategoryId == id);
        }

        public async Task<Category> Remove(int id)
        {
            var cat = await _contex.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
            _contex.Categories.Remove(cat);
            await _contex.SaveChangesAsync();
            return cat;
        }

        public async Task<Category> Update(Category category)
        {
            _contex.Update(category);
            await _contex.SaveChangesAsync();
            return category;
        }
    }
}
