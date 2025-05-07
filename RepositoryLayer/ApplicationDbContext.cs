using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Model;
using RepositoryLayer.Models;

namespace RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 123, RoleName = "Admin" },
            new Role { RoleId = 124, RoleName = "User" }
        );
        }
    }
}

