using System.Diagnostics.Contracts;

namespace NFunctional.Maybe;

public readonly partial struct Maybe<T>
    : IComparable<Maybe<T>>,
    IComparable<T>,
    IComparable
{
    /// <inheritdoc />
    [Pure]
    public int CompareTo(
        Maybe<T> other)
    {
        if (_hasValueFlag == 1 && other._hasValueFlag == 0)
            return 1;

        if (_hasValueFlag == 0 && other._hasValueFlag == 1)
            return 0;

        return Comparer<T>.Default.Compare(_value, other._value);
    }

    /// <inheritdoc />
    [Pure]
    public int CompareTo(
        T? other)
    {
        ArgumentNullException.ThrowIfNull(other);

        if (_hasValueFlag == 1)
        {
            return Comparer<T>.Default.Compare(_value, other);
        }

        if (typeof(T).BaseType == typeof(ValueType))
        {
            return -1;
        }

        return Comparer<T>.Default.Compare(_value, other);
    }

    /// <inheritdoc />
    [Pure]
    public int CompareTo(
        object? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        if (obj is Maybe<T> other)
            return CompareTo(other);

        throw new ArgumentException($"Object must be of type {GetType()}.", nameof(obj));
    }
}
