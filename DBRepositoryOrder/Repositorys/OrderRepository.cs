using DBRepositoryOrder.DBContext;
using DomainEntityOrder;
using DomainEntityOrder.DBRepository;
using DomainModelOrder;
using DomainModelOrder.ViewModel;
using OrderExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DBRepositoryOrder.Repositorys
{
    public class OrderRepository : SqlServerRespository<OrderModel>, IOrderRepository<OrderModel>
    {
        public OrderRepository() : base(new SqlServerContextOrder())
        { }

        public IEnumerable<OrderViewModel> GetOrderView(OrderSearchViewModel searchModel,PaginationViewModel page)
        {
            IQueryable<OrderDetailQueryModel> queryableData = from o in dbContext.Orders
                     join cu in dbContext.Customers on o.CustomerID equals cu.CustomerID
                     join od in dbContext.OrderDetails on o.OrderID equals od.OrderID
                     where
                     (string.IsNullOrEmpty(searchModel.CustomerName) || cu.CustomerName.ToUpper().Contains( searchModel.CustomerName.ToUpper()) )
                     && (string.IsNullOrEmpty(searchModel.SKU) || od.SKU.ToUpper().Contains(searchModel.SKU.ToUpper()) )
                     //where cu.CustomerName == "customer2"
                     //orderby o.OrderID, o.UpdateTime descending
                     //orderby string.IsNullOrEmpty(searchModel.SortColumn) ? o.OrderID: searchModel.SortColumn
                     select new OrderDetailQueryModel {  OrderID = o.OrderID, CreateTime= o.CreateTime, SKU= od.SKU,
                        Price= od.Price,Amount= od.Amount,CustomerName= cu.CustomerName,Email= cu.Email };

            page.TotalItems = queryableData.Count();


            if ( !string.IsNullOrEmpty(searchModel.SortColumn) )
            {
                queryableData = queryableData.OrderByField<OrderDetailQueryModel>("OrderID", true);
                queryableData = queryableData.OrderByField<OrderDetailQueryModel>(searchModel.SortColumn,true).Skip(page.PageSize * (page.CurrntPage - 1)).Take(page.PageSize); ;
            }else
            {
                queryableData = queryableData.OrderByField<OrderDetailQueryModel>("OrderID", true).Skip(page.PageSize*(page.CurrntPage-1)).Take(page.PageSize);

            }

            List<OrderViewModel> viewResult = new List<OrderViewModel>();

            OrderViewModel om = null;
            Guid tempOrderId = Guid.NewGuid();
            foreach (var iXX in queryableData)
            {
                if (tempOrderId != iXX.OrderID || om == null)
                {
                    tempOrderId = iXX.OrderID;
                    om = new OrderViewModel
                    {
                        OrderID = iXX.OrderID,
                        CustomerName = iXX.CustomerName,
                        Email = iXX.Email,
                        CreateTime = iXX.CreateTime,
                    };
                    viewResult.Add(om);
                    OrderItemViewModel oiv = new OrderItemViewModel
                    {
                        Amount = iXX.Amount,
                        Price = iXX.Price,
                        SKU = iXX.SKU
                    };
                    if (om.OrderItems == null) om.OrderItems = new List<OrderItemViewModel>();
                    om.OrderItems.Add(oiv);
                }
                else
                {
                    OrderItemViewModel oiv = new OrderItemViewModel
                    {
                        Amount = iXX.Amount,
                        Price = iXX.Price,
                        SKU = iXX.SKU
                    };
                    if (om.OrderItems == null) om.OrderItems = new List<OrderItemViewModel>();
                    om.OrderItems.Add(oiv);
                }
            }

            return viewResult.AsEnumerable<OrderViewModel>();
        }
        public IEnumerable<OrderViewModel> GetOrderView()
        {
            return GetOrderView(new OrderSearchViewModel(), new PaginationViewModel {PageSize=10,CurrntPage=1 });
        }
    }
}
