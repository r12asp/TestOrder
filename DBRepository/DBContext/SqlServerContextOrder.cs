using DomainModelOrder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepositoryOrder.DBContext
{
    public class SqlServerContextOrder : DbContext
    {
        public SqlServerContextOrder():base("SqlServerOrder")
        {
            Database.SetInitializer<SqlServerContextOrder>(null);
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
    }
}
