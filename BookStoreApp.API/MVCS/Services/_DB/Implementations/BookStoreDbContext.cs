using BookStoreApp.API.MVCS.Models.DBM.Collections;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.MVCS.Services._DB.Implementations;

public sealed class BookStoreDbContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// VARIABLES INSTANTIATION FOR COLLECTIONS
    /// </summary>
    /// <value></value>
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    /// <summary>
    /// OVERRIDES THE ON MODEL CREATING METHOD TO MAP THE COLLECTIONS TO THE DATABASE
    /// </summary>
    /// <param name="modelBuilder"></param> <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>();
        modelBuilder.Entity<Author>();
    }
}
