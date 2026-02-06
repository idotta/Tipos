namespace Tipos.Tests;

public class ValueOfTryValidateTests
{
    [Fact]
    public void TryValidate_ReturnsFalse_OnInvalidString()
    {
        var ok = TryValidateClientRef.TryFrom("", out var valueObject);

        Assert.False(ok);
        Assert.Null(valueObject);
    }

    [Fact]
    public void TryValidate_ReturnsTrue_OnValidString()
    {
        var ok = TryValidateClientRef.TryFrom("something", out var valueObject);

        Assert.True(ok);
        Assert.NotNull(valueObject);
        Assert.Equal("something", valueObject.Value);
    }

    [Fact]
    public void TryValidate_ReturnsFalse_OnNullString()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var ok = TryValidateClientRef.TryFrom(null, out var valueObject);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        Assert.False(ok);
        Assert.Null(valueObject);
    }
}
