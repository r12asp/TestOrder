using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainServiceOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using DomainEntityOrder.DomainService;
using DomainModelOrder;
using DomainEntityOrder.DBRepository;

namespace DomainServiceOrder.DomainService.Tests
{
    [TestClass()]
    public class ServiceOrderTests
    {
        [TestMethod()]
        public void GetOrdersAllTest()
        {
            //Arrange
            var expectedOrderList = new List<OrderModel>
            {
                new OrderModel {OrderID= new Guid("53D01A12-DD44-4E72-B5E2-11D26899E981"),
                                CustomerID = new Guid("337FD688-17A5-42E4-A64E-E181235A1B3B"),
                                Status =0,
                                CreateTime =DateTime.Parse("2017-06-16 19:36:12.257"),
                                UpdateTime =DateTime.Parse("2017-06-16 19:36:12.257") },
                new OrderModel {OrderID= new Guid("337FD688-17A5-42E4-A64E-E181235A1B3B"),
                                CustomerID = new Guid("337FD688-17A5-42E4-A64E-E181235A1B3B"),
                                Status =0,
                                CreateTime =DateTime.Parse("2017-06-16 19:36:12.257"),
                                UpdateTime =DateTime.Parse("2017-06-16 19:36:12.257") },
            };
            var mock = new Mock<IOrderRepository<OrderModel>>();
            mock.Setup(orderRepo => orderRepo.GetAll()).Returns(expectedOrderList);
            OrderService serviceOrder = new OrderService(mock.Object);

            //Act
            var results = serviceOrder.GetOrdersAll();

            //Assert
            CollectionAssert.AreEqual(expectedOrderList, results.ToList());
        }
    }
}