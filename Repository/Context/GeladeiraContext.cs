using GeladeiraAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{

    public class GeladeiraContext : DbContext
    {
        public DbSet<Item> Itens { get; set; }
        public GeladeiraContext(DbContextOptions<GeladeiraContext> options) : base(options) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasKey(e => e.IdItem);
            modelBuilder.Entity<Item>().Property(e => e.Nome).IsRequired();
        }
    }
}