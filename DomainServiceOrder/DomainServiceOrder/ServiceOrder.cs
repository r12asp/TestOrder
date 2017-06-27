using DBRepositoryOrder;
using DBRepositoryOrder.DBContext;
using DBRepositoryOrder.Repositorys;
using DomainEntityOrder;
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
    public class ServiceOrder : IServiceOrder
    {
        private IOrderRepository<OrderModel> repo;
        public ServiceOrder(IOrderRepository<OrderModel> repo)
        {
            this.repo = repo;
        }
        public IEnumerable<OrderModel> GetOrdersAll()
        {
            return repo.GetAll();
        }
        public IEnumerable<OrderViewModel> GetOrderViewsAll()
        {
            return repo.GetOrderView();
        }
        public IEnumerable<OrderViewModel> GetOrderViewsAll(OrderSearchViewModel searchModel)
        {
            return repo.GetOrderView(searchModel);
        }
    }
}
