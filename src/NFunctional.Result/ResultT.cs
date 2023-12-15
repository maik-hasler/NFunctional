using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NFunctional.Result;

public readonly struct Result<T>
{
    private readonly T _value;

    private readonly Error _error;

    public Result(T value)
    {
        _value = value;
        _error = Error.None;
    }

    public Result(Error error)
    {
        _error = error;
        _value = default!;
    }

    [Pure]
    public bool TryGetValue(
        [NotNullWhen(true)] out T value)
    {
        value = _value;

        return _error == Error.None;
    }

    [Pure]
    public bool IsSuccess => _error == Error.None;

    [Pure]
    public bool IsFailure => !IsSuccess;

    public static Result<T> Success(T value) => new(value);

    public static Result<T> Failure(Error error) => new(error);
}
