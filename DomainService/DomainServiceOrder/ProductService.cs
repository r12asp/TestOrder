using DomainEntityOrder.DBRepository;
using DomainEntityOrder.DomainService;
using DomainModelOrder;
using DomainModelOrder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServiceOrder
{
    public class ProductService : IProductService
    {
        private IProductRepository<ProductModel> repo;
        public ProductService(IProductRepository<ProductModel> iRepo)
        {
            repo = iRepo;
        }
        public IEnumerable<ProductModel> GetAll()
        {
            return repo.GetAll().OrderByDescending(p=>p.CreateTime );
        }
        public IEnumerable<ProductModel> GetAll(ProductSearchViewModel searchModel, PaginationViewModel page)
        {
            return repo.GetAll(searchModel,page);
        }
        public void Insert(ProductModel pModel)
        {
            repo.Insert(pModel);
        }
        public void Edit(ProductModel pModel)
        {
            repo.Edit(pModel);
        }
        public void Delete(Guid pid)
        {
            repo.Delete(pid);
        }
        public ProductModel Get(Guid pID)
        {
            return repo.Get(pID);
        }


    }
}
