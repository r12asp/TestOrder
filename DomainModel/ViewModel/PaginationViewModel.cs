using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelOrder.ViewModel
{
    public class PaginationViewModel
    {
        public int TotalItems { get; set; }
        public int CurrntPage { get; set; }
        public int TotalPages { get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); } }
        public int PageSize { get; set; }
    }
}
