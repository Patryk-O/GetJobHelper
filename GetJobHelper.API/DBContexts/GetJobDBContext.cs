
using GetJobHelper.API.Extentions;
using GetJobHelper.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GetJobHelper.API.DBContexts
{
    public class GetJobDBContext : DbContext
    {
        public GetJobDBContext(DbContextOptions<GetJobDBContext> options) : base(options)
        {
        }
        public DbSet<Recruiter> Recruiters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
