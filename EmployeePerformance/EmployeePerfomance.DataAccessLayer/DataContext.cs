using EmployeePerfomance.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeePerfomance.DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DataContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed default roles
            string adminRoleName = "Admin";
            string employeeRoleName = "Employee";
            string teamLeadRoleName = "TeamLead";
            Role adminRole = new() { Id = Guid.NewGuid(), RoleName = adminRoleName };
            Role userRole = new() { Id = Guid.NewGuid(), RoleName = employeeRoleName };
            Role teamLeadRole = new() { Id = Guid.NewGuid(), RoleName = teamLeadRoleName };

            // Seed default statuses
            string workingStatusName = "Working";
            string notWorkingStatusName = "Not Working";
            string onVacationStatusName = "On Vacation";
            Status workingStatus = new() { Id = Guid.NewGuid(), StatusName = workingStatusName };
            Status notWorkingStatus = new() { Id = Guid.NewGuid(), StatusName = notWorkingStatusName };
            Status onVacationStatus = new() { Id = Guid.NewGuid(), StatusName = onVacationStatusName };

            // Seed default admin
            string adminLogin = "admin";
            string adminPassword = "admin";
            User adminUser = new()
            {
                Id = Guid.NewGuid(),
                Login = adminLogin,
                Password = adminPassword,
                RoleId = adminRole.Id,
                FirstName = "Admin",
                LastName = "Admin",
                StatusId = workingStatus.Id
            };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole, teamLeadRole });
            modelBuilder.Entity<Status>().HasData(new Status[] { workingStatus, notWorkingStatus, onVacationStatus });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Users)
                .WithOne(u => u.Department)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
