using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelOrder
{
    [Table("Product")]
    public class ProductModel
    {
        [Key]
        public Guid ProductID { set; get; }
        public string ProductName { set; get; }
        public string SKU { set; get; }
        public decimal Price { set; get; }
        public Int16 Status { set; get; }
        public DateTime CreateTime { set; get; }
        public DateTime UpdateTime { set; get; }
    }
}
