using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntityOrder.DBRepository
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get<Tid>(Tid id);
        void Insert(T tModel);
        void Edit(T tModel);
        void Delete<Tid>(Tid id);
    }
}
