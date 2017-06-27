using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelOrder.ViewModel
{
    public class OrderItemViewModel
    {
        public string SKU { set; get; }
        public decimal Price { set; get; }
        public int Amount { set; get; }
    }
}
