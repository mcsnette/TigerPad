// UserContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TigerPadG4.Models;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
}
