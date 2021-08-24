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
        /// <summary>
        /// This method takes <paramref name="id"/> which is the primary key value of the entity and returns the entity
        /// if found otherwise <see langword="null"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="id">The primary key value of the entity.</param>
        /// <returns>Returns <see cref="{TEntity}"/></returns>
        TEntity Get<TEntity>(int id) where TEntity : BaseEntity;
        /// <summary>
        /// This method takes <typeparamref name="TEntity"/>, insert it into database/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity to be inserted.</param>
        void Insert<TEntity>(TEntity entity) where TEntity : BaseEntity;
        /// <summary>
        /// This method takes <typeparamref name="TEntity"/>, update it into database/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity to be updated.</param>
        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        void Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        void Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;


    }
}
