using DomainEntityOrder.DBRepository;
using DomainModelOrder;
using DomainModelOrder.ViewModel;
using OrderExtension;
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
       
        public IEnumerable<ProductModel> GetAll(ProductSearchViewModel searchModel, PaginationViewModel page)
        {
            IQueryable<ProductModel> queryableData =
                from o in dbContext.Products
                where
                (string.IsNullOrEmpty(searchModel.ProductName) || o.ProductName.ToUpper().Contains(searchModel.ProductName.ToUpper()))
                && (string.IsNullOrEmpty(searchModel.SKU) || o.SKU.ToUpper().Contains(searchModel.SKU.ToUpper()))
                select o;

            page.TotalItems = queryableData.Count();
            if (!string.IsNullOrEmpty(searchModel.SortColumn))
            {
                queryableData = queryableData.OrderByField<ProductModel>(searchModel.SortColumn, true).Skip(page.PageSize * (page.CurrntPage - 1)).Take(page.PageSize); ;
            }
            else
            {
                queryableData = queryableData.OrderByField<ProductModel>("CreateTime", true).Skip(page.PageSize * (page.CurrntPage - 1)).Take(page.PageSize);

            }
            List<ProductModel> viewResult = new List<ProductModel>();
            return queryableData.AsEnumerable<ProductModel>();
        }
    }
}
