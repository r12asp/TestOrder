using Autofac;
using Autofac.Integration.Mvc;
using DBRepositoryOrder.Repositorys;
using DomainEntityOrder;
using DomainEntityOrder.DBRepository;
using DomainEntityOrder.DomainService;
using DomainModelOrder;
using DomainServiceOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientOrder.Base
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<OrderRepository>().As<IOrderRepository<OrderModel>>().InstancePerRequest();
            builder.RegisterType<ServiceOrder>().As<IServiceOrder>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}