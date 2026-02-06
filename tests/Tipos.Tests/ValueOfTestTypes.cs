namespace Tipos.Tests;

public sealed class UserId : ValueOf<int, UserId>
{
    protected override void Validate()
    {
        if (Value < 0)
        {
            throw new ArgumentException("Id cannot be negative", nameof(Value));
        }
    }
}

public sealed class ClientRef : ValueOf<string, ClientRef>
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            throw new ArgumentException("Value cannot be null or empty", nameof(Value));
        }
    }
}

public sealed class TryValidateClientRef : ValueOf<string, TryValidateClientRef>
{
    protected override bool TryValidate()
    {
        return !string.IsNullOrWhiteSpace(Value);
    }
}

public sealed class Postcode : ValueOf<string, Postcode>
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            throw new ArgumentException("Postcode cannot be null or empty", nameof(Value));
        }
    }
}

public sealed class Address : ValueOf<(string firstLine, string secondLine, Postcode postcode), Address>
{
}

public sealed class OrderId : ValueOf<Guid, OrderId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("Value cannot be empty", nameof(Value));
        }
    }
}

public sealed class Money : ValueOf<decimal, Money>
{
    protected override void Validate()
    {
        if (Value < 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(Value), "Value cannot be negative");
        }
    }
}
