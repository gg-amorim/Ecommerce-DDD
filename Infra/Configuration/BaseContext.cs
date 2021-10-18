using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuration
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionStringConfig());
                base.OnConfiguring(optionsBuilder);
            }

        }
        private string GetConnectionStringConfig()
        {
            string strConnection = @"Data Source=LAPTOP-437NEVR9\SQLEXPRESS;Initial Catalog=EcommerceDDD;User ID=sa;Password=1234;";
            return strConnection;
        }
    }
}