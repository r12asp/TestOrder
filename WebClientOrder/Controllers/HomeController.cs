using DomainEntityOrder;
using DomainEntityOrder.DomainService;
using DomainModelOrder.ViewModel;
using DomainServiceOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientOrder.Controllers
{
    public class HomeController : Controller
    {
        private IServiceOrder so;
        public HomeController(IServiceOrder so)
        {
            this.so = so;
        }
        [HttpGet]
        public ActionResult Index()
        {
            OrderViewPageViewModel pageModel = new OrderViewPageViewModel
            {
                Orders = so.GetOrderViewsAll(),
                OrderSearch = new OrderSearchViewModel()
            };
            return View(pageModel);
        }
        [HttpPost]
        public ActionResult Index(OrderSearchViewModel searchModel)
        {
            OrderViewPageViewModel pageModel = new OrderViewPageViewModel
            {
                Orders = so.GetOrderViewsAll(searchModel),
                OrderSearch = searchModel
            };
            return View(pageModel);
        }

    }
}