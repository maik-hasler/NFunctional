namespace NFunctional.Maybe;

public readonly partial struct Maybe<T>
{
    private readonly T _value;

    private readonly byte _hasValueFlag;

    public Maybe(
        T? value)
    {
        if (typeof(T).GetGenericTypeDefinition() == typeof(Maybe<>)
            || typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            throw new InvalidOperationException();
        }

        if (value == null)
        {
            _hasValueFlag = 0;
            _value = default!;
            return;
        }

        _hasValueFlag = 1;
        _value = value;
    }

    public static Maybe<T> From(
        T? value)
    {
        return new(value);
    }

    public static Maybe<T> From<U>(
        U? value)
    {
        return new((T?)(object?)value);
    }

    public static explicit operator T(
        in Maybe<T> maybe)
    {
        return (maybe._hasValueFlag & 1) == 1
            ? maybe._value
            : throw new InvalidOperationException(
                $"Cannot perform explicit cast on {nameof(Maybe<T>)} without a value to type {nameof(T)}.");
    }

    public static implicit operator Maybe<T>(
        T? value)
    {
        return new(value);
    }
}
