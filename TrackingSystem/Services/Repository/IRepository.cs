﻿using System.Linq.Expressions;

namespace TrackingSystem.Services.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int page = 0,
            int size = -1,
            string includeProperties = "");
        TEntity GetById(object id);
        IEnumerable<TEntity> GetWithRangeSql(string query,
            params object[] parameters);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}
