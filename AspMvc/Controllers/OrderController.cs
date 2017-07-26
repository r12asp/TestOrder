using DomainEntityOrder;
using DomainEntityOrder.DomainService;
using DomainModelOrder.Constant;
using DomainModelOrder.ViewModel;
using DomainServiceOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientOrder.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService so;
        public OrderController(IOrderService so)
        {
            this.so = so;
        }
        [HttpGet]
        public ActionResult Index(OrderSearchViewModel searchModel,string page)
        {
            var pp = new PaginationViewModel
            {
                CurrntPage = (string.IsNullOrEmpty(page) || int.Parse(page)==0) ? 1 : int.Parse(page),
                PageSize = GlobalConsts.PageSize,
            };

            OrderViewPageViewModel pageModel = new OrderViewPageViewModel
            {
                Orders = so.GetOrderViewsAll(searchModel, pp ),
                OrderSearch = searchModel,
                Pagination =pp,
            };
            return View(pageModel);
        }


    }
}