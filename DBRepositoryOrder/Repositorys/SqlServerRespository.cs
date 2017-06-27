using DBRepositoryOrder.DBContext;
using DomainEntityOrder;
using DomainEntityOrder.DBRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepositoryOrder.Repositorys
{
    public class SqlServerRespository<T> : IRepository<T> where T : class
    {
        public SqlServerContextOrder dbContext;
        DbSet<T> dbSet;        

        public SqlServerRespository(SqlServerContextOrder db)
        {
            dbContext = db;
            dbSet = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            var xx = from o in dbContext.Orders
                   select o;
            return (IQueryable<T>)xx;
        }
        public T Get<Tid>(Tid id)
        {
            return dbSet.Find(id);
        }
    }
}
