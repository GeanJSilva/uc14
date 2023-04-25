using ExoApi_turma15.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoApi_turma15.Contexts
{
    public class SqlContext : DbContext

    {

        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-5D01BO3; initial catalog = ExoApi; Integrated Security = true; TrustServerCertificate = true");
            }
        }
        public DbSet<Projeto> Projetos { get; set; }
    }
}
