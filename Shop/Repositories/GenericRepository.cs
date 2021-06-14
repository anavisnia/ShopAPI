using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWA.Data;
using ShopWA.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Repositories
{
    public class GenericRepository<T> where T : Entity
    {
        // repository is dealing with the databse operations
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);

            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            return entity;
        }

        public async Task Upsert(T entity)
        {
            if(entity.Id == 0)
            {
                _context.Update(entity);
            }
            else
            {
                _context.Add(entity);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);

            if(entity != null)
            {
                _context.Remove(entity);
            }

            await _context.SaveChangesAsync();
        }
    }
}
