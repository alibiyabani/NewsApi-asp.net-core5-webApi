using Microsoft.EntityFrameworkCore;
using NewsApi.Core.Services.Interfaces;
using NewsApi.DataLayer.Context;
using NewsApi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsApi.Core.Services
{
    public class SourceService : ISourceService
    {
        private ApiContex _context;

        public SourceService(ApiContex context)
        {
            _context = context;
        }
         
        public async Task<Source> Add(Source source)
        {
            await _context.Sources.AddAsync(source);
            await _context.SaveChangesAsync();
            return source;
        }

        public async Task<Source> Find(int id)
        {
            return await _context.Sources.SingleOrDefaultAsync(s =>s.SourceId == id);
        }

        public IEnumerable<Source> GetAll()
        {
            return _context.Sources;
        }

        public async Task<Source> Remove(int id)
        {
            var source = await _context.Sources.SingleAsync(s => s.SourceId == id);
            _context.Sources.Remove(source);
            await _context.SaveChangesAsync();
            return source;
        }

        public async Task<Source> Update(Source source)
        {
            _context.Update(source);
            await _context.SaveChangesAsync();
            return source;
        }
        public async Task<bool> IsExist(int id)
        {
            return await _context.Sources.AnyAsync(n => n.SourceId == id);
        }
    }
}
