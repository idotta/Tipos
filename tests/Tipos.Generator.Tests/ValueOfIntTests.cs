namespace Tipos.Generator.Tests;

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
    public void TryFrom_Invalid_NoTryValidate_ReturnsFalse()
    {
        var ok = UserId.TryFrom(-1, out var id);

        Assert.False(ok);
        Assert.Equal(default, id);
    }

    [Fact]
    public void TryFrom_Valid_NoTryValidate_ReturnsTrue()
    {
        var ok = UserId.TryFrom(2, out var id);

        Assert.True(ok);
        Assert.Equal(2, id.Value);
    }

    [Fact]
    public void ToString_UsesValue()
    {
        var id = UserId.From(42);

        Assert.Equal("42", id.ToString());
    }

    [Fact]
    public void CompareTo_UsesValue()
    {
        var a = UserId.From(1);
        var b = UserId.From(2);

        Assert.True(a.CompareTo(b) < 0);
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
}
