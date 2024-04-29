using Microsoft.EntityFrameworkCore;

namespace Joao;

public class AppDataContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Folha> Folhas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=andre_joao.db");
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>() 
            .HasOne(f => f.folha)
            .WithOne(f => f.Funcionario)
            .HasForeignKey<Folha>(f => f.FuncionarioId);
    }

}
