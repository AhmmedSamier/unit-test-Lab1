﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace web_api.Models
{
    public class Model1 : DbContext
    {
        public Model1(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("RoleUser").Property(typeof(int), "Id");

            var role = new Role()
            {
                Id = 1,
                Name = "admin"
            };

            var user = new User
            {
                Id = 1,
                Name = "admin",
                Email = "admin@admin.com",
                Password = "abcd"
            };

            modelBuilder.Entity<Role>().HasData(role);

            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity("RoleUser").HasData(
                new
                {
                    Id = 1,
                    UsersId = user.Id,
                    RolesId = role.Id
                });
        }
    }
}
