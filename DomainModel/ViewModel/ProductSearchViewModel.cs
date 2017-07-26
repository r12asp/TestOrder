using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelOrder.ViewModel
{
    public class ProductSearchViewModel
    {
        public string ProductName { set; get; }
        public string SKU { set; get; }
        public string SortColumn { get; set; }

    }
}
