﻿// <auto-generated />
using Joao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Joao.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Joao.Folha", b =>
                {
                    b.Property<string>("FolhaId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FuncionarioId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("ImpostoFGTS")
                        .HasColumnType("REAL");

                    b.Property<float>("ImpostoINSS")
                        .HasColumnType("REAL");

                    b.Property<float>("ImpostoIRRF")
                        .HasColumnType("REAL");

                    b.Property<int>("Mes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<float>("SalarioBruto")
                        .HasColumnType("REAL");

                    b.Property<float>("SalarioLiquido")
                        .HasColumnType("REAL");

                    b.Property<float>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("FolhaId");

                    b.HasIndex("FuncionarioId")
                        .IsUnique();

                    b.ToTable("Folhas");
                });

            modelBuilder.Entity("Joao.Funcionario", b =>
                {
                    b.Property<string>("FuncionarioId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Joao.Folha", b =>
                {
                    b.HasOne("Joao.Funcionario", "Funcionario")
                        .WithOne("folha")
                        .HasForeignKey("Joao.Folha", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("Joao.Funcionario", b =>
                {
                    b.Navigation("folha")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
