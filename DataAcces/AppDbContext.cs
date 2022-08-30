
using DataAcces.BseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class AppDbContext : DbContext
    {
         public DbSet<User> Users { get; set; }
         public DbSet<Contact> Contacts { get; set; }
         public DbSet<Role> Roles { get; set; }
         public DbSet<UserRole> UserRoles { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
           
        }
    }
}
