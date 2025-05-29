using System;
using API_GERAL.models;
using Microsoft.EntityFrameworkCore;

namespace API_GERAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Despesas> Despesas { get; set; }
    }
}