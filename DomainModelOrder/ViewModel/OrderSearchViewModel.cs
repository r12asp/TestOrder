using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelOrder.ViewModel
{
    public class OrderSearchViewModel
    {
        public string CustomerName { get; set; }
        public string SKU { get; set; }
        public string SortColumn { get; set; }
    }
}
