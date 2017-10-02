using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using vega.Persistence;

namespace Vega.Migrations
{
    [DbContext(typeof(VegaDbContext))]
    [Migration("20171002060729_removeDadosAntigos")]
    partial class removeDadosAntigos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vega.Core.Models.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<string>("Logradouro")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PessoasFisicas");
                });

            modelBuilder.Entity("vega.Core.Models.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ")
                        .IsRequired();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<string>("Logradouro")
                        .HasMaxLength(200);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PessoasJuridicas");
                });
        }
    }
}
