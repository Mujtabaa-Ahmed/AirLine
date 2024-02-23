using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Airline.Models;

namespace Airline.Data
{
    public partial class AirlineContext : DbContext
    {
        public AirlineContext()
        {
        }

        public AirlineContext(DbContextOptions<AirlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Rout> Routs { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-713LM2T;Initial Catalog=Airline;Integrated Security=True;\nConnect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;\nMultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BId)
                    .HasName("PK__booking__4E29C30D6376A9AD");

                entity.ToTable("booking");

                entity.Property(e => e.BId).HasColumnName("b_id");

                entity.Property(e => e.BAmount).HasColumnName("b_amount");

                entity.Property(e => e.BQuan).HasColumnName("b_quan");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.SId).HasColumnName("s_id");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__booking__c_id__45F365D3");

                entity.HasOne(d => d.SIdNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SId)
                    .HasConstraintName("FK__booking__s_id__46E78A0C");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__class__213EE7742A88EE4D");

                entity.ToTable("class");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.CName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("c_name");

                entity.Property(e => e.CPrice).HasColumnName("c_price");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__flight__2911CBEDCA488431");

                entity.ToTable("flight");

                entity.Property(e => e.FId).HasColumnName("f_id");

                entity.Property(e => e.FName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("f_name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("PK__Role__C4762327B42FD563");

                entity.ToTable("Role");

                entity.Property(e => e.RId).HasColumnName("r_id");

                entity.Property(e => e.RName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("r_name");
            });

            modelBuilder.Entity<Rout>(entity =>
            {
                entity.ToTable("rout");

                entity.Property(e => e.RoutId).HasColumnName("Rout_id");

                entity.Property(e => e.RoutName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rout_name");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__schedule__2F3684F49050460F");

                entity.ToTable("schedule");

                entity.Property(e => e.SId).HasColumnName("s_id");

                entity.Property(e => e.FId).HasColumnName("f_id");

                entity.Property(e => e.RoutId).HasColumnName("rout_id");

                entity.Property(e => e.SArival)
                    .HasColumnType("datetime")
                    .HasColumnName("s_arival");

                entity.Property(e => e.SDeparture)
                    .HasColumnType("datetime")
                    .HasColumnName("s_departure");

                entity.HasOne(d => d.FIdNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.FId)
                    .HasConstraintName("FK__schedule__f_id__403A8C7D");

                entity.HasOne(d => d.Rout)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RoutId)
                    .HasConstraintName("FK__schedule__rout_i__412EB0B6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__Users__B51D3DEAF6F94EED");

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.Property(e => e.RId).HasColumnName("r_id");

                entity.Property(e => e.UMail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("u_mail");

                entity.Property(e => e.UName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("u_name");

                entity.Property(e => e.UPass)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("u_pass");

                entity.HasOne(d => d.RIdNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RId)
                    .HasConstraintName("FK__Users__r_id__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
