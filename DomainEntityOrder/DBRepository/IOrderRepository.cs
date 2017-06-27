using DomainModelOrder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntityOrder.DBRepository
{
    public interface IOrderRepository<T> : IRepository<T> where T :class
    {
        IEnumerable<OrderViewModel> GetOrderView(OrderSearchViewModel searchModel);
        IEnumerable<OrderViewModel> GetOrderView();
    }
}
