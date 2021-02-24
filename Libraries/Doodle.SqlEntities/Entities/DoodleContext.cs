using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Doodle.SqlEntities.Entities
{
    public partial class DoodleContext : DbContext
    {
        public DoodleContext()
        {
        }

        public DoodleContext(DbContextOptions<DoodleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommunicationLogs> CommunicationLogs { get; set; }
        public virtual DbSet<Contactdetails> Contactdetails { get; set; }
        public virtual DbSet<CurrentStatusValue> CurrentStatusValue { get; set; }
        public virtual DbSet<LeadTable> LeadTable { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<LeadsourceTable> LeadsourceTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=BNGLOG-L-98134;Initial Catalog=Doodle;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunicationLogs>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CommunicationDate)
                    .HasColumnName("Communication_Date")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CommunicationMode)
                    .HasColumnName("Communication_Mode")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.CommunicationLogs)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK__Communica__LeadI__52593CB8");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.CommunicationLogs)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__Communica__Statu__534D60F1");
            });

            modelBuilder.Entity<Contactdetails>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContactName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CurrentStatusValue>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LeadTable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CommunicationMode)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContactDetailNavigation)
                    .WithMany(p => p.LeadTable)
                    .HasForeignKey(d => d.ContactDetail)
                    .HasConstraintName("FK__LeadTable__Conta__4D94879B");

                entity.HasOne(d => d.CurrentStatusNavigation)
                    .WithMany(p => p.LeadTable)
                    .HasForeignKey(d => d.CurrentStatus)
                    .HasConstraintName("FK__LeadTable__Curre__4F7CD00D");

                entity.HasOne(d => d.LeadSourceNavigation)
                    .WithMany(p => p.LeadTable)
                    .HasForeignKey(d => d.LeadSource)
                    .HasConstraintName("FK__LeadTable__LeadS__4E88ABD4");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LeadsourceTable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
