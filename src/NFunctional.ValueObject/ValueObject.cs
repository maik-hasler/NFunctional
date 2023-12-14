namespace NFunctional.ValueObject;


/// <summary>
/// Represents a base class for value objects.
/// </summary>
public abstract partial class ValueObject
{
    /// <summary>
    /// Gets the equality components of the value object.
    /// </summary>
    /// <returns>An enumerable of the equality components.</returns>
    protected abstract IEnumerable<object> GetEqualityComponents();
}
