using GraduationProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject
{
    public class GraduationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"server=.;database=GradDB;trusted_connection=true;encrypt=false");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1 to M Admin with Patient
            modelBuilder.Entity<Patient>()
            .HasOne(p => p.hospital_Admins)
            .WithMany(h => h.patients)
            .HasForeignKey(p => p.AdminSsn);

            //1 to M Admin with Relative
            modelBuilder.Entity<Relative>()
           .HasOne(p => p.hospital_Admins)
           .WithMany(h => h.relatives)
           .HasForeignKey(p => p.AdminSsn);

            // M to M  Medicine with Relative
            modelBuilder.Entity<RelativeMedicine>()
               .HasKey(t => new { t.RelativeSsn, t.MedicineId }); 
            modelBuilder.Entity<RelativeMedicine>()
                .HasOne(p => p.Relative)
                .WithMany(m => m.RelativeMedicines)
                .HasForeignKey(p => p.RelativeSsn);
            modelBuilder.Entity<RelativeMedicine>()
               .HasOne(p => p.medicine)
               .WithMany(m => m.RelativeMedicines)
               .HasForeignKey(p => p.MedicineId);
        }
        public DbSet<Hospital_Admin> hospital_Admins { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Relative> relatives { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
    }
}
