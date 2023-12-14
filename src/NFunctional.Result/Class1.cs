namespace NFunctional.Result;

public enum ResultState : byte
{
    Success,
    Failure
}

public readonly partial struct Result
{
    private readonly ResultState _state;

    private readonly Error _error;

    public Result(
        ResultState state,
        Error error)
    {
        _state = state;
        _error = error;
    }
}

public sealed class Error
{
    public string Code { get; private init; }

    public string Message { get; private init; }

    public Error(
        string code,
        string message)
    {
        Code = code;
        Message = message;
    }

    internal static Error None => new(string.Empty, string.Empty);
}
