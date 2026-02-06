namespace Tipos.Tests;

public class ValueOfIntTests
{
    [Fact]
    public void From_Valid_ReturnsValue()
    {
        var id = UserId.From(5);

        Assert.Equal(5, id.Value);
    }

    [Fact]
    public void From_Invalid_Throws()
    {
        Assert.Throws<ArgumentException>(() => UserId.From(-1));
    }

    [Fact]
    public void TryFrom_Valid_ReturnsValue()
    {
        var ok = UserId.TryFrom(2, out var id);

        Assert.True(ok);
        Assert.NotNull(id);
        Assert.Equal(2, id.Value);
    }

    [Fact]
    public void ToString_UsesValue()
    {
        var id = UserId.From(42);

        Assert.Equal("42", id.ToString());
    }

    [Fact]
    public void Equality_BasedOnValue()
    {
        var a = UserId.From(1);
        var b = UserId.From(1);

        Assert.Equal(a, b);
        Assert.True(a == b);
        Assert.False(a != b);
    }

    [Fact]
    public void Equality_DifferentValues_NotEqual()
    {
        var a = UserId.From(1);
        var b = UserId.From(2);

        Assert.NotEqual(a, b);
        Assert.False(a == b);
        Assert.True(a != b);
    }

    [Fact]
    public void Equality_Null_ReturnsFalse()
    {
        var a = UserId.From(1);
        ValueOf<int, UserId>? b = null;

        Assert.False(a.Equals(b));
        Assert.False(a == b);
        Assert.True(a != b);
    }
}
