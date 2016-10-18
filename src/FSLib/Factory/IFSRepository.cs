using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FSLib.Factory
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFSRepository<T> : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> _predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_predicate"></param>
        /// <returns></returns>
        Task<T> FindSingle(Expression<Func<T, bool>> _predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_model"></param>
        void Add(T _model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_model"></param>
        void Update(T _model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_model"></param>
        void Delete(T _model);
    }
}
