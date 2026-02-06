namespace Tipos.Generator.Tests;

public class ValueOfDecimalTests
{
    [Fact]
    public void DecimalValue_Validate_ThrowsOnNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Money.From(-1m));
    }

    [Fact]
    public void DecimalValue_Valid_RoundTrips()
    {
        var money = Money.From(10.5m);

        Assert.Equal(10.5m, money.Value);
    }
}
