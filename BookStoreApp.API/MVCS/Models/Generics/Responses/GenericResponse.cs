using BookStoreApp.API.MVCS.Models._Base;

namespace BookStoreApp.API.MVCS.Models.Generics.Responses;

public sealed class GenericResponse<T> : BaseResponse
{
    public T? Data { get; set; }
}
