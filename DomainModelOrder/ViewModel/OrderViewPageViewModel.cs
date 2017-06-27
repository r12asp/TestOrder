using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelOrder.ViewModel
{
    public class OrderViewPageViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public OrderSearchViewModel OrderSearch { get; set; }
    }
}
