using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Net.DataAccess;
using API.Net.Models;
namespace API.Net.Controllers

{

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
   private readonly ILogger<BookController> _logger;
   private readonly DataContext _context;

   public BookController (ILogger<BookController> logger, DataContext context)
   {
    _logger = logger;
    _context = context;
   }


[HttpGet(Name = "GetBooks")]
public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
{
  return await _context.Books.ToListAsync();
}

[HttpGet("{id}", Name="GetBook")]
public async Task<ActionResult<Book>> GetBook(int id)
{
  var book = await _context.Books.FindAsync(id);
  if (book == null)
  {
    return NotFound();
  }
  return book;
}

[HttpPost("add")]
public async Task<ActionResult<Book>> CreateBook(Book book)
{
  _context.Books.Add(book);
  await _context.SaveChangesAsync();
  return new CreatedAtRouteResult("GetBook", new { id = book.Id }, book);
}

[HttpPut("update/{id}")]
public async Task<ActionResult> UpdateBook(int id, Book book)
{
  if (id != book.Id)
  {
    return BadRequest();
  }

  _context.Entry(book).State = EntityState.Modified;
  await _context.SaveChangesAsync();
  return Ok();
}

[HttpDelete("delete/{id}")]
public async Task<ActionResult<Book>> DeleteBook(int id)
{
  var book = await _context.Books.FindAsync(id);
    if (book == null)
    {
      return NotFound();
    }

  _context.Books.Remove(book);
  await _context.SaveChangesAsync();
  return book;
}
}
}
