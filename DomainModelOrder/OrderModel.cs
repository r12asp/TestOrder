using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelOrder
{
    [Table("Order")]
    public class OrderModel
    {
        [Key]
        public Guid OrderID { set; get; }
        public Guid CustomerID { set; get; }
        public Int16 Status { set; get; }
        public DateTime CreateTime { set; get; }
        public DateTime UpdateTime { set; get; }
    }
}
