using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ProductdetailContext:DbContext
    {
        public ProductdetailContext(DbContextOptions<ProductdetailContext> options):base(options)
        {

        }
        public DbSet<ProductDetails> ProductDetails { get; set; }

        public DbSet<CartDetail> CartDetails{ get; set; }


    }
}
