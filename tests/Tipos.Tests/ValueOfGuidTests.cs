namespace Tipos.Tests;

public class ValueOfGuidTests
{
    [Fact]
    public void GuidValue_Validate_ThrowsOnEmpty()
    {
        Assert.Throws<ArgumentException>(() => OrderId.From(Guid.Empty));
    }

    [Fact]
    public void GuidValue_Valid_RoundTrips()
    {
        var guid = Guid.NewGuid();
        var orderId = OrderId.From(guid);

        Assert.Equal(guid, orderId.Value);
    }
}
