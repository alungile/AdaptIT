using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AdaptItAcademyEntities _dbContext = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this._dbContext = new AdaptItAcademyEntities();
            table = _dbContext.Set<T>();
        }

        public GenericRepository(AdaptItAcademyEntities _dbEntity)
        {
            this._dbContext = _dbEntity;
            table = _dbEntity.Set<T>();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
