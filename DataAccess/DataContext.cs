using Microsoft.EntityFrameworkCore;
using API.Net.Models;


namespace API.Net.DataAccess
{
  public class DataContext: DbContext
  {
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
  }
}
