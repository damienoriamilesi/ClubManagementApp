using ClubManagementApp.Infrastructure.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClubManagementApp.Infrastructure
{
    public class ClubManagementContext : DbContext
    {
        public ClubManagementContext(DbContextOptions<ClubManagementContext> options) : base(options)
        {
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

    public class Audit
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
