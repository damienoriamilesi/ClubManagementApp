using Microsoft.EntityFrameworkCore;
using System;

namespace ClubManagementApp.Infrastructure
{
    public class ClubManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("");
        }

        protected ClubManagementContext(DbContextOptions<ClubManagementContext> options) : base(options)
        {
            
        }

        //public DbSet<Club> MyProperty { get; set; }
    }

    public class Audit
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
