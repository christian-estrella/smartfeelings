namespace SmartFeelings.Application.Common.Base;

public class BaseResponse<T>
{
    public bool Success { get; init; }
    public string Message { get; init; }
    public T? Data { get; init; }

    public BaseResponse(bool success, string message, T? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}