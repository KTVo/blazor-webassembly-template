namespace BookStoreApp.API.MVCS.Models._Base;

public class BaseResponse
{
    public bool? IsSuccess { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }
}
