using Microsoft.EntityFrameworkCore;
using svc_teams_sender.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Models
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(int entityId);
        void Delete(T entity);
        void Update(T entity);
        void Save(T entity);

    }
}
