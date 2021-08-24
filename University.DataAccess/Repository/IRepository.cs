using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataAccess.Data;

namespace University.DataAccess.Repository
{
    /// <summary>
    /// Contains all the repository methods.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets <see cref="IEnumerable{T}"/> of the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>Returns <see cref="IEnumerable{T}"/>.</returns>
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity;
        /// <summary>
        /// Gets <see cref="IQueryable{T}"/> of the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>Returns <see cref="IQueryable{T}"/>.</returns>
        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : BaseEntity;
        TEntity Get<TEntity>(int id) where TEntity : BaseEntity;
        void Insert<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;
        void Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;
        void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;


    }
}
