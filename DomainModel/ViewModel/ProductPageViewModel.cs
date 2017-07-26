using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelOrder.ViewModel
{
    public class ProductPageViewModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public ProductSearchViewModel ProductSearch { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}
