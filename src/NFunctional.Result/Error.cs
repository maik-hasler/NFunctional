namespace NFunctional.Result;

public sealed class Error(
    string code,
    string message)
{
    public string Code { get; private set; } = code;

    public string Message { get; private set; } = message;

    internal static Error None => new(string.Empty, string.Empty);
}
