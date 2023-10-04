using Microsoft.EntityFrameworkCore;


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
