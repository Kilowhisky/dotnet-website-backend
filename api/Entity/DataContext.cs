using System;
using Api.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Api.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
