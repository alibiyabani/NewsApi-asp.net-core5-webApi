using NewsApi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Services.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetAll();
        Task<IEnumerable<News>> Search(string searchTerm);
        Task<News> Find(int id);
        Task<News> Add(News news);
        Task<News> Update(News news);
        Task<News> Remove(int id);
        Task<bool> IsExist(int id);
    }
}
