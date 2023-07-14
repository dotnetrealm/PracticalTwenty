using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracticalTwenty.Data.DTO;
using PracticalTwenty.Data.Models;
using System.Security.AccessControl;
using System;

namespace PracticalSeventeen.Data.Models
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Seed Users table data
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User() { Id = 1, Firstname = "Bhavin", LastName = "Kareliya", Email = "bhavin@gmail.com", Password = "123123" },
                    new User() { Id = 2, Firstname = "Jil", LastName = "Patel", Email = "jil@gmail.com", Password = "123123" },
                    new User() { Id = 3, Firstname = "Vipul", LastName = "Kumar", Email = "vipul@gmail.com", Password = "123123" },
                    new User() { Id = 4, Firstname = "Abhi", LastName = "Dasadiya", Email = "abhi@gmail.com", Password = "123123" },
                    new User() { Id = 5, Firstname = "Jay", LastName = "Gohel", Email = "jay@gmail.com", Password = "123123" }
                );
        }
    }
}
