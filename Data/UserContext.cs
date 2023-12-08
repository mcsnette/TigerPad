// UserContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TigerPadG4.Models;
using TigerPadG4.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TigerPadG4.ViewModel;

public class UserContext : DbContext
{
    public DbSet<UserClass> Users { get; set; }

    public DbSet<UserProfile> Profiles { get; set; }

    public DbSet<UserPosts> Posts { get; set; }

    public DbSet<QOTD> qotd { get; set; }


    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<QOTD>().HasData(
            new QOTD
            {
                Id = 1,
                QuoteOftheDay = "Welcome to Tigerpad! We hope you enjoy your stay!"

            }
            
            );

        modelBuilder.Entity<UserPosts>().HasData(

            new UserPosts
            {
                Id =1,
                Name = "Test",
                Username = "Test",
                PostContent = "This is a Post!",
                CreatedAt = DateTime.Now,
                IsInquiry = false,

            },

             new UserPosts
             {
                 Id = 2,
                 Name = "Test",
                 Username = "Test",
                 PostContent = "This is an Inquiry!",
                 CreatedAt = DateTime.Now,
                 IsInquiry = true,

             })
            
            
            
            ;


           

    }






}
