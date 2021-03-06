﻿using DBRepositoryOrder.DBContext;
using DomainEntityOrder;
using DomainEntityOrder.DBRepository;
using DomainModelOrder;
using DomainModelOrder.Constant;
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

        public IEnumerable<OrderViewModel> GetOrderView(OrderSearchViewModel searchModel, PaginationViewModel page)
        {
            IQueryable<OrderViewModel> queryableData = 
                from o in dbContext.Orders
                join cu in dbContext.Customers on o.CustomerID equals cu.CustomerID
                join od in dbContext.OrderDetails on o.OrderID equals od.OrderID
                where
                (string.IsNullOrEmpty(searchModel.CustomerName) || cu.CustomerName.ToUpper().Contains(searchModel.CustomerName.ToUpper()))
                && (string.IsNullOrEmpty(searchModel.SKU) || od.SKU.ToUpper().Contains(searchModel.SKU.ToUpper()))
                select new OrderViewModel
                {
                    OrderID = o.OrderID,
                    CreateTime = o.CreateTime,
                    CustomerName = cu.CustomerName,
                    Email = cu.Email,
                    OrderItems = dbContext.OrderDetails.Where(a => a.OrderID == o.OrderID),
                };

            page.TotalItems = queryableData.Count();
            if (!string.IsNullOrEmpty(searchModel.SortColumn))
            {
                queryableData = queryableData.OrderByField<OrderViewModel>("OrderID", true);
                queryableData = queryableData.OrderByField<OrderViewModel>(searchModel.SortColumn, true).Skip(page.PageSize * (page.CurrntPage - 1)).Take(page.PageSize); ;
            } else
            {
                queryableData = queryableData.OrderByField<OrderViewModel>("OrderID", true).Skip(page.PageSize * (page.CurrntPage - 1)).Take(page.PageSize);

            }
            List<OrderViewModel> viewResult = new List<OrderViewModel>();
            return queryableData.AsEnumerable<OrderViewModel>();
        }
        public IEnumerable<OrderViewModel> GetOrderView()
        {
            return GetOrderView(new OrderSearchViewModel(), new PaginationViewModel {PageSize= GlobalConsts.PageSize, CurrntPage=1 });
        }
    }
}
