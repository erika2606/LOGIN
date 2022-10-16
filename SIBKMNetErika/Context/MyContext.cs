using Microsoft.EntityFrameworkCore;
using SIBKMNetErika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNetErika.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        // mengatur connection string (done)
        // menmbahkan model untuk diolah dan atau migration (done)
        /*
         * Code First V
         * Database First
         */
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
