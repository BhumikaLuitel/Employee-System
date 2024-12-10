﻿using Microsoft.EntityFrameworkCore;
using ProductApp.Entities;

namespace ProductApp.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; } 
    public DbSet<Employee> Employees { get; set; }
}