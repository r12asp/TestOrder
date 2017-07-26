using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelOrder
{
    [Table("Customer")]
    public class CustomerModel
    {
        [Key]
        public Guid CustomerID { set; get; }
        public string CustomerName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public Int16 Status { set; get; }
        public DateTime CreateTime { set; get; }
        public DateTime UpdateTime { set; get; }
    }
}
