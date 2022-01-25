﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoffeeeLover.Models;

namespace CoffeeeLover.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CoffeeeLover.Models.Address> Address { get; set; }
        public DbSet<CoffeeeLover.Models.Cashier> Cashier { get; set; }
        public DbSet<CoffeeeLover.Models.Customer> Customer { get; set; }
        public DbSet<CoffeeeLover.Models.Customer_Payment_Method> Customer_Payment_Method { get; set; }
    }
}