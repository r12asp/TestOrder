using DomainEntityOrder.DBRepository;
using DomainModelOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepositoryOrder.Repositorys
{
    public class ProductRepository : SqlServerRespository<ProductModel>,IProductRepository<ProductModel>
    {
        public ProductRepository() : base(new DBContext.SqlServerContextOrder())
        { }
    }
}
