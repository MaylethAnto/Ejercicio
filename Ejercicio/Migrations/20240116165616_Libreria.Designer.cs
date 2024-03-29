﻿// <auto-generated />
using System;
using Ejercicio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ejercicio.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    [Migration("20240116165616_Libreria")]
    partial class Libreria
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ejercicio.Models.Entidades.Autor", b =>
                {
                    b.Property<int>("idAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAutor"));

                    b.Property<string>("apAutor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomAutor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idAutor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Ejercicio.Models.Entidades.Categoria", b =>
                {
                    b.Property<int>("idCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCategoria"));

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Ejercicio.Models.Entidades.DetalleVenta", b =>
                {
                    b.Property<int>("iddetalleventa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("iddetalleventa"));

                    b.Property<int>("cantidadlibros")
                        .HasColumnType("int");

                    b.Property<int>("libroidlibro")
                        .HasColumnType("int");

                    b.Property<int>("ventasidVentas")
                        .HasColumnType("int");

                    b.HasKey("iddetalleventa");

                    b.HasIndex("libroidlibro");

                    b.HasIndex("ventasidVentas");

                    b.ToTable("DetalleVentas");
                });

            modelBuilder.Entity("Ejercicio.Models.Entidades.Editorial", b =>
                {
                    b.Property<int>("idEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEditorial"));

                    b.Property<string>("nombreEdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idEditorial");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("Ejercicio.Models.Entidades.Roles", b =>
                {
                    b.Property<int>("idRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRol"));

                    b.Property<string>("nombreRol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Ejercicio.Models.Entidades.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUsuario"));

                    b.Property<string>("URLFotoPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Ejercicio.Models.entidades.Libro", b =>
                {
                    b.Property<int>("idlibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idlibro"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("EditorialidEditorial")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal (18,2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLlibro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idlibro");

                    b.HasIndex("AutorId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EditorialidEditorial");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Ejercicio.Models.entidades.Ventas", b =>
                {
                    b.Property<int>("idVentas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVentas"));

                    b.Property<decimal>("descuento")
                        .HasColumnType("decimal (18,2)");

                    b.Property<DateTime>("fechaventa")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("iva")
                        .HasColumnType("decimal (18,2)");

                    b.Property<decimal>("subtotal")
                        .HasColumnType("decimal (18,2)");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal (18,2)");

                    b.Property<int>("usuarioidUsuario")
                        .HasColumnType("int");

                    b.HasKey("idVentas");

                    b.HasIndex("usuarioidUsuario");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Ejercicio.Models.Entidades.DetalleVenta", b =>
                {
                    b.HasOne("Ejercicio.Models.entidades.Libro", "libro")
                        .WithMany()
                        .HasForeignKey("libroidlibro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ejercicio.Models.entidades.Ventas", "ventas")
                        .WithMany()
                        .HasForeignKey("ventasidVentas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("libro");

                    b.Navigation("ventas");
                });

            modelBuilder.Entity("Ejercicio.Models.entidades.Libro", b =>
                {
                    b.HasOne("Ejercicio.Models.Entidades.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ejercicio.Models.Entidades.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ejercicio.Models.Entidades.Editorial", "Editorial")
                        .WithMany()
                        .HasForeignKey("EditorialidEditorial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Categoria");

                    b.Navigation("Editorial");
                });

            modelBuilder.Entity("Ejercicio.Models.entidades.Ventas", b =>
                {
                    b.HasOne("Ejercicio.Models.Entidades.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioidUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
