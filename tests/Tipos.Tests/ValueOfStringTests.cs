namespace Tipos.Tests;

public class ValueOfStringTests
{
    [Fact]
    public void StringValue_ValidatesAndCompares()
    {
        var ref1 = ClientRef.From("ASDF12345");
        var ref2 = ClientRef.From("ASDF12345");
        var ref3 = ClientRef.From("QWER98765");

        Assert.Equal(ref1, ref2);
        Assert.Equal(ref1.GetHashCode(), ref2.GetHashCode());
        Assert.NotEqual(ref1, ref3);
        Assert.NotEqual(ref1.GetHashCode(), ref3.GetHashCode());
    }

    [Fact]
    public void StringValue_Validate_ThrowsOnEmpty()
    {
        Assert.Throws<ArgumentException>(() => ClientRef.From(""));
    }
}
