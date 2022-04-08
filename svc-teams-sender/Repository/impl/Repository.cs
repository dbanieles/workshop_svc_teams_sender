using Microsoft.EntityFrameworkCore;
using svc_teams_sender.Entity;
using svc_teams_sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Repository
{

    public class Repository<T>: IRepository<T> , IDisposable where T : class,IEntity
    {
        private RepositoryContext _context;
        public DbSet<T> _entity;

        public Repository(RepositoryContext context)
        {
           _context = context;
           _entity = context.Set<T>();
        }

        public void Dispose()
        {
            _context.SaveChanges();
            _context.Dispose();
        }

        public T Get(int entityId)
        {
            if (entityId == null)
            {
                throw new ArgumentNullException("GET ARGUMENT CAN NOT BE NULL");
            }

            return _entity.SingleOrDefault(s => s.Id == entityId);
        }

        public IQueryable<T> GetAll()
        {
            return _entity.AsQueryable<T>();
        }

        public void Save(T entity)
        {
            _entity.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("UPDATE ARGUMENT CAN NOT BE NULL");
            }

            _entity.Update(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("DELETE ARGUMENT CAN NOT BE NULL");
            }

            _entity.Remove(entity);
            _context.SaveChanges();
        }

    }
}
