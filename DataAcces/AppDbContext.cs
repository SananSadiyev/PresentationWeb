
using DataAcces.BseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Services.Helper;

namespace DataAcces
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
                  new Role
                  {
                      Id = 1,
                      Name = "Admin",
                     // CreateDate = DateTime.Now,
                      CreateUserId = 1
                  });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 2,
                    Name = "User",
                  //  CreateDate = DateTime.Now,
                    CreateUserId = 1
                }
                );

            var salt = Crypto.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Name = "admin",
                    Surname = "admin",
                    Salt = salt,
                    PasswordHash = Crypto.GenerateSHA256Hash("admin001", salt),
                    RoleId = 1,
                    //CreateDate = DateTime.Now,
                    CreateUserId = 1
                }
                );
        }


    }
}
