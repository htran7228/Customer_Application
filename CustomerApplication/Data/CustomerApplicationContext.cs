using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomerApplication.Models
{
    public class CustomerApplicationContext : DbContext
    {
        public CustomerApplicationContext (DbContextOptions<CustomerApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerApplication.Models.Customer> Customer { get; set; }
    }
}
