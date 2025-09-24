using Microsoft.EntityFrameworkCore;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserRole> UserRole { get; set; }
        
        public DbSet<TEmp_Role> TEmp_Role { get; set; }
        public DbSet<TEmp_Group> TEmp_Group { get; set; }
        public DbSet<Group> Group { get; set; }

        public DbSet<MemberInfo> MemberInfo { get; set; }
        public DbSet<EmployeeEXT> EmployeeExt { get; set; }

        public DbSet<Files> Files { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

    }
}
