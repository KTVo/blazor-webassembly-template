using BookStoreApp.API.MVCS.Models.DBM.Collections;
using BookStoreApp.API.MVCS.Models.Generics.Responses;
using BookStoreApp.API.MVCS.Repositories.Interfaces;
using BookStoreApp.API.MVCS.Services.Interfaces;

namespace BookStoreApp.API.MVCS.Services.Implementations;

public sealed class BookAppServices(ILogger<BookAppServices> logger, IBookStoreRepository bookStoreRepository) : IBookAppServices
{
    private readonly ILogger<BookAppServices> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly IBookStoreRepository _bookStoreRepository = bookStoreRepository ?? throw new ArgumentNullException(nameof(bookStoreRepository));

    /// <summary>
    /// RETURNS A LIST OF BOOKS.
    /// </summary>
    /// <returns></returns>
    public async Task<GenericResponse<List<Book>>> GetAllBooksAsync()
    {
        GenericResponse<List<Book>> response = await _bookStoreRepository.GetAllBooksAsync();

        return response;

    }
    
    public async Task<GenericResponse<bool>> AddBookAsync<T>(Book book)
    {
        GenericResponse<bool> response = await _bookStoreRepository.AddBookAsync(book);

        return response;
    }
}
