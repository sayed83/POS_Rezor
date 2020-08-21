using Microsoft.EntityFrameworkCore;
using POS_Rezor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Rezor.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {          
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Profit> Profits { get; set; }
        public DbSet<Invest> Invests { get; set; }
        public DbSet<Expenses> Expensess { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<BloodGroup> BloodGroup { get; set; }
        public DbSet<Transection> Transections { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<ModuleGroup> ModuleGroups { get; set; }
        public DbSet<ModuleMenu> ModuleMenues { get; set; }
        public DbSet<ImageCriteria> ImageCriterias { get; set; }
        public DbSet<MenuPermission_Master> MenuPermission_Masters { get; set; }
        public DbSet<MenuPermission_Details> MenuPermission_Details { get; set; }
    }
}
