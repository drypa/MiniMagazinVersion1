using System;
using System.Collections.Generic;

namespace Magazine.DAL.Core
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(int id);
        void Update(TEntity item);
    }
}
