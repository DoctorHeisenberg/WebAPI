using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseRepository <TEntity,TKey>
    {
        TEntity Add(TEntity entity);
        Task <IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByKey (TKey key);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        public IUnitOfWork IUnit { get; }
    }
}
