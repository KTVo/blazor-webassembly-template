using BookStoreApp.API.Helpers;
using BookStoreApp.API.MVCS.Models.DBM.Collections;
using BookStoreApp.API.MVCS.Models.Generics.Responses;
using BookStoreApp.API.MVCS.Repositories.Interfaces;
using BookStoreApp.API.MVCS.Services._DB.Implementations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.MVCS.Repositories.Implementations;
public sealed class BookStoreRepository(
    ILogger<BookStoreRepository> logger,
    BookStoreDbContext dbContext) : IBookStoreRepository
{
    private readonly ILogger<BookStoreRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly BookStoreDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    /// <summary>
    /// LIST ALL BOOKS IN THE DATABASE
    /// </summary>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<GenericResponse<List<Book>>> GetAllBooksAsync()
    {
        try
        {
            IQueryable<Book> query = _dbContext.Set<Book>().AsNoTracking();

            List<Book> books = await query.ToListAsync();

            return GenericResponseHelper.GetResponse<List<Book>>(books, true, "Books retrieved successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return GenericResponseHelper.GetResponse<List<Book>>(new List<Book>(), false, ex.Message);
        }
    }

    /// <summary>
    /// ADD AN AUTHOR TO THE DATABASE
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    public async Task<GenericResponse<bool>> AddAuthorAsync(Author author)
    {
        try
        {
            await _dbContext.Set<Author>().AddAsync(author);
            int result = await _dbContext.SaveChangesAsync();

            bool isSuccess = result > 0;

            return GenericResponseHelper.GetResponse<bool>(isSuccess, true, "Author added successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return GenericResponseHelper.GetResponse<bool>(false, false, "Failed to add author.");
        }
    }

    /// <summary>
    /// LIST ALL AUTHORS IN THE DATABASE
    /// </summary>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<GenericResponse<List<Author>>> GetAllAuthorsAsync()
    {
        try
        {
            IQueryable<Author> query = _dbContext.Set<Author>().AsNoTracking();

            List<Author> authors = await query.ToListAsync();

            return GenericResponseHelper.GetResponse<List<Author>>(authors, true, "Authors retrieved successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return GenericResponseHelper.GetResponse<List<Author>>(new List<Author>(), false, ex.Message);
        }
    }

    /// <summary>
    /// GET ALL BOOKS BY AUTHOR ID FROM THE DATABASE
    /// </summary>
    /// <param name="authorId"></param>
    /// <returns></returns>
    public async Task<GenericResponse<List<Book>>> GetBooksByAuthorIdAsync(string authorId)
    {
        try
        {
            IQueryable<Book> query = _dbContext.Set<Book>().AsNoTracking();

            List<Book> books = await query
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();

            return GenericResponseHelper.GetResponse<List<Book>>(books, true, "Books retrieved successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return GenericResponseHelper.GetResponse<List<Book>>(new List<Book>(), false, ex.Message);
        }
    }

    /// <summary>
    /// GET A BOOK BY ID FROM THE DATABASE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<GenericResponse<Book?>> GetBookByIdAsync(int id)
    {
        try
        {
            IQueryable<Book> query = _dbContext.Set<Book>().AsNoTracking();

            Book? book = await query
                .Where(b => b.Id == id.ToString())
                .FirstOrDefaultAsync();

            return GenericResponseHelper.GetResponse<Book?>(book, true, "Book retrieved successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return GenericResponseHelper.GetResponse<Book?>(null, false, ex.Message);
        }
    }

    /// <summary>
    /// ADD A BOOK TO THE DATABASE
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public async Task<GenericResponse<bool>> AddBookAsync(Book book)
    {
        try
        {
            await _dbContext.Set<Book>().AddAsync(book);
            int result = await _dbContext.SaveChangesAsync();

            bool isSuccess = result > 0;

            return GenericResponseHelper.GetResponse<bool>(isSuccess, true, "Book added successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return GenericResponseHelper.GetResponse<bool>(false, false, "Failed to add book.");
        }
    }

    /// <summary>
    /// UPDATE A BOOK IN THE DATABASE
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public async Task<GenericResponse<bool>> UpdateBookAsync(Book book)
    {
        try
        {
            _dbContext.Set<Book>().Update(book);
            int result = await _dbContext.SaveChangesAsync();

            bool isSuccess = result > 0;

            return GenericResponseHelper.GetResponse<bool>(isSuccess, true, "Book updated successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return GenericResponseHelper.GetResponse<bool>(false, false, "Failed to update book.");
        }
    }

    /// <summary>
    /// DELETE A BOOK FROM THE DATABASE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<GenericResponse<bool>> DeleteBookAsync(int id)
    {
        try
        {
            Book book = new() { Id = id.ToString() };

            _dbContext.Set<Book>().Remove(book);
            int result = _dbContext.SaveChanges();

            bool isSuccess = result > 0;

            return GenericResponseHelper.GetResponse<bool>(isSuccess, true, "Book deleted successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return GenericResponseHelper.GetResponse<bool>(false, false, "Failed to delete book.");
        }
    }
}
