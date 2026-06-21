using BookStoreApp.API.MVCS.Models.DBM.Collections;
using BookStoreApp.API.MVCS.Models.Generics.Responses;

namespace BookStoreApp.API.MVCS.Repositories.Interfaces;

public interface IBookStoreRepository
{
    Task<GenericResponse<List<Book>>> GetAllBooksAsync();
    Task<GenericResponse<List<Author>>> GetAllAuthorsAsync();
    Task<GenericResponse<Author?>> GetAuthorByIdAsync(int id);
    Task<GenericResponse<bool>> AddAuthorAsync(Author author);
    Task<GenericResponse<bool>> UpdateAuthorAsync(Author author);
    Task<GenericResponse<bool>> DeleteAuthorAsync(int id);
    Task<GenericResponse<Book?>> GetBookByIdAsync(int id);
    Task<GenericResponse<bool>> AddBookAsync(Book book);
    Task<GenericResponse<bool>> UpdateBookAsync(Book book);
    Task<GenericResponse<bool>> DeleteBookAsync(int id);
}