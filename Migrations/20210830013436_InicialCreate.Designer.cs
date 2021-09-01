﻿// <auto-generated />
using System;
using APILocadoraCRUD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APILocadoraCRUD.Migrations
{
    [DbContext(typeof(APILocadoraCRUDContext))]
    [Migration("20210830013436_InicialCreate")]
    partial class InicialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("APILocadoraCRUD.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Situacao")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("APILocadoraCRUD.Models.Filme", b =>
                {
                    b.Property<int>("IdFilme")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdGenero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("IdFilme");

                    b.HasIndex("IdGenero");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("APILocadoraCRUD.Models.Genero", b =>
                {
                    b.Property<int>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("IdGenero");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("APILocadoraCRUD.Models.Locacao", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdFilme")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataDaLocacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdLocacao")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdCliente", "IdFilme");

                    b.HasIndex("IdFilme");

                    b.ToTable("Locacaos");
                });

            modelBuilder.Entity("APILocadoraCRUD.Models.Filme", b =>
                {
                    b.HasOne("APILocadoraCRUD.Models.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("APILocadoraCRUD.Models.Locacao", b =>
                {
                    b.HasOne("APILocadoraCRUD.Models.Cliente", "Cliente")
                        .WithMany("Locacoes")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APILocadoraCRUD.Models.Filme", "Filme")
                        .WithMany("Locacoes")
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("APILocadoraCRUD.Models.Cliente", b =>
                {
                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("APILocadoraCRUD.Models.Filme", b =>
                {
                    b.Navigation("Locacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
