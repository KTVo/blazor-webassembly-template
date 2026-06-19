using BookStoreApp.API.MVCS.Services.Interfaces;

namespace BookStoreApp.API.MVCS.Services.Implementations;

public sealed class BookAppServices(ILogger<BookAppServices> logger) : IBookAppServices
{
    private readonly ILogger<BookAppServices> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    /// <summary>
    /// RETURNS A LIST OF BOOKS.
    /// </summary>
    /// <returns></returns>
    public List<string> GetBooks()
    {
        _logger.LogInformation("Getting books from the service.");

        try
        {
            return new List<string>
            {
                "Book 1",
                "Book 2",
                "Book 3"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new List<string>();
        }

    }
}
