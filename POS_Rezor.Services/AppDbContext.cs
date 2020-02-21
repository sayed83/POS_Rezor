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
        public DbSet<Modules> Modules { get; set; }
        public DbSet<ModuleGroup> ModuleGroups { get; set; }
        public DbSet<ModuleMenu> ModuleMenues { get; set; }
        public DbSet<ImageCriteria> ImageCriterias { get; set; }
        public DbSet<MenuPermission_Master> MenuPermission_Masters { get; set; }
        public DbSet<MenuPermission_Details> MenuPermission_Details { get; set; }
    }
}
