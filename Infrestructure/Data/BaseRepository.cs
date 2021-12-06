using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrestructure.Data
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class, Core.Entities.IEntity<TKey>
    {
        protected readonly ToDoDBContext toDoDB1;
        protected readonly DbSet<TEntity> dbset;
        public BaseRepository(ToDoDBContext toDoDB)
        {
            toDoDB1 = toDoDB;
            dbset = toDoDB1.Set<TEntity>();
        }
        //public IUnitOfWork IUnit => throw new NotImplementedException();

        //public Task<TEntity> Add(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Delete(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<TEntity>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<TEntity> GetByKey(TKey key)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Update(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}
        public IUnitOfWork IUnit { get=>toDoDB1; }
        
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbset.ToListAsync();
        }

        public async Task<TEntity> GetByKey(TKey id)
        {
            return await dbset.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public TEntity Add(TEntity item)
        {
            var insertedItem = dbset.Add(item).Entity;

            return insertedItem;
        }

        public void Update(TEntity item)
        {
            toDoDB1.Entry(item).State = EntityState.Modified;
        }

        public void Delete(TEntity item)
        {
            dbset.Remove(item);
        }

    }
}
