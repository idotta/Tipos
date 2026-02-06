namespace Tipos.Generator.Tests;

public class ValueOfTryValidateTests
{
    [Fact]
    public void TryFrom_HandledFalse_FallsBackToValidate()
    {
        ValidateFallback.Reset();

        var ok = ValidateFallback.TryFrom(1, out var id);

        Assert.True(ok);
        Assert.Equal(1, id.Value);
        Assert.Equal(1, ValidateFallback.ValidateCallCount);
    }

    [Fact]
    public void TryFrom_HandledTrue_Invalid_ReturnsFalse_WithoutValidate()
    {
        ValidateHandled.Reset();

        var ok = ValidateHandled.TryFrom(-1, out var id);

        Assert.False(ok);
        Assert.Equal(default, id);
        Assert.Equal(0, ValidateHandled.ValidateCallCount);
    }

    [Fact]
    public void TryFrom_HandledTrue_Valid_ReturnsTrue_WithoutValidate()
    {
        ValidateHandled.Reset();

        var ok = ValidateHandled.TryFrom(3, out var id);

        Assert.True(ok);
        Assert.Equal(3, id.Value);
        Assert.Equal(0, ValidateHandled.ValidateCallCount);
    }

    [Fact]
    public void TryValidate_ReturnsFalse_OnInvalidString()
    {
        var ok = TryValidateClientRef.TryFrom("", out var valueObject);

        Assert.False(ok);
        Assert.Equal(default, valueObject);
    }

    [Fact]
    public void TryValidate_ReturnsTrue_OnValidString()
    {
        var ok = TryValidateClientRef.TryFrom("something", out var valueObject);

        Assert.True(ok);
        Assert.Equal("something", valueObject.Value);
    }
}
