using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.DataAccess.Data;

namespace University.DataAccess.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : BaseEntity
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public TEntity Get<TEntity>(int id) where TEntity : BaseEntity
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(e => e.Id == id);
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null) throw new ArgumentNullException("cannot insert null entity!!");

            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null) throw new ArgumentNullException("cannot update null entity!!");
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null) throw new ArgumentNullException("cannot delete null entity!!");

            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _dbContext.Set<TEntity>().AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _dbContext.Set<TEntity>().UpdateRange(entities);
            _dbContext.SaveChanges();
        }

        public void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _dbContext.Set<TEntity>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }
    }
}
