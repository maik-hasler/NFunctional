namespace NFunctional.ValueObject;

public abstract partial class ValueObject
    : IComparable<ValueObject>,
    IComparable
{
    /// <inheritdoc />
    public int CompareTo(
        ValueObject? other)
    {
        if (other == null)
            return 1;

        var components = GetEqualityComponents().GetEnumerator();
        var otherComponents = other.GetEqualityComponents().GetEnumerator();

        while (components.MoveNext() && otherComponents.MoveNext())
        {
            var comparison = Comparer<object>.Default.Compare(components.Current, otherComponents.Current);

            if (comparison != 0)
                return comparison;
        }

        return 0;
    }

    /// <inheritdoc />
    public int CompareTo(
        object? obj)
    {
        return obj switch
        {
            null => 1,
            ValueObject other => CompareTo(other),
            _ => throw new ArgumentException($"Object must be of type {nameof(ValueObject)}")
        };
    }
}
