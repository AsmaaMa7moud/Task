using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ApplicationContext _dbContext;
        public EFRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<T> FirstAsync(int num)
        {
           var keyValues = new object[] { num };
            return await _dbContext.Set<T>().FindAsync(keyValues);
        }
    }
    }

