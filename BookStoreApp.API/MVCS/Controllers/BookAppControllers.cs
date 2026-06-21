using BookStoreApp.API.MVCS.Models.DBM.Collections;
using BookStoreApp.API.MVCS.Models.Generics.Responses;
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

    /// <summary>
    /// GETS ALL BOOKS FROM THE DATABASE.
    /// </summary>
    /// <returns></returns>
    [HttpGet("get/books/all")]
    public async Task<IActionResult> GetAllBooks()
    {
        GenericResponse<List<Book>> response = await _bookAppServices.GetAllBooksAsync();

        return Ok(response);
    }

    [HttpPost("add/book")]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        if (book == null) { return BadRequest("Base model is null!"); }

        GenericResponse<bool> response = await _bookAppServices.AddBookAsync<bool>(book);

        return Ok(response);
    }
}

