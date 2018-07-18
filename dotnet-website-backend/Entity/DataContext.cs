using System;
using dotnetwebsitebackend.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace dotnetwebsitebackend.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
