using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using vega.Persistence;

namespace Vega.Migrations
{
    [DbContext(typeof(VegaDbContext))]
    [Migration("20170929211556_pessoas")]
    partial class pessoas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vega.Core.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("vega.Core.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("vega.Core.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MakeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");
                });

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

            modelBuilder.Entity("vega.Core.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("vega.Core.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(255);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsRegistered");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("ModelId");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("vega.Core.Models.VehicleFeature", b =>
                {
                    b.Property<int>("VehicleId");

                    b.Property<int>("FeatureId");

                    b.HasKey("VehicleId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("VehicleFeatures");
                });

            modelBuilder.Entity("vega.Core.Models.Model", b =>
                {
                    b.HasOne("vega.Core.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vega.Core.Models.Photo", b =>
                {
                    b.HasOne("vega.Core.Models.Vehicle")
                        .WithMany("Photos")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vega.Core.Models.Vehicle", b =>
                {
                    b.HasOne("vega.Core.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vega.Core.Models.VehicleFeature", b =>
                {
                    b.HasOne("vega.Core.Models.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vega.Core.Models.Vehicle", "Vehicle")
                        .WithMany("Features")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
