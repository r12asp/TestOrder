using DomainModelOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntityOrder.DomainService
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        void Insert(ProductModel pModel);
    }
}
