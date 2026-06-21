using BookStoreApp.API.MVCS.Models.DBM.Collections;
using BookStoreApp.API.MVCS.Models.Generics.Responses;

namespace BookStoreApp.API.MVCS.Services.Interfaces;

public interface IBookAppServices
{
    Task<GenericResponse<List<Book>>> GetAllBooksAsync();
    Task<GenericResponse<bool>> AddBookAsync<T>(Book book);
}
