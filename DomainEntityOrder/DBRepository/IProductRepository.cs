using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntityOrder.DBRepository
{
    public interface IProductRepository<T> : IRepository<T> where T : class
    {

    }
}
