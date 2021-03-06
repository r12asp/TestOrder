﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelOrder
{
    [Table("OrderDetail")]
    public class OrderDetailModel
    {
        [Key]
        public Guid OrderDetailID { set; get; }
        public Guid OrderID { set; get; }
        public string SKU { set; get; }
        public int Amount { set; get; }
        public decimal Price { set; get; }
        public Int16 Status { set; get; }
        public DateTime CreateTime { set; get; }
        public DateTime UpdateTime { set; get; }
    }
}
