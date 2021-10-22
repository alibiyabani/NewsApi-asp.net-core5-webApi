using NewsApi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Services.Interfaces
{
    public interface ISourceService
    {
        IEnumerable<Source> GetAll();
        Task<Source> Find(int id);
        Task<Source> Add(Source source);
        Task<Source> Update(Source source);
        Task<Source> Remove(int id);
        Task<bool> IsExist(int id);

    }
}
