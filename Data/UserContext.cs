// UserContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TigerPadG4.Models;
using TigerPadG4.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TigerPadG4.ViewModel;

public class UserContext : IdentityDbContext<UserClass>
{
    public DbSet<UserModel> UserProfiles { get; set; }
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserClass>().HasData(

            new UserClass
            {
                Username = "Test",
                Password = "Test",
                Email = "Test",
                Access = true
                

            }
            
            
            
            
            
            );


    }




}
