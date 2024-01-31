using LibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI;

public class LibraryDb:DbContext
{



    public LibraryDb(DbContextOptions<LibraryDb> option):base(option)
    {
        
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //}

    public DbSet<Book> Books { get; set; }
    public DbSet<Member> Members { get; set; }


}
