﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coursedb.Data.db
{
    public partial class CoursedbContext : DbContext
    {
        public CoursedbContext()
        {
        }

        public CoursedbContext(DbContextOptions<CoursedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Docs> Docs { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Types> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.Clientid);

                entity.ToTable("clients");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Clientname).HasColumnName("clientname");
            });

            modelBuilder.Entity<Docs>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK__Table__080E377560C2117E");

                entity.ToTable("docs");

                entity.HasIndex(e => e.Rowguid, "UQ__docs__F73921F7EA4C5270")
                    .IsUnique();

                entity.Property(e => e.Orderid)
                    .ValueGeneratedNever()
                    .HasColumnName("orderid");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Terms).HasColumnName("terms");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.Docs)
                    .HasForeignKey<Docs>(d => d.Orderid)
                    .HasConstraintName("fk_orderid");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Orderid);

                entity.ToTable("orders");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Eff).HasColumnName("eff");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.Typeid).HasColumnName("typeid");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("fk_clientid");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Typeid)
                    .HasConstraintName("fk_typeid");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.Typeid);

                entity.ToTable("types");

                entity.Property(e => e.Typeid).HasColumnName("typeid");

                entity.Property(e => e.Billedper).HasColumnName("billedper");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Typename).HasColumnName("typename");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}