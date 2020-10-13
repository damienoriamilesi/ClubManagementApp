using ClubManagementApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClubManagementApp.Infrastructure
{
    public class ClubManagementContext : DbContext
    {
        public ClubManagementContext(DbContextOptions<ClubManagementContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseSqlite("");

            //optionsBuilder.UseSqlServer()
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modify fluent mappings
            //modelBuilder.Entity<Licence>(entity =>
            //{
            //    entity.HasOne(p => p.Club);
            //    entity.HasOne(p => p.LicenceType);
            //    entity.HasOne(p => p.User);
            //});

            //Many to Many 
            modelBuilder.Entity<Cotisation>().HasKey(entity => new { entity.UserId, entity.LicenceId });

            Seed(modelBuilder);
       }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 1, Label = "Male" }, new Gender {Id = 2, Label = "Female" });
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Lastname = "Oria", Firstname = "Damien", GenderId = 1 });
            
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<Cotisation> Cotisations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<LicenceType> LicenceTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
