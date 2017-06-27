using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelOrder.ViewModel
{
    public class OrderViewModel
    {
        public Guid OrderID { set; get; }
        public string CustomerName { set; get; }
        public string Email { set; get; }
        public int Amount { set; get; }
        public decimal Price { set; get; }
        public List<OrderItemViewModel> OrderItems { set; get; }
        //public Int16 Status { set; get; }
        public DateTime CreateTime { set; get; }
        //public DateTime UpdateTime { set; get; }
    }
}
