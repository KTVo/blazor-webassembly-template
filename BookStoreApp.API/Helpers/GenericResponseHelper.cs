using BookStoreApp.API.MVCS.Models.Generics.Responses;

namespace BookStoreApp.API.Helpers;

public static class GenericResponseHelper
{
    public static GenericResponse<T> GetResponse<T>(T? data, bool isSuccess, string message)
    {
        return new GenericResponse<T>
        {
            Data = data,
            IsSuccess = isSuccess,
            Message = message
        };
    }
}
