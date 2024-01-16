using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CDNApi.Models
{
    public partial class AssementsContext : DbContext
    {
        //public AssementsContext()
        //{
        //}

        public AssementsContext(DbContextOptions<AssementsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblFreelancerUserList> TblFreelancerUserLists { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-9NN04D0\\SQLEXPRESS;Database=Assements;Integrated Security=True;Trust Server Certificate=False");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblFreelancerUserList>(entity =>
            {
                entity.ToTable("tblFreelancerUserList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Hobby)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("hobby");

                entity.Property(e => e.Mail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Skillsets)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("skillsets");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
