using NewsApi.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsApi.Core.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Task<Category> Find(int id);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(int id);
        Task<bool> IsExist(int id);


    }
}
