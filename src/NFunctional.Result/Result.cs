using System.Diagnostics.Contracts;

namespace NFunctional.Result;

public readonly struct Result
{
    private readonly Error _error;

    public Result()
    {
        _error = Error.None;
    }

    public Result(
        Error error)
    {
        _error = error;
    }

    [Pure]
    public bool IsSuccess => _error == Error.None;

    [Pure]
    public bool IsFailure => !IsSuccess;

    public static Result Success() => new();

    public static Result Failure(Error error) => new(error);
}
