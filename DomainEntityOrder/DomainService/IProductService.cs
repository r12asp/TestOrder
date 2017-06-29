using DomainModelOrder;
using DomainModelOrder.ViewModel;
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
        IEnumerable<ProductModel> GetAll(ProductSearchViewModel searchModel, PaginationViewModel page);
        void Insert(ProductModel pModel);
        void Edit(ProductModel pModel);
        void Delete(Guid pid);
        ProductModel Get(Guid pID);

    }
}
