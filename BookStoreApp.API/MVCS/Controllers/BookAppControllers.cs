using BookStoreApp.API.MVCS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.API.MVCS.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/v1/BookStoreAPI")]
public class BookAppControllers(ILogger<BookAppControllers> logger, IBookAppServices bookAppServices) : ControllerBase
{
    private readonly ILogger<BookAppControllers> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly IBookAppServices _bookAppServices = bookAppServices ?? throw new ArgumentNullException(nameof(bookAppServices));

    [HttpGet("GetBooks")]
    public IActionResult GetBooks()
    {
        List<string> books = _bookAppServices.GetBooks();
        
        return Ok(books);
    }
}
