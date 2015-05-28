using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidade;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class EFDbContext: DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        //public DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Produto>().ToTable("Produtos");
            //modelBuilder.Entity<Administrador>().ToTable("Administradores");
        }
    }
}
