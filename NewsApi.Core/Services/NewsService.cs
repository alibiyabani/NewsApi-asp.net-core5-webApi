using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NewsApi.Core.Services.Interfaces;
using NewsApi.DataLayer.Context;
using NewsApi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Services
{
    public class NewsService : INewsService
    {

        private ApiContex _context;
        private IMemoryCache _catch;


        public NewsService(ApiContex context, IMemoryCache cache)
        {
            _context = context;
            _catch = cache;
        }

        public async Task<News> Add(News news)
        {
            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
            return news;
        }

        public async Task<News> Find(int id)
        {
            var catcheResult = _catch.Get<News>(id);
            if (catcheResult != null)
            {
                return catcheResult;
            }
            else
            {
                var news = await _context.News.SingleOrDefaultAsync(n => n.Id == id);
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(120));
                _catch.Set(news.Id, news, cacheOptions);
                return news;
            }
            //return await _context.News.SingleOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<News>> GetAll()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.News.AnyAsync(n => n.Id == id);
        }

        public async Task<News> Remove(int id)
        {
            var news = await _context.News.SingleAsync(n => n.Id == id);
            _context.Remove(news);
            await _context.SaveChangesAsync();
            return news;
        }

        public async Task<IEnumerable<News>> Search(string searchTerm)
        {
            IQueryable<News> query = _context.News;

            query.Where(s => s.Body.Contains(searchTerm) || s.Title.Contains(searchTerm) || s.SubTitle.Contains(searchTerm));

            return await query.ToListAsync();
        }

        public async Task<News> Update(News news)
        {
            _context.Update(news);
            await _context.SaveChangesAsync();
            return news;
        }


    }
}
