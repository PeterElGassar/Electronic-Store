using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }



        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpcification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpcification(spec).ToListAsync();
        }



        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpcification(spec).CountAsync();
        }

        //Private 
        private IQueryable<T> ApplySpcification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}