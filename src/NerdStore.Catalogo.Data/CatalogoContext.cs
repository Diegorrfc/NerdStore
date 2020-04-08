using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            const string propertyToCommit = "DataCadastro";

            foreach (var item in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(propertyToCommit) != null))
            {
                if (item.State == EntityState.Added)
                    item.Property(propertyToCommit).CurrentValue = DateTime.Now;

                if (item.State == EntityState.Modified)
                    item.Property(propertyToCommit).IsModified = false;
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
