using DomainModelOrder;
using DomainModelOrder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntityOrder.DomainService
{
    public interface IServiceOrder
    {
        IEnumerable<OrderModel> GetOrdersAll();
        IEnumerable<OrderViewModel> GetOrderViewsAll();
        IEnumerable<OrderViewModel> GetOrderViewsAll(OrderSearchViewModel searchModel, PaginationViewModel page);
    }
}
