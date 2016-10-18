using FSLib.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StaffMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StaffMicroService.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FSRepository<T> : IFSRepository<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        internal ApplicationDbContext context;

        /// <summary>
        /// 
        /// </summary>
        internal IConfiguration config;

        /// <summary>
        /// context option to use with termporary _context
        /// </summary>
        protected DbContextOptions<ApplicationDbContext> contextOptions;

        /// <summary>
        /// 
        /// </summary>
        public FSRepository() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public FSRepository(ApplicationDbContext _context)
        {
            context = _context;
            contextOptions = context.options;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_model"></param>
        public virtual void Add(T _model)
        {
            context.Set<T>().Add(_model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_model"></param>
        public virtual void Delete(T _model)
        {
            context.Set<T>().Remove(_model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> _predicate)
        {
            IEnumerable<T> query = null;
            using (var _context = new ApplicationDbContext(contextOptions))
            {
                query = await _context.Set<T>().Where(_predicate).ToListAsync();
            }
            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> Get()
        {
            return await Find(x => 1 == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_model"></param>
        public void Update(T _model)
        {
            context.Entry(_model).State = EntityState.Modified;
        }

        /// <summary>
        /// abstract method for update value
        /// </summary>
        /// <param name="_entity"></param>
        /// <param name="_value"></param>
        public abstract void Update(T _entity, T _value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_predicate"></param>
        /// <returns></returns>
        public async Task<T> FindSingle(Expression<Func<T, bool>> _predicate)
        {
            T _object = null;
            using (var _context = new ApplicationDbContext(contextOptions))
            {
                _object = await _context.Set<T>().FirstOrDefaultAsync(_predicate);
            }
            return _object;
        }

        private bool disposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Disposed(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }

            disposed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }
    }
}
