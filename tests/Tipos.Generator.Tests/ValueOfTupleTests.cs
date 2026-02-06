namespace Tipos.Generator.Tests;

public class ValueOfTupleTests
{
    [Fact]
    public void TupleValue_ToString_UsesValueToString()
    {
        var address = Address.From(new AddressValue("16 Food Street", "London", Postcode.From("N1 1LT")));

        Assert.Equal(address.Value.ToString(), address.ToString());
    }

    [Fact]
    public void TupleValue_Equality_MatchesValue()
    {
        var address1 = Address.From(new AddressValue("16 Food Street", "London", Postcode.From("N1 1LT")));
        var address2 = Address.From(new AddressValue("16 Food Street", "London", Postcode.From("N1 1LT")));
        var address3 = Address.From(new AddressValue("17 Food Street", "London", Postcode.From("N1 1LT")));

        Assert.Equal(address1, address2);
        Assert.Equal(address1.GetHashCode(), address2.GetHashCode());
        Assert.NotEqual(address1, address3);
        Assert.NotEqual(address1.GetHashCode(), address3.GetHashCode());
    }
}
