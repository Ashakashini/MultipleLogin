
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultipleLogin.DAL.Models;

namespace MultipleLogin.DAL
{
    //public class EntityMultipleLoginDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    //{
    //    public EntityMultipleLoginDbContext(DbContextOptions<EntityMultipleLoginDbContext> options) : base(options) { }
    //    public DbSet <LoginModel> Login { get; set; }
    //    public DbSet<EmployeeRegisterationModel> Employees { get; set; }
    //}

    using MultipleLogin.DAL;  // ✅ Required for EmployeeRegisterationModel

    public class EntityMultipleLoginDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public EntityMultipleLoginDbContext(DbContextOptions<EntityMultipleLoginDbContext> options)
            : base(options) { }

        public DbSet<LoginModel> Login { get; set; }

        
        public DbSet<EmployeeRegisterationModel> Employees { get; set; }
        public DbSet<LeaveApplyModel> Leaves { get; set; }
    }
}

